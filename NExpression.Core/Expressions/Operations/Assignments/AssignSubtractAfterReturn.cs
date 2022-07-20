﻿using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Operations.Calculations;
using NExpression.Core.Expressions.Operations.Abstractions;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignSubtractAfterReturn : ContextReadWrite
    {
        public AssignSubtractAfterReturn(IContext? Context)
            : base(Context,
                  new CalculationSubtract(),
                  MathOperation.AssignSubtractAfterReturn)
        {

        }
    }
}
