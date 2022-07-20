using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Nodes.NodeDatas;
using NExpression.Core.Expressions.Nodes.NodeStructures;
using NExpression.Core.Expressions.Nodes.NodeStructures.Postfixs;
using NExpression.Core.Expressions.Parsers.Interfaces;
using NExpression.Core.Tokens;

namespace NExpression.Core.Expressions.Parsers
{
    internal class PostfixParser : IParser
    {
        public Tokenizer Tokenizer { private set; get; }
        public IParser NextParser { private set; get; }
        public List<Token> MaskToken { private set; get; }
        public IContext? Context { private set; get; }

        public PostfixParser(IContext? Context, Tokenizer Tokenizer, IParser NextParser, List<Token> MaskToken)
        {
            this.Context = Context;
            this.Tokenizer = Tokenizer;
            this.NextParser = NextParser;
            this.MaskToken = MaskToken;
        }

        public INode Parse<T>()
        {
            var LeftNode = NextParser.Parse<T>();

            while (true)
            {
                Token CurrentToken = Tokenizer.Token;

                if (MaskToken.Contains(CurrentToken))
                {
                    Tokenizer.NextToken();

                    if (CurrentToken == Token.DoubleCross || CurrentToken == Token.DoubleDash)
                    {
                        if (LeftNode is NodeVariable Variable)
                        {
                            if (CurrentToken == Token.DoubleCross)
                            {
                                LeftNode = new NodeAddAfterReturn(Variable, Context);
                            }
                            else if (CurrentToken == Token.DoubleDash) // i--
                            {
                                LeftNode = new NodeSubtractAfterReturn(Variable, Context);
                            }
                            else return new NodeNull();
                        }
                        else throw new InvalidOperationException("The left-hand side of an assignment must be a variable");
                    }
                    else if (CurrentToken == Token.SingleExclamation) // 9!
                    {
                        LeftNode = new NodeFactorial(LeftNode, Context);
                    }
                    else if (CurrentToken == Token.OpenBlacket)
                    {
                        INode IndexNode = this.NextParser.Parse<T>();
                    
                        if (Tokenizer.Token != Token.CloseBlacket)
                        {
                            throw new ExpressionSyntaxException("Missing close blacket");
                        }
                    
                        Tokenizer.NextToken();
                    
                        return new NodeGetArrayItemByIndex(LeftNode, IndexNode, Context);
                    }
                }
                else return LeftNode;
            }
        }
    }
}
