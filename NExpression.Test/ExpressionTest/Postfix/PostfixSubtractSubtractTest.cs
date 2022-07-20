using NExpression.Core.Contexts;
using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Exceptions;
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

            object? Value = ExpressionHelpers.Parse("a = 0", Context).Evaluate();

            Assert.AreEqual(Value, 0);

            Value = ExpressionHelpers.Parse("--a", Context).Evaluate();

            Assert.AreEqual(Value, -1);

            Assert.AreEqual(ExpressionHelpers.Parse("a", Context).Evaluate(), -1);

            Assert.AreEqual(ExpressionHelpers.Parse("a", Context).Evaluate(), Value);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddAddToConstNumber()
        {
            CleanUp();

            ExpressionHelpers.Parse("--1", Context).Evaluate();
        }

        [TestMethod]
        [ExpectedException(typeof(NullVariableException))]
        public void AddAddToNullReference()
        {
            CleanUp();

            ExpressionHelpers.Parse("--b", Context).Evaluate();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddAddToNullValue()
        {
            CleanUp();

            ExpressionHelpers.Parse("--null", Context).Evaluate();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddAddToStringValue()
        {
            CleanUp();

            ExpressionHelpers.Parse("--\"123\"", Context).Evaluate();
        }
    }
}