using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Operations.Bitwises;
using NExpression.Core.Expressions.Operations.Abstractions;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignBitwiseOR : ContextReadWrite
    {
        public AssignBitwiseOR(IContext? Context)
            : base(Context,
                  new BitwiseOR(),
                  MathOperation.AssignBitwiseOR)
        {

        }
    }
}
