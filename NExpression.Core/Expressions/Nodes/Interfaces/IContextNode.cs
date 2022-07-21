using NExpression.Core.Contexts.Interfaces;

namespace NExpression.Core.Expressions.Nodes.Interfaces
{
    public interface IContextNode
    {
        IContext? Context { set; get; }
        void SetContext(IContext? Context);
    }
}
