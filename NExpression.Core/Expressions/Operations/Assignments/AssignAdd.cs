using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Operations.Abstractions;
using NExpression.Core.Expressions.Operations.Calculations;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignAdd : ContextReadWrite
    {
        public AssignAdd(IContext? Context) : 
            base(Context, 
                new CalculationAdd(),
                MathOperation.Add)
        {
            
        }
    }
}
