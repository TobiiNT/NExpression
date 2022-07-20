using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Operations.Logicals;
using NExpression.Core.Expressions.Operations.Abstractions;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignIFNULL : ContextReadWrite
    {
        public AssignIFNULL(IContext? Context)
            : base(Context,
                  new LogicalIFNULL(),
                  MathOperation.AssignIFNULL)
        {

        }
    }
}
