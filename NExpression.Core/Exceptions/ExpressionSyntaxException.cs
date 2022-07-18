namespace NExpression.Core.Exceptions
{
    public class ExpressionSyntaxException : Exception
    {
        public ExpressionSyntaxException(string Message)
            : base(Message)
        {
        }
    }
}
