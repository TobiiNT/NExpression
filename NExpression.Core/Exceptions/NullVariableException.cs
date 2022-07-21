using NExpression.Core.Contexts.Interfaces;

namespace NExpression.Core.Exceptions
{
    public class NullVariableException : Exception
    {
        public NullVariableException(IContext Context, string? VariableName, Exception? InnerException = null)
            : base($"The name '{VariableName}' does not exist in the current context '{Context.Name}'", InnerException)
        {
        }
    }
}
