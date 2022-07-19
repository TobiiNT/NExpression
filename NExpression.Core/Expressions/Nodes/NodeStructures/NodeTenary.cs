using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Operations;
using NExpression.Core.Expressions.Operations.Interfaces;
using NExpression.Core.Helpers;

namespace NExpression.Core.Expressions.Nodes.NodeStructures
{
    public class NodeTenary : INode
    {
        public INode? ConditionNode { set; get; }
        public INode LeftNode { set; get; }
        public INode RightNode { set; get; }
        public IOperation? TenaryOperation { set; get; }
       
        public NodeTenary(INode LeftNode, INode RightNode)
        {
            this.LeftNode = LeftNode;
            this.RightNode = RightNode;
            this.TenaryOperation = OperationHelpers.GetOperation(MathOperation.ConditionTenary);
        }

        public NodeTenary(INode ConditionNode, INode LeftNode, INode RightNode)
        {
            this.ConditionNode = ConditionNode;
            this.LeftNode = LeftNode;
            this.RightNode = RightNode;
            this.TenaryOperation = OperationHelpers.GetOperation(MathOperation.ConditionTenary);
        }
        public void SetCondition(INode ConditionNode) => this.ConditionNode = ConditionNode;

        public object? Evaluate() => Evaluate(null);
        public object? Evaluate(IContext? ReadContext = null)
        {
            var ConditionValue = ConditionNode?.Evaluate(ReadContext);
            var LeftValue = LeftNode.Evaluate(ReadContext);
            var RightValue = RightNode.Evaluate(ReadContext);
            var Result = TenaryOperation?.Execute(ConditionValue, LeftValue, RightValue);

            return Result;
        }
        public T? Evaluate<T>() => Evaluate<T>(null);
        public T? Evaluate<T>(IContext? ReadContext = null)
        {
            return (T?)Convert.ChangeType(Evaluate(), typeof(T?));
        }
        public void Traverse(ref Stack<INode> Nodes)
        {
            Nodes.Push(this);
            ConditionNode?.Traverse(ref Nodes);
            LeftNode.Traverse(ref Nodes);
            RightNode.Traverse(ref Nodes);
        }
    }
}
