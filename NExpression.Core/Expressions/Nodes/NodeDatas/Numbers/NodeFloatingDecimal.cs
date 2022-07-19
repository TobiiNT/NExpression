using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;
using System.Globalization;

namespace NExpression.Core.Expressions.Nodes.NodeDatas.Numbers
{
    public class NodeFloatingDecimal : INode
    {
        private string? NumberString { get; }
        private object? Value { get; set; }
        public NodeFloatingDecimal(string NumberString)
        {
            this.NumberString = NumberString;
        }
        public NodeFloatingDecimal(object Value)
        {
            this.Value = Value;
            this.NumberString = Value.ToString();
        }

        public object? Evaluate(IContext? ReadContext = null)
        {
            if (Value == null)
            {
                if (double.TryParse(NumberString, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double DoubleValue))
                {
                    Value = DoubleValue;
                }
                else if (decimal.TryParse(NumberString, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal DecimalValue))
                {
                    Value = DecimalValue;
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
