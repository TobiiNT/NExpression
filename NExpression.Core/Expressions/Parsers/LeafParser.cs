﻿using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Nodes.NodeDatas;
using NExpression.Core.Expressions.Nodes.NodeDatas.Booleans;
using NExpression.Core.Expressions.Nodes.NodeDatas.Numbers;
using NExpression.Core.Expressions.Nodes.NodeDatas.Strings;
using NExpression.Core.Expressions.Nodes.NodeStructures;
using NExpression.Core.Expressions.Parsers.Interfaces;
using NExpression.Core.Tokens;
using System.Text;

namespace NExpression.Core.Expressions.Parsers
{
    internal class LeafParser : IParser
    {
        public Tokenizer Tokenizer { private set; get; }
        public IParser NextParser => throw new NotImplementedException();
        public Expression Expression { private set; get; }

        public LeafParser(Tokenizer Tokenizer, Expression Expression)
        {
            this.Tokenizer = Tokenizer;
            this.Expression = Expression;
        }

        public INode Parse<T>()
        {
            Token CurrentToken = Tokenizer.Token;

            if (CurrentToken == Token.DoubleQuote)
            {
                StringBuilder StringValue = new StringBuilder();
                while (true)
                {
                    Tokenizer.NextToken();

                    if (Tokenizer.Token == Token.EOF)
                        throw new ExpressionSyntaxException("Missing close parenthesis");

                    if (Tokenizer.Token == Token.DoubleQuote)
                        break;

                    StringValue.Append(Tokenizer.TokenString);
                }

                Tokenizer.NextToken();

                return new NodeString(StringValue.ToString());
            }
            else if (CurrentToken == Token.SingleQuote)
            {
                char Value = '\u0000';
                while (true)
                {
                    Tokenizer.NextToken();

                    if (Tokenizer.Token == Token.EOF)
                        throw new ExpressionSyntaxException("Missing close parenthesis");

                    if (Tokenizer.Token == Token.SingleQuote)
                    {
                        break;
                    }
                    else if (Value != '\u0000')
                    {
                        throw new InvalidCastException("Cannot cast value to char");
                    }

                    if (!char.TryParse(Tokenizer.TokenString, out Value))
                    {
                        throw new InvalidCastException("Cannot cast value to char");
                    }
                }
                Tokenizer.NextToken();

                return new NodeChar(Value);
            }
            else if (CurrentToken == Token.OpenBlacket)
            {
                Tokenizer.NextToken();

                var Node = Expression.Parser.Parse<T>();

                if (Tokenizer.Token != Token.CloseBlacket)
                {
                    throw new ExpressionSyntaxException("Missing close blacket");
                }

                Tokenizer.NextToken();

                return new NodeBlacket(Node);
            }
            else if (CurrentToken == Token.OpenParenthesis)
            {
                Tokenizer.NextToken();

                var Node = Expression.Parser.Parse<T>();

                if (Tokenizer.Token != Token.CloseParenthesis)
                {
                    if (Node is NodeTernaryTree)
                        return Node;
                    else throw new ExpressionSyntaxException("Missing close parenthesis");
                }

                Tokenizer.NextToken();

                return Node;
            }
            else if (CurrentToken == Token.SingleQuestion)
            {
                Tokenizer.NextToken(); // Skip TernaryOpen, goto LeftNode

                var LeftNode = Expression.Parser.Parse<T>();

                Tokenizer.NextToken(); // Goto RightNode

                var RightNode = Expression.Parser.Parse<T>();

                Tokenizer.NextToken();

                return new NodeTernaryTree(LeftNode, RightNode);
            }
            else if (CurrentToken == Token.KeywordVar)
            {
                Tokenizer.NextToken();

                var LeftSide = Expression.Parser.Parse<T>();

                if (LeftSide is NodeAssignment Assignment)
                {
                    Assignment.SetDeclare<object>(true);
                    return Assignment;
                }
                throw new ExpressionSyntaxException("Implicitly typed variables must be initialized");
            }
            else if (CurrentToken == Token.KeywordNew)
            {
                Tokenizer.NextToken();

                var CreationFunction = this.Parse<T>();

                if (CreationFunction is NodeFunctionCall Creation)
                {
                    return Creation;
                }
                throw new ExpressionSyntaxException("A new expression require creation function");
            }
            else if (CurrentToken == Token.Identifier) // Variable
            {
                var Name = Tokenizer.TokenString;

                Tokenizer.NextToken();

                if (Tokenizer.Token != Token.OpenParenthesis)
                {
                    return new NodeVariable(Name);
                }
                else
                {
                    Tokenizer.NextToken();

                    var Arguments = new List<INode>();
                    while (true)
                    {
                        if (Tokenizer.Token == Token.CloseParenthesis)
                            break;

                        Arguments.Add(Expression.Parser.Parse<T>());

                        if (Tokenizer.Token == Token.Comma)
                        {
                            Tokenizer.NextToken();
                            continue;
                        }

                        break;
                    }

                    if (Tokenizer.Token != Token.CloseParenthesis)
                        throw new ExpressionSyntaxException("Missing close parenthesis");

                    Tokenizer.NextToken();

                    return new NodeFunctionCall(Name, Arguments.ToArray());
                }
            }
            else
            {
                string TokenString = Tokenizer.TokenString;
                Tokenizer.NextToken();

                switch (CurrentToken)
                {
                    case Token.Binary: return new NodeBinary(TokenString);
                    case Token.FloatingDecimal: return new NodeFloatingDecimal(TokenString);
                    case Token.NonFloatingDecimal: return new NodeNonFloatingDecimal(TokenString);
                    case Token.Octal: return new NodeOctal(TokenString);
                    case Token.Hexadecimal: return new NodeHexadecimal(TokenString);
                    case Token.KeywordTrue: return new NodeBoolean(true);
                    case Token.KeywordFalse: return new NodeBoolean(false);
                    case Token.KeywordNull: return new NodeNull();
                }
            }


            throw new ExpressionSyntaxException($"Unexpected token: {Tokenizer.Token}");
        }
    }
}
