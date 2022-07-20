using NExpression.Core.Contexts;
using NExpression.Core.Expressions.Operations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NExpression.Dependencies
{
    public class CreateContext : IOperation
    {
        public object? Evaluate(params object?[] Params)
        {
            string? Name = (string?)Params[0];

            if (Name != null)
            {
                return new DynamicContext(Name);
            }
            return new DynamicContext();
        }
    }
}
