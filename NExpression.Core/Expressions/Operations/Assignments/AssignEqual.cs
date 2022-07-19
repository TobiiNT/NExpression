using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Operations.Assignments.Abstractions;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignEqual : AssignWrite
    {
        public AssignEqual(IContext? Context) : 
            base(Context, 
                MathOperation.AssignEqual)
        {
           
        }
    }
}
