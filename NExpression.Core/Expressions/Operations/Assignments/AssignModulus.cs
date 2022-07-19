using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Operations.Calculations;
using NExpression.Core.Expressions.Operations.Assignments.Abstractions;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignModulus : AssignReadWrite
    {
        public AssignModulus(IContext? Context)
            : base(Context,
                  new CalculationModulus(),
                  MathOperation.AssignModulus)
        {

        }
    }
}
