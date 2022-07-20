using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Operations.Bitwises;
using NExpression.Core.Expressions.Operations.Abstractions;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignBitwiseXOR : ContextReadWrite
    {
        public AssignBitwiseXOR(IContext? Context)
            : base(Context,
                  new BitwiseXOR(),
                  MathOperation.AssignBitwiseXOR)
        {

        }
    }
}
