using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Helpers;

namespace NExpression.Test.ExpressionTest
{
    [TestCategory("Expression")]
    [TestClass]
    public class FunctionTest
    {
        private class MyFunctionContext : IFunctionContext
        {
            public string Name { get; } = "Test";
            public object? CallFunction(string name, object?[] Arguments)
            {
                if (name == "rectArea")
                {
                    return (int?)Arguments[0] * (int?)Arguments[1];
                }

                if (name == "rectPerimeter")
                {
                    return ((int?)Arguments[0] + (int?)Arguments[1]) * 2;
                }

                throw new InvalidDataException($"Unknown function: '{name}'");
            }
        }

        [TestMethod]
        public void FunctionsTest()
        {
            var ctx = new MyFunctionContext();
            Assert.AreEqual(ExpressionHelpers.Parse("rectArea(10,20)").Evaluate(ctx), 200);
            Assert.AreEqual(ExpressionHelpers.Parse("rectPerimeter(10,20)").Evaluate(ctx), 60);
        }
    }
}
