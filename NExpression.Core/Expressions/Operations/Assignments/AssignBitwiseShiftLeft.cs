using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Operations.Bitwises;
using NExpression.Core.Expressions.Operations.Abstractions;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignBitwiseShiftLeft : ContextReadWrite
    {
        public AssignBitwiseShiftLeft(IContext? Context)
            : base(Context,
                  new BitwiseShiftLeft(),
                  MathOperation.AssignBitwiseShiftLeft)
        {

        }
    }
}
