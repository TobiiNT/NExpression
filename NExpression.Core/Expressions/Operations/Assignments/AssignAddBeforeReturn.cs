﻿using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Operations.Calculations;
using NExpression.Core.Expressions.Operations.Abstractions;

namespace NExpression.Core.Expressions.Operations.Assignments
{
    internal class AssignAddBeforeReturn : ContextReadWrite
    {
        public AssignAddBeforeReturn(IContext? Context) 
            : base(Context, 
                  new CalculationAdd(), 
                  MathOperation.AssignAddBeforeReturn)
        {

        }
    }
}

   