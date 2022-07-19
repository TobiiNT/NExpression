using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Operations;
using NExpression.Core.Expressions.Operations.Interfaces;
using NExpression.Core.Helpers;

namespace NExpression.Core.Expressions.Nodes.NodeStructures
{
    public class NodeTernaryTree : INode
    {
        public INode? ConditionNode { set; get; }
        public INode LeftNode { set; get; }
        public INode RightNode { set; get; }
        public IOperation? TernaryOperation { set; get; }
       
        public NodeTernaryTree(INode LeftNode, INode RightNode)
        {
            this.LeftNode = LeftNode;
            this.RightNode = RightNode;
            this.TernaryOperation = OperationHelpers.GetOperation(MathOperation.ConditionTernary);
        }

        public NodeTernaryTree(INode ConditionNode, INode LeftNode, INode RightNode)
        {
            this.ConditionNode = ConditionNode;
            this.LeftNode = LeftNode;
            this.RightNode = RightNode;
            this.TernaryOperation = OperationHelpers.GetOperation(MathOperation.ConditionTernary);
        }
        public void SetCondition(INode ConditionNode) => this.ConditionNode = ConditionNode;

        public object? Evaluate(IContext? ReadContext = null)
        {
            var ConditionValue = ConditionNode?.Evaluate(ReadContext);
            var LeftValue = LeftNode.Evaluate(ReadContext);
            var RightValue = RightNode.Evaluate(ReadContext);
            var Result = TernaryOperation?.Evaluate(ConditionValue, LeftValue, RightValue);

            return Result;
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
