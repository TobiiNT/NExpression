using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Operations.Bitwises;
using NExpression.Core.Expressions.Operations.Abstractions;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignBitwiseAND : ContextReadWrite
    {
        public AssignBitwiseAND(IContext? Context)
            : base(Context,
                  new BitwiseAND(),
                  MathOperation.AssignBitwiseAND)
        {

        }
    }
}
