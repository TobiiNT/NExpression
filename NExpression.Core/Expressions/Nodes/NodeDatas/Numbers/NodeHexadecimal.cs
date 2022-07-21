using NExpression.Core.Expressions.Nodes.Interfaces;

namespace NExpression.Core.Expressions.Nodes.NodeDatas.Numbers
{
    public class NodeHexadecimal : INode
    {
        private string HexString { get; set; }
        private int? Value { get; set; }
        public NodeHexadecimal(string HexString)
        {
            this.HexString = HexString;
        }
        public NodeHexadecimal(int Value)
        {
            this.Value = Value;
            this.HexString = Value.ToString();
        }
        public object? Evaluate()
        {
            if (Value == null)
                Value = Convert.ToInt32(HexString, 16);

            return Value;
        }
        public void Traverse(ref Stack<INode> Nodes)
        {
            Nodes.Push(this);
        }
        public override string ToString() =>  $"0x{HexString}";
    }
}
