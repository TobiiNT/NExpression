using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions;
using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Tokens;

namespace NExpression.Core.Helpers
{
    public static class ExpressionHelpers
    {
        public static INode Parse(string? ExpressionString, IContext? ReadContext = null)
        {
            return Parse(TokenHelpers.Parse(ExpressionString), ReadContext);
        }

        public static INode Parse(Tokenizer Tokenizer, IContext? Context)
        {
            var Parser = new Expression(Tokenizer, Context);
            return Parser.ParseExpression<object>();
        }
    }
}
