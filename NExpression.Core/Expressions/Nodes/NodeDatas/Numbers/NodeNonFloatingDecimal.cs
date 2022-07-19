using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;
using System.Globalization;

namespace NExpression.Core.Expressions.Nodes.NodeDatas.Numbers
{
    public class NodeNonFloatingDecimal : INode
    {
        private string? NumberString { get; }
        private object? Value { get; set; }
        public NodeNonFloatingDecimal(string NumberString)
        {
            this.NumberString = NumberString;
        }
        public NodeNonFloatingDecimal(object Value)
        {
            this.Value = Value;
            this.NumberString = Value.ToString();
        }
        public object? Evaluate() => Evaluate(null);
        public object? Evaluate(IContext? ReadContext = null)
        {
            if (Value == null)
            {
                if (int.TryParse(NumberString, NumberStyles.Integer, CultureInfo.InvariantCulture, out int IntValue))
                {
                    Value = IntValue;
                }
                else if (long.TryParse(NumberString, NumberStyles.Integer, CultureInfo.InvariantCulture, out long LongValue))
                {
                    Value = LongValue;
                }
                else throw new OverflowException($"Casting {NumberString} to decimal result overflow");
            }
            return Value;
        }
        public T? Evaluate<T>() => Evaluate<T>(null);
        public T? Evaluate<T>(IContext? ReadContext = null)
        {
            return (T?)Convert.ChangeType(Evaluate(), typeof(T?));
        }
        public void Traverse(ref Stack<INode> Nodes)
        {
            Nodes.Push(this);
        }
        public override string ToString() => NumberString ?? "null";
    }
}
