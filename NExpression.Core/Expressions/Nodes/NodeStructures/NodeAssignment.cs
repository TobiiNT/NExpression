using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Operations;
using NExpression.Core.Expressions.Operations.Interfaces;
using NExpression.Core.Helpers;

namespace NExpression.Core.Expressions.Nodes.NodeStructures
{
    public class NodeAssignment : INode
    {
        public INode? InnerNode => null;
        public IContext? Context { set; get; }

        public NodeVariable Variable { get; }
        public INode Value { get; }
        public MathOperation MathOperation { get; }

        public NodeAssignment(IContext? Context, NodeVariable Variable, INode Value, MathOperation MathOperation)
        {
            this.Context = Context;
            this.Variable = Variable;
            this.Value = Value;
            this.MathOperation = MathOperation;
        }


        public object? Evaluate()
        {
            var FinalValue = Value.Evaluate();

            var Operation = OperationHelpers.GetOperation(MathOperation, Context);

            var Result = Operation?.Evaluate(Variable.VariableName, FinalValue);

            return Result;
        }
        public void Traverse(ref Stack<INode> Nodes)
        {
            Nodes.Push(this);
            Variable.Traverse(ref Nodes);
            Value.Traverse(ref Nodes);
        }
    }
}
