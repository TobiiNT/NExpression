using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Operations.Calculations;
using NExpression.Core.Expressions.Operations.Assignments.Abstractions;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignSubtract : AssignReadWrite
    {
        public AssignSubtract(IContext? Context)
            : base(Context,
                  new CalculationSubtract(),
                  MathOperation.AssignSubtract)
        {

        }
    }
}
