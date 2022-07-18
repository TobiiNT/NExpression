namespace NExpression.Core.Expressions.Operations.Interfaces
{
    public interface IOperation
    {
        Func<object?, object?, object?, object> Execute { get; }
        object LogicExecute(MathOperation Operation, object? Arg1 = null, object? Arg2 = null, object? Args3 = null);
    }
}
