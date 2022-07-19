using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;

namespace NExpression.Core.Expressions.Nodes.NodeDatas
{
    public class NodeBoolean : INode
    {
        private bool Boolean { get; set; }
        public NodeBoolean(bool Boolean)
        {
            this.Boolean = Boolean;
        }
        public object? Evaluate() => Evaluate(null);
        public object? Evaluate(IContext? ReadContext = null)
        {
            return Boolean;
        }
        public T? Evaluate<T>() => Evaluate<T>(null);
        public T? Evaluate<T>(IContext? ReadContext = null)
        {
            return (T?)Convert.ChangeType(Evaluate(), typeof(T?));
        }
        public string Traverse()
        {
            return $"bool ({Boolean})";
        }
    }
}
