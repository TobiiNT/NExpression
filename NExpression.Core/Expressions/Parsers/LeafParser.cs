using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Nodes.NodeDatas;
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

                    StringValue.Append(Tokenizer.Value);
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
                        break;
                    else if (Value != '\u0000')
                        throw new InvalidCastException("Cannot cast value to char");

                    Value = (char)Tokenizer.Value;
                }
                Tokenizer.NextToken();

                return new NodeChar(Value);
            }
            else if (CurrentToken == Token.Number)
            {
                object Number = Tokenizer.Value;

                Tokenizer.NextToken();

                return new NodeNumber(Number);
            }
            else if (CurrentToken == Token.KeywordTrue)
            {
                Tokenizer.NextToken();

                return new NodeBoolean(true);
            }
            else if (CurrentToken == Token.KeywordFalse)
            {
                Tokenizer.NextToken();

                return new NodeBoolean(false);
            }
            else if (CurrentToken == Token.KeywordNull)
            {
                Tokenizer.NextToken();

                return new NodeNull();
            }
            else if (CurrentToken == Token.OpenParenthesis)
            {
                Tokenizer.NextToken();

                var Node = Expression.Parser.Parse<T>();

                if (Tokenizer.Token != Token.CloseParenthesis)
                {
                    if (Node is NodeTenary)
                        return Node;
                    else throw new ExpressionSyntaxException("Missing close parenthesis");
                }

                Tokenizer.NextToken();

                return Node;
            }
            else if (CurrentToken == Token.SingleQuestion)
            {
                Tokenizer.NextToken(); // Skip TenaryOpen, goto LeftNode

                var LeftNode = Expression.Parser.Parse<T>();

                Tokenizer.NextToken(); // Goto RightNode

                var RightNode = Expression.Parser.Parse<T>();

                Tokenizer.NextToken();

                return new NodeTenary(LeftNode, RightNode);
            }
            else if (CurrentToken == Token.KeywordVar)
            {
                Tokenizer.NextToken();

                var LeftSide = Expression.Parser.Parse<T>();

                if (LeftSide is NodeAssignment Assignment)
                {
                    Assignment.SetDeclare(true);
                    return Assignment;
                }
                throw new ExpressionSyntaxException("Implicitly typed variables must be initialized");
            }
            else if (CurrentToken == Token.Identifier) // Variable
            {
                var Name = Tokenizer.Identifier;

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
            throw new ExpressionSyntaxException($"Unexpected token: {Tokenizer.Token}");
        }
    }
}
