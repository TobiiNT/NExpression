namespace NExpression.Core.Expressions.Nodes.Interfaces
{
    public interface INestedNode
    {
        public INode? ChildrenNode { set; get; }
    }
}
