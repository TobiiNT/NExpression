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

            object? Value = ExpressionHelpers.Parse("a = 3", Context).Evaluate();

            Assert.AreEqual(Value, 3);

            Value = ExpressionHelpers.Parse("a = 4", Context).Evaluate();

            Assert.AreEqual(Value, 4);

            Value = ExpressionHelpers.Parse("b = 2", Context).Evaluate();

            Assert.AreEqual(Value, 2);

            Assert.AreEqual(ExpressionHelpers.Parse("a", Context).Evaluate(), 4);

            Assert.AreEqual(ExpressionHelpers.Parse("b", Context).Evaluate(), 2);

            Value = ExpressionHelpers.Parse("c = a * b", Context).Evaluate();

            Assert.AreEqual(Value, 8);

            Assert.AreEqual(ExpressionHelpers.Parse("c", Context).Evaluate(), 8);

            CleanUp();

            Value = ExpressionHelpers.Parse("a = null", Context).Evaluate();

            Assert.AreEqual(Value, null);

            Value = ExpressionHelpers.Parse("a = 4", Context).Evaluate();

            Assert.AreEqual(Value, 4);

            Value = ExpressionHelpers.Parse("b = null", Context).Evaluate();

            Assert.AreEqual(Value, null);

            Assert.AreEqual(ExpressionHelpers.Parse("a", Context).Evaluate(), 4);

            Assert.AreEqual(ExpressionHelpers.Parse("b", Context).Evaluate(), null);
        }

        [TestMethod]
        public void GetValueFromNoDeclaredVariable()
        {
            CleanUp();

            Assert.AreEqual(ExpressionHelpers.Parse("d", Context).Evaluate(), null);
        }

        [TestMethod]
        public void SetValueToNoDeclaredVariable()
        {
            CleanUp();

            ExpressionHelpers.Parse("c = 3", Context).Evaluate();

            Assert.AreEqual(ExpressionHelpers.Parse("c", Context).Evaluate(), 3);
        }
    }
}
