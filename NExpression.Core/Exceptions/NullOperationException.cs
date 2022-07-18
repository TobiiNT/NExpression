namespace NExpression.Core.Exceptions
{
    public class NullOperationException : Exception
    {
        public NullOperationException(string ContextName, string FunctionName)
            : base($"Context '{ContextName}' does not contains a function called '{FunctionName}'")
        {
        }
    }


}
