using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Operations.Bitwises;
using NExpression.Core.Expressions.Operations.Assignments.Abstractions;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignBitwiseAND : AssignReadWrite
    {
        public AssignBitwiseAND(IContext? Context)
            : base(Context,
                  new BitwiseAND(),
                  MathOperation.AssignBitwiseAND)
        {

        }
    }
}
