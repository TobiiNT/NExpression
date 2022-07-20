using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Operations.Abstractions;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignEqual : ContextWrite
    {
        public AssignEqual(IContext? Context) : 
            base(Context, 
                MathOperation.AssignEqual)
        {
           
        }
    }
}
