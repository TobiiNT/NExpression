using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Operations.Bitwises;
using NExpression.Core.Expressions.Operations.Abstractions;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignBitwiseShiftRight : ContextReadWrite
    {
        public AssignBitwiseShiftRight(IContext? Context)
            : base(Context,
                  new BitwiseShiftRight(),
                  MathOperation.AssignBitwiseShiftRight)
        {

        }
    }
}
