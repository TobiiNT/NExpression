using NExpression.Core.Expressions.Operations.Interfaces;

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
