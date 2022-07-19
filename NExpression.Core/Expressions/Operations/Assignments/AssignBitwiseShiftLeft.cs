using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Operations.Bitwises;
using NExpression.Core.Expressions.Operations.Assignments.Abstractions;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignBitwiseShiftLeft : AssignReadWrite
    {
        public AssignBitwiseShiftLeft(IContext? Context)
            : base(Context,
                  new BitwiseShiftLeft(),
                  MathOperation.AssignBitwiseShiftLeft)
        {

        }
    }
}
