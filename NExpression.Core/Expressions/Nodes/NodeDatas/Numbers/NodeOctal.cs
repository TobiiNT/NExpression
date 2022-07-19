using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;

namespace NExpression.Core.Expressions.Nodes.NodeDatas.Numbers
{
    public class NodeOctal : INode
    {
        private string NumberString { get; }
        private int? Value { get; set; }
        public NodeOctal(string NumberString)
        {
            this.NumberString = NumberString;
        }
        public NodeOctal(int Value)
        {
            this.Value = Value;
            this.NumberString = Value.ToString();
        }

        public object? Evaluate(IContext? ReadContext = null)
        {
            if (Value == null)
                Value = Convert.ToInt32(NumberString, 8);

            return Value;
        }
        public void Traverse(ref Stack<INode> Nodes)
        {
            Nodes.Push(this);
        }
        public override string ToString() => NumberString;
    }
}
