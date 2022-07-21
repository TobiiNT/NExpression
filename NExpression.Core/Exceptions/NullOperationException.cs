using NExpression.Core.Contexts.Interfaces;

namespace NExpression.Core.Exceptions
{
    public class NullOperationException : Exception
    {
        public NullOperationException(IContext Context, string FunctionName)
            : base($"Context '{Context.Name}' does not contains a function called '{FunctionName}'")
        {
        }
    }


}
