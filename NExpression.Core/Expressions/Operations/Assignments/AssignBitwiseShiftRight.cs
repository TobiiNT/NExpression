using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Operations.Bitwises;
using NExpression.Core.Expressions.Operations.Assignments.Abstractions;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignBitwiseShiftRight : AssignReadWrite
    {
        public AssignBitwiseShiftRight(IContext? Context)
            : base(Context,
                  new BitwiseShiftRight(),
                  MathOperation.AssignBitwiseShiftRight)
        {

        }
    }
}
