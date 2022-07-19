using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Operations;
using NExpression.Core.Expressions.Operations.Interfaces;
using NExpression.Core.Helpers;
using NExpression.Core.Extensions;

namespace NExpression.Core.Expressions.Nodes.NodeStructures
{
    public class NodeAssignment : INode
    {
        public NodeVariable Variable { get; }
        public INode Value { get; }
        public MathOperation MathOperation { get; }

        public IOperation? Operation { private set; get; }

        private bool IsDeclare { set; get; }
        private Type DeclareType { set; get; }

        public NodeAssignment(NodeVariable Variable, INode Value, MathOperation MathOperation)
        {
            this.Variable = Variable;
            this.Value = Value;
            this.MathOperation = MathOperation;
        }
        public NodeAssignment(NodeVariable Variable, INode Value, MathOperation MathOperation, IOperation Operation)
        {
            this.Variable = Variable;
            this.Value = Value;
            this.Operation = Operation;
        }
        public void AssignContext(IContext? Context)
        {
            this.Operation = OperationHelpers.GetOperation(MathOperation, Context); ;
        }
        public void SetDeclare<T>(bool IsDeclare)
        {
            this.IsDeclare = IsDeclare;
            this.DeclareType = typeof(T);
        }

        public object? Evaluate(IContext? ReadContext = null)
        {
            object? FirstValue = null;
            try
            {
                FirstValue = Variable.Evaluate(ReadContext);
            }
            catch
            {
                if (!IsDeclare)
                    throw;
            }
            if (IsDeclare && FirstValue != null)
            {
                throw new DuplicatedNameException(ReadContext, Variable.VariableName);
            }
            var FinalValue = Value.Evaluate(ReadContext);

            var Result = Operation?.Evaluate(Variable.VariableName, FinalValue, DeclareType);

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
