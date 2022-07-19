﻿using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Operations.Calculations;
using NExpression.Core.Expressions.Operations.Assignments.Abstractions;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignDivide : AssignReadWrite
    {
        public AssignDivide(IContext? Context)
            : base(Context,
                  new CalculationDivide(),
                  MathOperation.AssignDivide)
        {

        }
    }
}
