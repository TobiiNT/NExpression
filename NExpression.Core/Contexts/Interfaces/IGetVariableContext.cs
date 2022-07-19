namespace NExpression.Core.Contexts.Interfaces
{
    public interface IGetVariableContext : IContext
    {
        bool ContainVariable(string PropertyName);
        bool ResolveVariable(string? PropertyName, out object? Value);
    }
}
