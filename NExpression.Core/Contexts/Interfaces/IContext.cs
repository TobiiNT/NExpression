namespace NExpression.Core.Contexts.Interfaces
{
    public interface IContext
    {
        string Name { get; }
        void SetName (string Name);
    }
}
