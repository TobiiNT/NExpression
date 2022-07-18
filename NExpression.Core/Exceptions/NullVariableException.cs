namespace NExpression.Core.Exceptions
{
    public class NullVariableException : Exception
    {
        public NullVariableException(string? VariableName, Exception? InnerException = null)
            : base($"The name '{VariableName}' does not exist in the current context", InnerException)
        {
        }
    }
}
