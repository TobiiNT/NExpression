namespace NExpression.Core.Contexts.Interfaces
{
    public interface IFunctionContext : IContext
    {
        object? CallFunction(string Name, object?[] Arguments);
        object? CallFunctionWithReferences(string[] References, object?[] Arguments);
    }
}
