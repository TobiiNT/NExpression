namespace NExpression.Core.Expressions.Nodes.Interfaces
{
    public interface INode
    {
        public object? Evaluate();

        public void Traverse(ref Stack<INode> Nodes);
    }
}
