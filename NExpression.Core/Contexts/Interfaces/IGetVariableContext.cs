namespace NExpression.Core.Contexts.Interfaces
{
    public interface IGetVariableContext : IContext
    {
        bool ResolveVariable(string? Name, out object? Value);
        bool ResolveVariable<T>(string? PropertyName, out T? Value);
    }
}
