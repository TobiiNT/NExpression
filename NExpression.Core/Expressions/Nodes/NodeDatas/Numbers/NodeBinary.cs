using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;

namespace NExpression.Core.Expressions.Nodes.NodeDatas.Numbers
{
    public class NodeBinary : INode
    {
        public INode? InnerNode => null;
        public IContext? Context { get => null; set { } }

        private string BinaryString { get; set; }
        private int? Value { get; set; }
        public NodeBinary(string BinaryString)
        {
            this.BinaryString = BinaryString;
        }
        public NodeBinary(int Value)
        {
            this.Value = Value;
            this.BinaryString = Value.ToString();
        }

        public object? Evaluate()
        {
            if (Value == null)
                Value = Convert.ToInt32(BinaryString, 2);

            return Value;
        }
        public void Traverse(ref Stack<INode> Nodes)
        {
            Nodes.Push(this);
        }
        public override string ToString() => $"0b{BinaryString}";
    }
}
