using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Operations.Calculations;
using NExpression.Core.Expressions.Operations.Abstractions;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignDivide : ContextReadWrite
    {
        public AssignDivide(IContext? Context)
            : base(Context,
                  new CalculationDivide(),
                  MathOperation.AssignDivide)
        {

        }
    }
}
