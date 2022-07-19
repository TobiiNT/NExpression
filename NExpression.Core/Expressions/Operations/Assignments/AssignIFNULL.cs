using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Operations.Logicals;
using NExpression.Core.Expressions.Operations.Assignments.Abstractions;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignIFNULL : AssignReadWrite
    {
        public AssignIFNULL(IContext? Context)
            : base(Context,
                  new LogicalIFNULL(),
                  MathOperation.AssignIFNULL)
        {

        }
    }
}
