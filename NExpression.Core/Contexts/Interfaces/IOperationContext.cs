using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Contexts.Interfaces
{
    public interface IOperationContext : IContext
    {
        object? CallOperation(IOperation? Operation, object?[] Arguments);
        void RegisterOperation<T>(string Name);
    }
}
