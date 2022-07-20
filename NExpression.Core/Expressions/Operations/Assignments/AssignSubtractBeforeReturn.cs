using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Operations.Calculations;
using NExpression.Core.Expressions.Operations.Abstractions;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignSubtractBeforeReturn : ContextReadWrite
    {
        public AssignSubtractBeforeReturn(IContext? Context)
            : base(Context,
                  new CalculationSubtract(),
                  MathOperation.AssignSubtractBeforeReturn)
        {

        }
    }
}
