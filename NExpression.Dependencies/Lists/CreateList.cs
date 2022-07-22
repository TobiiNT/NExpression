using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Dependencies.Lists
{
    public class CreateList : IOperation
    {
        public object? Evaluate(params object?[] Params)
        {
            int? Capacity = Params.Length >= 1 ? (int?)Params[0] : null;

            if (Capacity != null)
            {
                return new List<object>((int)Capacity);
            }
            return new List<object>();
        }
    }
}
