namespace NExpression.Core.Exceptions
{
    public class NullContextException : Exception
    {
        public NullContextException(Exception? InnerException = null)
            : base($"No context assigned", InnerException)
        {
        }
    }
}
