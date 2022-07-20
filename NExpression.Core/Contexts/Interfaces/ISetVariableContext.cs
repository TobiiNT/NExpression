namespace NExpression.Core.Contexts.Interfaces
{
    public interface ISetVariableContext : IContext
    {
        void AssignVariable(string? Name, object? Value);
    }
}
