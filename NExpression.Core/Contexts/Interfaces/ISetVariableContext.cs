namespace NExpression.Core.Contexts.Interfaces
{
    public interface ISetVariableContext : IContext
    {
        void DeclareVariable(string? Name, Type? Type);
        void AssignVariable(string? Name, object? Value);
    }
}
