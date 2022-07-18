using NExpression.Core.Contexts.Interfaces;

namespace NExpression.Core.Exceptions
{
    public class InvalidOperationContextException : Exception
    {
        public InvalidOperationContextException(IContext? Context, string? Operation, Exception? InnerException = null)
            : base($"The context {Context?.Name} does not have {Operation} operation", InnerException)
        {
        }
    }
}
