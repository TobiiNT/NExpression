using NExpression.Core.Exceptions;
using NExpression.Core.Helpers;

namespace NExpression.Test.ExpressionTest
{
    [TestClass]
    public class LogicalTest
    {
        [TestMethod]
        public void LogicalAndTest()
        {
            Assert.AreEqual(ExpressionHelpers.Parse("true && true").Evaluate(), true && true);

            Assert.AreEqual(ExpressionHelpers.Parse("true && false").Evaluate(), true && false);

            Assert.AreEqual(ExpressionHelpers.Parse("false && false").Evaluate(), false && false);

            Assert.AreEqual(ExpressionHelpers.Parse("false && false && true").Evaluate(), false && false && true);

            Assert.AreEqual(ExpressionHelpers.Parse("true && true && true").Evaluate(), true && true && true);

            Assert.ThrowsException<InvalidMathOperatorException>(() => ExpressionHelpers.Parse("2 && 3").Evaluate(null));
            
            Assert.ThrowsException<InvalidMathOperatorException>(() => ExpressionHelpers.Parse("1 && 0").Evaluate(null));
        }

        [TestMethod]
        public void LogicalOrTest()
        {
            Assert.AreEqual(ExpressionHelpers.Parse("true || true").Evaluate(), true || true);

            Assert.AreEqual(ExpressionHelpers.Parse("true || false").Evaluate(), true || false);

            Assert.AreEqual(ExpressionHelpers.Parse("false || false").Evaluate(), false || false);

            Assert.AreEqual(ExpressionHelpers.Parse("false || false || true").Evaluate(), false || false || true);

            Assert.AreEqual(ExpressionHelpers.Parse("true || true || true").Evaluate(), true || true || true);

            Assert.ThrowsException<InvalidMathOperatorException>(() => ExpressionHelpers.Parse("2 || 3").Evaluate(null));

            Assert.ThrowsException<InvalidMathOperatorException>(() => ExpressionHelpers.Parse("1 || 0").Evaluate(null));
        }

        [TestMethod]
        public void LogicalNotTest()
        {
            Assert.AreEqual(ExpressionHelpers.Parse("!true").Evaluate(), !true);
                            
            Assert.AreEqual(ExpressionHelpers.Parse("!false").Evaluate(), !false);
                            
            Assert.AreEqual(ExpressionHelpers.Parse("!(true && true)").Evaluate(), !(true && true));
                            
            Assert.AreEqual(ExpressionHelpers.Parse("!!false").Evaluate(), !!false);
                            
            Assert.ThrowsException<InvalidMathOperatorException>(() => ExpressionHelpers.Parse("!3").Evaluate(null));

            Assert.ThrowsException<InvalidMathOperatorException>(() => ExpressionHelpers.Parse("!1").Evaluate(null));
        }
    }
}
