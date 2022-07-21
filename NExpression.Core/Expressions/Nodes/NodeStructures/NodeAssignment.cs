using NExpression.Core.Contexts;
using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Operations;
using NExpression.Core.Helpers;

namespace NExpression.Core.Expressions.Nodes.NodeStructures
{
    public class NodeAssignment : INode
    {
        public NodeVariable Variable { get; }
        public INode Value { get; }
        public MathOperation MathOperation { get; }

        public NodeAssignment(NodeVariable Variable, INode Value, MathOperation MathOperation)
        {
            this.Variable = Variable;
            this.Value = Value;
            this.MathOperation = MathOperation;
        }


        public object? Evaluate()
        {
            var FinalValue = Value.Evaluate();

            var Operation = OperationHelpers.GetOperation(MathOperation, Variable.Context);

            var Result = Operation?.Evaluate(Variable.VariableName, FinalValue);

            if (Result is IContext Context)
            {
                Context.SetName($"{Variable.Context}.{Variable.VariableName}");
            }

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
