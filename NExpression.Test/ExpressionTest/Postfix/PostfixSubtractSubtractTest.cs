using NExpression.Core.Contexts;
using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Helpers;

namespace NExpression.Test.ExpressionTest.Postfix
{
    [TestClass]
    public class PostfixSubtractSubtractTest
    {
        private IContext Context = new DynamicContext();
        private void CleanUp() => Context = new DynamicContext();

        [TestMethod]
        public void AddThenReturnTest()
        {
            CleanUp();

            object? Value = ExpressionHelpers.Parse("var a = 0", Context).Evaluate(Context);

            Assert.AreEqual(Value, 0);

            Value = ExpressionHelpers.Parse("--a", Context).Evaluate(Context);

            Assert.AreEqual(Value, -1);

            Assert.AreEqual(ExpressionHelpers.Parse("a", Context).Evaluate(Context), -1);

            Assert.AreEqual(ExpressionHelpers.Parse("a", Context).Evaluate(Context), Value);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddAddToConstNumber()
        {
            CleanUp();

            ExpressionHelpers.Parse("--1", Context).Evaluate(Context);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void AddAddToNullReference()
        {
            CleanUp();

            ExpressionHelpers.Parse("--b", Context).Evaluate(Context);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddAddToNullValue()
        {
            CleanUp();

            ExpressionHelpers.Parse("--null", Context).Evaluate(Context);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddAddToStringValue()
        {
            CleanUp();

            ExpressionHelpers.Parse("--\"123\"", Context).Evaluate(Context);
        }
    }
}