using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Operations.Calculations;
using NExpression.Core.Expressions.Operations.Assignments.Abstractions;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignMultiply : AssignReadWrite
    {
        public AssignMultiply(IContext? Context)
            : base(Context,
                  new CalculationMultiply(),
                  MathOperation.AssignMultiply)
        {

        }
    }
}
