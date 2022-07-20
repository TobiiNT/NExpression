using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Operations.Calculations;
using NExpression.Core.Expressions.Operations.Abstractions;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignModulus : ContextReadWrite
    {
        public AssignModulus(IContext? Context)
            : base(Context,
                  new CalculationModulus(),
                  MathOperation.AssignModulus)
        {

        }
    }
}
