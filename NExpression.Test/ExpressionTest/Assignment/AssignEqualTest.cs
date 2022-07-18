using NExpression.Core.Contexts;
using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Helpers;

namespace NExpression.Test.ExpressionTest.Assignment
{
    [TestClass]
    public class AssignEqualTest
    {
        private IContext Context = new DynamicContext();
        private void CleanUp() => Context = new DynamicContext();

        [TestMethod]
        public void AssignAndRead()
        {
            CleanUp();

            object? Value = ExpressionHelpers.Parse("var a = 3", Context).Evaluate(Context);

            Assert.AreEqual(Value, 3);

            Value = ExpressionHelpers.Parse("a = 4", Context).Evaluate(Context);

            Assert.AreEqual(Value, 4);

            Value = ExpressionHelpers.Parse("var b = 2", Context).Evaluate(Context);

            Assert.AreEqual(Value, 2);

            Assert.AreEqual(ExpressionHelpers.Parse("a", Context).Evaluate(Context), 4);

            Assert.AreEqual(ExpressionHelpers.Parse("b", Context).Evaluate(Context), 2);

            Value = ExpressionHelpers.Parse("var c = a * b", Context).Evaluate(Context);

            Assert.AreEqual(Value, 8);

            Assert.AreEqual(ExpressionHelpers.Parse("c", Context).Evaluate(Context), 8);

            CleanUp();

            Value = ExpressionHelpers.Parse("var a = null", Context).Evaluate(Context);

            Assert.AreEqual(Value, null);

            Value = ExpressionHelpers.Parse("a = 4", Context).Evaluate(Context);

            Assert.AreEqual(Value, 4);

            Value = ExpressionHelpers.Parse("var b = null", Context).Evaluate(Context);

            Assert.AreEqual(Value, null);

            Assert.AreEqual(ExpressionHelpers.Parse("a", Context).Evaluate(Context), 4);

            Assert.AreEqual(ExpressionHelpers.Parse("b", Context).Evaluate(Context), null);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetValueFromNoDeclaredVariable()
        {
            CleanUp();

            ExpressionHelpers.Parse("d", Context).Evaluate(Context);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SetValueToNoDeclaredVariable()
        {
            CleanUp();

            ExpressionHelpers.Parse("c = 3", Context).Evaluate(Context);
        }
    }
}
