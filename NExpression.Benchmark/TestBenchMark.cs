using BenchmarkDotNet.Attributes;
using NExpression.Core.Helpers;
using System.Data;

namespace NExpression.BenchMark
{
    [MemoryDiagnoser]
    public class TestBenchmark
    {
        private int NumberOfItems = 10000;
        private string TestExpression(int i) => $"(({i} + 300) / (300 * (400 % 3)) >= (300 / 0.5))";
        [Benchmark]
        public List<object?> NExpressionCreateAndEvaluateTest()
        {
            List<object?> Values = new List<object?>();
            for (int i = 0; i < NumberOfItems; i++)
            {
                object? Value = ExpressionHelpers.Parse(TestExpression(i)).Evaluate();
                Values.Add(Value);
            }
            return Values;
        }

        [Benchmark]
        public List<object?> NExpressionEvaluateOnlyTest()
        {
            List<object?> Values = new List<object?>();

            var Expression = ExpressionHelpers.Parse(TestExpression(NumberOfItems));
            for (int i = 0; i < NumberOfItems; i++)
            {
                object? Value = Expression.Evaluate();
                Values.Add(Value);
            }
            return Values;
        }

        [Benchmark]
        public List<object?> DataTableComputeTest()
        {
            var DataTable = new DataTable();
            List<object?> Values = new List<object?>();
            for (int i = 0; i < NumberOfItems; i++)
            {
                object? Value = DataTable.Compute(TestExpression(i), null);
                Values.Add(Value);
            }
            return Values;
        }

        [Benchmark]
        public List<object?> BuildInTest()
        {
            List<object?> Values = new List<object?>();
            for (int i = 0; i < NumberOfItems; i++)
            {
                object? Value = ((i + 300) / (300 * (400 % 3)) >= (300 / 0.5));
                Values.Add(Value);
            }
            return Values;
        }
    }
}
