namespace NExpression.Core.Expressions.Operations.Interfaces
{
    public interface IOperation
    {
        object? Evaluate(params object?[] Parameters);
    }
}
