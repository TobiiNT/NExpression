﻿using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Nodes.NodeStructures;
using NExpression.Core.Expressions.Operations;
using NExpression.Core.Expressions.Operations.Interfaces;
using NExpression.Core.Expressions.Parsers.Interfaces;
using NExpression.Core.Helpers;
using NExpression.Core.Tokens;

namespace NExpression.Core.Expressions.Parsers
{
    internal class AssignmentParser : IParser
    {
        public Tokenizer Tokenizer { private set; get; }
        public IParser NextParser { private set; get; }
        public List<Token> MaskToken { private set; get; }
        public IContext? Context { private set; get; }

        public AssignmentParser(IContext? Context, Tokenizer Tokenizer, IParser NextParser, List<Token> MaskToken)
        {
            this.Tokenizer = Tokenizer;
            this.NextParser = NextParser;
            this.MaskToken = MaskToken;
            this.Context = Context;
        }

        public INode Parse<T>()
        {
            var LeftNode = NextParser.Parse<T>();

            while (true)
            {
                Token CurrentToken = Tokenizer.Token;

                if (MaskToken.Contains(CurrentToken))
                {
                    MathOperation MathOperation = OperationHelpers.GetOperationByToken(CurrentToken);

                    IOperation? Operation = OperationHelpers.GetOperation(MathOperation, Context);

                    if (Operation == null)
                        return LeftNode;

                    Tokenizer.NextToken();

                    var RightNode = NextParser.Parse<T>();

                    if (LeftNode is NodeVariable Variable)
                    {
                        LeftNode = new NodeAssignment(Variable, RightNode, MathOperation);
                    }
                    else if (LeftNode is NodeNested Nested)
                    {
                        var NestedResult = Nested.GetFinalNode();
                        if (NestedResult is NodeVariable VariableInside)
                        {
                            LeftNode = new NodeAssignment(VariableInside, RightNode, MathOperation);
                        }
                        else throw new InvalidOperationException("The left-hand side of an assignment must be a variable", new InvalidMathOperatorException(MathOperation, LeftNode, RightNode));
                    }
                    else throw new InvalidOperationException("The left-hand side of an assignment must be a variable", new InvalidMathOperatorException(MathOperation, LeftNode, RightNode));
                }
                else return LeftNode;

            }
        }
    }
}
