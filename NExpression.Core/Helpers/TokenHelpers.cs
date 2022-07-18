using NExpression.Core.Exceptions;
using NExpression.Core.Tokens;

namespace NExpression.Core.Helpers
{
    public static class TokenHelpers
    {
        public static Tokenizer Parse(string? Expression)
        {
            if (Expression == null)
                throw new NullExpressionException(nameof(Expression));

            return new Tokenizer(Expression);
        }

        public static Tokenizer Clone(Tokenizer Tokenizer)
        {
            if (Tokenizer == null)
                throw new NullExpressionException(nameof(Tokenizer));

            return new Tokenizer(Tokenizer);
        }

    }
}
