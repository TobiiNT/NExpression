using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Operations.Bitwises;
using NExpression.Core.Expressions.Operations.Assignments.Abstractions;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignBitwiseOR : AssignReadWrite
    {
        public AssignBitwiseOR(IContext? Context)
            : base(Context,
                  new BitwiseOR(),
                  MathOperation.AssignBitwiseOR)
        {

        }
    }
}
