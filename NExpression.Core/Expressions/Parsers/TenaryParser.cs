using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Nodes.NodeStructures;
using NExpression.Core.Expressions.Parsers.Interfaces;
using NExpression.Core.Tokens;

namespace NExpression.Core.Expressions.Parsers
{
    internal class TenaryParser : IParser
    {
        public Tokenizer Tokenizer { private set; get; }
        public IParser NextParser { private set; get; }
        public List<Token> MaskToken { private set; get; }
        public IContext Context => throw new NotImplementedException();

        public TenaryParser(Tokenizer Tokenizer, IParser NextParser, List<Token> MaskToken)
        {
            this.Tokenizer = Tokenizer;
            this.NextParser = NextParser;
            this.MaskToken = MaskToken;
        }

        public INode Parse<T>()
        {
            var Condition = NextParser.Parse<T>();

            while (true)
            {
                Token CurrentToken = Tokenizer.Token;

                if (MaskToken.Contains(CurrentToken))
                {
                    Tokenizer.NextToken();

                    var LeftSide = NextParser.Parse<T>();

                    CurrentToken = Tokenizer.Token;

                    if (CurrentToken == Token.SingleColon)
                    {
                        Tokenizer.NextToken();

                        var RightSide = NextParser.Parse<T>();

                        Tokenizer.NextToken();

                        return new NodeTenary(Condition, LeftSide, RightSide);
                    }
                    else if (CurrentToken == Token.SingleQuestion) // Nested tenary
                    {
                        INode MissingNode = Parse<T>();
                        if (MissingNode is NodeTenary TenaryNode)
                        {
                            TenaryNode.SetCondition(LeftSide);

                            Tokenizer.NextToken();

                            return TenaryNode;
                        }
                        else throw new ExpressionSyntaxException("Missing close parenthesis");
                    }
                }
                else return Condition;
            }
        }
    }
}
