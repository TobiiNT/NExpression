using NExpression.Core.Expressions.Nodes.Interfaces;
using System.Globalization;

namespace NExpression.Core.Expressions.Nodes.NodeDatas.Numbers
{
    public class NodeDouble : INode
    {
        private string? NumberString { get; }
        private object? Value { get; set; }
        public NodeDouble(string NumberString)
        {
            this.NumberString = NumberString;
        }
        public NodeDouble(double Value)
        {
            this.Value = Value;
            this.NumberString = Value.ToString();
        }

        public object? Evaluate()
        {
            if (Value == null)
            {
                if (double.TryParse(NumberString, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double DoubleValue))
                {
                    Value = DoubleValue;
                }
                else throw new OverflowException($"Casting {NumberString} to decimal result overflow");
            }
            return Value;
        }
        public void Traverse(ref Stack<INode> Nodes)
        {
            Nodes.Push(this);
        }
        public override string ToString() => NumberString ?? "null";
    }
}
