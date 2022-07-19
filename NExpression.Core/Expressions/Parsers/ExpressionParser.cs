using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Nodes.NodeStructures;
using NExpression.Core.Expressions.Operations;
using NExpression.Core.Expressions.Operations.Interfaces;
using NExpression.Core.Expressions.Parsers.Interfaces;
using NExpression.Core.Helpers;
using NExpression.Core.Tokens;

namespace NExpression.Core.Expressions.Parsers
{
    internal class ExpressionParser : IParser
    {
        public Tokenizer Tokenizer { private set; get; }
        public IParser NextParser { private set; get; }
        public List<Token> MaskToken { private set; get; }

        public ExpressionParser(Tokenizer Tokenizer, IParser NextParser, List<Token> MaskToken)
        {
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
                    MathOperation MathOperation = OperationHelpers.GetOperationByToken(CurrentToken);

                    IOperation? Operation = OperationHelpers.GetOperation(MathOperation);

                    if (Operation == null)
                        return LeftNode;

                    Tokenizer.NextToken();

                    var RightSide = NextParser.Parse<T>();

                    LeftNode = new NodeBinaryTree(LeftNode, RightSide, Operation);
                }
                else return LeftNode;
            }
        }
    }
}
