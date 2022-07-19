using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Nodes.NodeStructures
{
    public class NodeAssignment : INode
    {
        private NodeVariable Variable { set; get; }
        private INode Value { set; get; }
        private IOperation? Operation { set; get; }
        private bool IsDeclare { set; get; }
        private Type DeclareType { set; get; }
        public NodeAssignment(NodeVariable Variable, INode Value, IOperation Operation)
        {
            this.Variable = Variable;
            this.Value = Value;
            this.Operation = Operation;
        }
        public void SetDeclare<T>(bool IsDeclare)
        {
            this.IsDeclare = IsDeclare;
            this.DeclareType = typeof(T);
        }

        public object? Evaluate() => Evaluate(null);
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

            var Result = Operation?.Execute(Variable.VariableName, FinalValue, DeclareType);

            return Result;
        }
        public T? Evaluate<T>() => Evaluate<T>(null);
        public T? Evaluate<T>(IContext? ReadContext = null)
        {
            return (T?)Convert.ChangeType(Evaluate(), typeof(T?));
        }
    }
}
