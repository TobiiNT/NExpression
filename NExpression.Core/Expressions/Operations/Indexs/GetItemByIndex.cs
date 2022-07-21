using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Operations.Interfaces;

namespace NExpression.Core.Expressions.Operations.Indexs
{
    internal class GetItemByIndex : IOperation
    {
        public object? Evaluate(params object?[] Params)
        {
            MathOperation Operation = MathOperation.GetItemByIndex;
            object? Array = Params[0];
            object? Index = Params[1];

            if (Array == null)
            {
                throw new ArgumentNullException("An array cannot be null", new ExpressionEvaluationException(Operation, Array, Index));
            }
            if (Index == null)
            {
                throw new ArgumentNullException("An index cannot be null", new ExpressionEvaluationException(Operation, Array, Index));
            }
            if (Array is not List<object?> ListArray)
            {
                throw new InvalidOperationException("Cannot access non-array item by index", new ExpressionEvaluationException(Operation, Array, Index));
            }
            if (Index is not int IndexArray)
            {
                throw new InvalidOperationException("Index was out of range. Must be non-negative and less than the size of the collection.", new ExpressionEvaluationException(Operation, Array, Index));
            }
            if (ListArray.Count <= IndexArray)
            {
                throw new IndexOutOfRangeException("Index was out of range. Must be non-negative and less than the size of the collection.", new ExpressionEvaluationException(Operation, Array, Index));
            }

            return ListArray[IndexArray];
        }
    }
}
