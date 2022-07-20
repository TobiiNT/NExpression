namespace NExpression.Core.Contexts.Interfaces
{
    public interface IContext
    {
        public IContext? InnerContext { get; set; }
        public string Name { get; }
    }
}
