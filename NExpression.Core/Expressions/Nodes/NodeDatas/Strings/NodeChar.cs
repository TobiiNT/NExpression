using NExpression.Core.Expressions.Nodes.Interfaces;

namespace NExpression.Core.Expressions.Nodes.NodeDatas.Strings
{
    public class NodeChar : INode
    {
        private char Char { get; set; }
        public NodeChar(char Char)
        {
            this.Char = Char;
        }

        public object? Evaluate()
        {
            return Char;
        }
        public void Traverse(ref Stack<INode> Nodes)
        {
            Nodes.Push(this);
        }
        public override string ToString() => Char.ToString();
    }
}
