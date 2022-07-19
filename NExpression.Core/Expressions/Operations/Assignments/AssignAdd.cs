using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Operations.Assignments.Abstractions;
using NExpression.Core.Expressions.Operations.Calculations;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignAdd : AssignReadWrite
    {
        public AssignAdd(IContext? Context) : 
            base(Context, 
                new CalculationAdd(),
                MathOperation.Add)
        {
            
        }
    }
}
