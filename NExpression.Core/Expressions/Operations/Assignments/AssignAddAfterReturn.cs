using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Operations.Calculations;
using NExpression.Core.Expressions.Operations.Assignments.Abstractions;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignAddAfterReturn : AssignReadWrite
    {
        public AssignAddAfterReturn(IContext? Context) : 
            base(Context, 
                new CalculationAdd(),
                MathOperation.AssignAddAfterReturn)
        {

        }
    }
}
