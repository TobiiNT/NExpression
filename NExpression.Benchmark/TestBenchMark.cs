using BenchmarkDotNet.Attributes;
using NExpression.Core.Contexts;
using NExpression.Core.Helpers;
using System.Data;
using System.Text;

namespace NExpression.BenchMark
{
    [MemoryDiagnoser]
    public class TestBenchmark
    {
        private int NumberOfItems = 1000;
        private string TestExpression(int i) => $"(({i} + 300) / (300 * (400 % 3)) >= (300 / 0.5))";
        //[Benchmark]
        public Dictionary<string, object?> NExpressionCreateAndEvaluateTest()
        {
            var Context = new DynamicContext();
            ExpressionHelpers.Parse($"a = 0", Context).Evaluate();
            ExpressionHelpers.Parse($"b = 1", Context).Evaluate();
            ExpressionHelpers.Parse($"c = 1", Context).Evaluate();

            Dictionary<string, object?> Values = new Dictionary<string, object?>();
            for (int i = 0; i < NumberOfItems; i++)
            {
                ExpressionHelpers.Parse($"a = b", Context).Evaluate();
                ExpressionHelpers.Parse($"b = c", Context).Evaluate();
                ExpressionHelpers.Parse($"c = a + b", Context).Evaluate();
                ExpressionHelpers.Parse($"c{i} = c", Context).Evaluate();
                object? Value = ExpressionHelpers.Parse($"c{i}", Context).Evaluate();
                Values.Add($"c{i}", Value);
            }
            return Values;
        }

        //[Benchmark]
        public Dictionary<string, object?> BuildInTest()
        {
            var a = 0;
            var b = 1;
            var c = 1;
            Dictionary<string, object?> Values = new Dictionary<string, object?>();
            for (int i = 0; i < NumberOfItems; i++)
            {
                a = b;
                b = c;
                c = a + b;
                object? d = c;
                Values.Add($"c{i}", d);
            }
            return Values;
        }

        [Benchmark(Description = "SB with 5 characters (fixed)")]
        public void StringBuilder5CharFixed()
        {
            for (int i = 0; i < NumberOfItems; i++)
            {
                StringBuilder A = new StringBuilder(5);
                for (int j = 0; j < 5; j++)
                {
                    A.Append('a');
                }
                A.ToString();
            }
        }
        [Benchmark(Description = "SB with 10 characters (fixed)")]
        public void StringBuilder10CharFixed()
        {
            for (int i = 0; i < NumberOfItems; i++)
            {
                StringBuilder A = new StringBuilder(10);
                for (int j = 0; j < 10; j++)
                {
                    A.Append('a');
                }
                A.ToString();
            }
        }
        [Benchmark(Description = "SB with 20 characters (fixed)")]
        public void StringBuilder20CharFixed()
        {
            for (int i = 0; i < NumberOfItems; i++)
            {
                StringBuilder A = new StringBuilder(20);
                for (int j = 0; j < 20; j++)
                {
                    A.Append('a');
                }
                A.ToString();
            }
        }


        [Benchmark(Description = "SB with 5 characters")]
        public void StringBuilder5Char()
        {
            for (int i = 0; i < NumberOfItems; i++)
            {
                StringBuilder A = new StringBuilder();
                for (int j = 0; j < 5; j++)
                {
                    A.Append('a');
                }
                A.ToString();
            }
        }
        [Benchmark(Description = "SB with 10 characters")]
        public void StringBuilder10Char()
        {
            for (int i = 0; i < NumberOfItems; i++)
            {
                StringBuilder A = new StringBuilder();
                for (int j = 0; j < 10; j++)
                {
                    A.Append('a');
                }
                A.ToString();
            }
        }
        [Benchmark(Description = "SB with 20 characters")]
        public void StringBuilder20Char()
        {
            for (int i = 0; i < NumberOfItems; i++)
            {
                StringBuilder A = new StringBuilder();
                for (int j = 0; j < 20; j++)
                {
                    A.Append('a');
                }
                A.ToString();
            }
        }

        [Benchmark(Description = "String with 5 characters")]
        public void String5Char()
        {
            for (int i = 0; i < NumberOfItems; i++)
            {
                string A = "";
                for (int j = 0; j < 5; j++)
                {
                    A += 'a';
                }
                A.ToString();
            }
        }
        [Benchmark(Description = "String with 10 characters")]
        public void String10Char()
        {
            for (int i = 0; i < NumberOfItems; i++)
            {
                string A = "";
                for (int j = 0; j < 10; j++)
                {
                    A += 'a';
                }
                A.ToString();
            }
        }
        [Benchmark(Description = "String with 20 characters")]
        public void String20Char()
        {
            for (int i = 0; i < NumberOfItems; i++)
            {
                string A = "";
                for (int j = 0; j < 20; j++)
                {
                    A += 'a';
                }
                A.ToString();
            }
        }
    }
}
