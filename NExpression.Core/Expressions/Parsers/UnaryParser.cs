using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Nodes.NodeDatas;
using NExpression.Core.Expressions.Nodes.NodeStructures;
using NExpression.Core.Expressions.Nodes.NodeStructures.Unaries;
using NExpression.Core.Expressions.Parsers.Interfaces;
using NExpression.Core.Tokens;

namespace NExpression.Core.Expressions.Parsers
{
    internal class UnaryParser : IParser
    {
        public Tokenizer Tokenizer { private set; get; }
        public IParser NextParser { private set; get; }
        public List<Token> MaskToken { private set; get; }
        public IContext? Context { private set; get; }
        public UnaryParser(IContext? Context, Tokenizer Tokenizer, IParser NextParser, List<Token> MaskToken)
        {
            this.Tokenizer = Tokenizer;
            this.NextParser = NextParser;
            this.MaskToken = MaskToken;
            this.Context = Context;
        }

        public INode Parse<T>()
        {
            while (true)
            {
                Token CurrentToken = Tokenizer.Token;

                if (MaskToken.Contains(CurrentToken))
                {
                    Tokenizer.NextToken();

                    if (CurrentToken == Token.SingleCross)
                    {
                        continue;
                    }

                    // Parse parameter
                    var RightNode = Parse<T>();

                    // Create unary node
                    if (CurrentToken == Token.DoubleCross || CurrentToken == Token.DoubleDash)
                    {
                        // Create unary node
                        if (RightNode is NodeVariable Variable)
                        {
                            if (CurrentToken == Token.DoubleCross)
                            {
                                return new NodeUnaryAddBeforeReturn(Variable);
                            }
                            else if (CurrentToken == Token.DoubleDash)
                            {
                                return new NodeUnarySubtractBeforeReturn(Variable);
                            }
                            else return new NodeNull();
                        }
                        else throw new InvalidOperationException("The operand of an increment or decrement operator must be a variable");
                    }
                    else if (CurrentToken == Token.SingleDash) // -n
                    {
                        return new NodeUnaryNegative(RightNode);
                    }
                    if (CurrentToken == Token.SingleTilde) // ~0 ~1
                    {
                        return new NodeUnaryBitwiseNOT(RightNode);
                    }
                    else if (CurrentToken == Token.SingleExclamation) // Logical NOT
                    {
                        return new NodeUnaryLogicalNOT(RightNode);
                    }
                }
                // No unary symbol
                return NextParser.Parse<T>();
            }
        }
    }
}
