using NExpression.Core.Expressions.Operations;
using NExpression.Core.Expressions.Operations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NExpression.Dependencies.Lists
{
    public class CreateList : IOperation
    {
        public object? Evaluate(params object?[] Params)
        {
            int? Capacity = (int?)Params[0];

            if (Capacity != null)
            {
                return new List<object>((int)Capacity);
            }
            return new List<object>();
        }
    }
}
