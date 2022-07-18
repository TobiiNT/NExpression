namespace NExpression.Core.Exceptions
{
    public class NullExpressionException : Exception
    {
        public NullExpressionException(string Expression)
            : base("Cannot tokenize null expression : " + Expression)
        {
        }
    }
}
