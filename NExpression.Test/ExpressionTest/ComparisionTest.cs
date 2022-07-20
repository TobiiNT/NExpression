using NExpression.Core.Exceptions;
using NExpression.Core.Helpers;

namespace NExpression.Test.ExpressionTest
{
    [TestClass]
    public class ComparisionTest
    {
        [TestMethod]
        public void GreaterThanTest()
        {
            Assert.AreEqual(ExpressionHelpers.Parse("1 > 0").Evaluate(), 1 > 0);

            Assert.AreEqual(ExpressionHelpers.Parse("9 > 10").Evaluate(), 9 > 10);

            Assert.AreEqual(ExpressionHelpers.Parse("29 >= 30").Evaluate(), 29 >= 30);

            Assert.AreEqual(ExpressionHelpers.Parse("30 >= 30").Evaluate(), 30 >= 30);

            Assert.AreEqual(ExpressionHelpers.Parse("31 >= 30").Evaluate(), 31 >= 30);

            Assert.ThrowsException<InvalidMathOperatorException>(() => ExpressionHelpers.Parse("true > false").Evaluate());

            Assert.ThrowsException<InvalidMathOperatorException>(() => ExpressionHelpers.Parse("false >= false").Evaluate());

            Assert.ThrowsException<InvalidMathOperatorException>(() => ExpressionHelpers.Parse("1 >= false").Evaluate());

            Assert.ThrowsException<InvalidMathOperatorException>(() => ExpressionHelpers.Parse("\"10\" >= \"5\"").Evaluate());
        }

        [TestMethod]
        public void LessThanTest()
        {
            Assert.AreEqual(ExpressionHelpers.Parse("1 < 0").Evaluate(), 1 < 0);

            Assert.AreEqual(ExpressionHelpers.Parse("9 < 10").Evaluate(), 9 < 10);

            Assert.AreEqual(ExpressionHelpers.Parse("29 <= 30").Evaluate(), 29 <= 30);

            Assert.AreEqual(ExpressionHelpers.Parse("30 <= 30").Evaluate(), 30 <= 30);

            Assert.AreEqual(ExpressionHelpers.Parse("31 <= 30").Evaluate(), 31 <= 30);

            Assert.ThrowsException<InvalidMathOperatorException>(() => ExpressionHelpers.Parse("true < false").Evaluate());

            Assert.ThrowsException<InvalidMathOperatorException>(() => ExpressionHelpers.Parse("false <= false").Evaluate());

            Assert.ThrowsException<InvalidMathOperatorException>(() => ExpressionHelpers.Parse("1 <= false").Evaluate());

            Assert.ThrowsException<InvalidMathOperatorException>(() => ExpressionHelpers.Parse("\"10\" <= \"5\"").Evaluate());
        }

        [TestMethod]
        public void ValueEqualTest()
        {
            Assert.AreEqual(ExpressionHelpers.Parse("1 == 0").Evaluate(), 1 == 0);

            Assert.AreEqual(ExpressionHelpers.Parse("9 == 10").Evaluate(), 9 == 10);

            Assert.AreEqual(ExpressionHelpers.Parse("29 == 30").Evaluate(), 29 == 30);

            Assert.AreEqual(ExpressionHelpers.Parse("30 == 30").Evaluate(), 30 == 30);

            Assert.AreEqual(ExpressionHelpers.Parse("true == true").Evaluate(), true == true);

            Assert.AreEqual(ExpressionHelpers.Parse("true == false").Evaluate(), true == false);

            Assert.AreEqual(ExpressionHelpers.Parse("1 == 1.0").Evaluate(), 1 == 1.0);

            Assert.AreEqual(ExpressionHelpers.Parse("true == 1").Evaluate(), false);

            Assert.AreEqual(ExpressionHelpers.Parse("\"test\" == \"test\"").Evaluate(), "test" == "test");

            Assert.AreEqual(ExpressionHelpers.Parse("\"testA\" == \"testB\"").Evaluate(), "testA" == "testB");
        }

        [TestMethod]
        public void ValueNotEqualTest()
        {
            Assert.AreEqual(ExpressionHelpers.Parse("1 != 0").Evaluate(), 1 != 0);

            Assert.AreEqual(ExpressionHelpers.Parse("9 != 10").Evaluate(), 9 != 10);

            Assert.AreEqual(ExpressionHelpers.Parse("29 != 30").Evaluate(), 29 != 30);

            Assert.AreEqual(ExpressionHelpers.Parse("30 != 30").Evaluate(), 30 != 30);

            Assert.AreEqual(ExpressionHelpers.Parse("true != true").Evaluate(), true != true);

            Assert.AreEqual(ExpressionHelpers.Parse("true != false").Evaluate(), true != false);

            Assert.AreEqual(ExpressionHelpers.Parse("1 != 1.0").Evaluate(), 1 != 1.0);

            Assert.AreEqual(ExpressionHelpers.Parse("true != 1").Evaluate(), true);

            Assert.AreEqual(ExpressionHelpers.Parse("\"test\" != \"test\"").Evaluate(), "test" != "test");

            Assert.AreEqual(ExpressionHelpers.Parse("\"testA\" != \"testB\"").Evaluate(), "testA" != "testB");
        }

        [TestMethod]
        public void ValueAndTypeEqualTest()
        {
            Assert.AreEqual(ExpressionHelpers.Parse("1 === 0").Evaluate(), 1 == 0);

            Assert.AreEqual(ExpressionHelpers.Parse("9 === 10").Evaluate(), 9 == 10);

            Assert.AreEqual(ExpressionHelpers.Parse("29 === 30").Evaluate(), 29 == 30);

            Assert.AreEqual(ExpressionHelpers.Parse("30 === 30").Evaluate(), 30 == 30);

            Assert.AreEqual(ExpressionHelpers.Parse("true === true").Evaluate(), true == true);

            Assert.AreEqual(ExpressionHelpers.Parse("true === false").Evaluate(), true == false);

            Assert.AreEqual(ExpressionHelpers.Parse("1 === 1.0").Evaluate(), false);

            Assert.AreEqual(ExpressionHelpers.Parse("true === 1").Evaluate(), false);

            Assert.AreEqual(ExpressionHelpers.Parse("\"test\" === \"test\"").Evaluate(), "test" == "test");

            Assert.AreEqual(ExpressionHelpers.Parse("\"testA\" === \"testB\"").Evaluate(), "testA" == "testB");
        }

        [TestMethod]
        public void ValueAndTypeNotEqualTest()
        {
            Assert.AreEqual(ExpressionHelpers.Parse("1 !== 0").Evaluate(), 1 != 0);

            Assert.AreEqual(ExpressionHelpers.Parse("9 !== 10").Evaluate(), 9 != 10);

            Assert.AreEqual(ExpressionHelpers.Parse("29 !== 30").Evaluate(), 29 != 30);

            Assert.AreEqual(ExpressionHelpers.Parse("30 !== 30").Evaluate(), 30 != 30);

            Assert.AreEqual(ExpressionHelpers.Parse("true !== true").Evaluate(), true != true);

            Assert.AreEqual(ExpressionHelpers.Parse("true !== false").Evaluate(), true != false);

            Assert.AreEqual(ExpressionHelpers.Parse("1 !== 1.0").Evaluate(), true);

            Assert.AreEqual(ExpressionHelpers.Parse("true !== 1").Evaluate(), true);

            Assert.AreEqual(ExpressionHelpers.Parse("\"test\" !== \"test\"").Evaluate(), "test" != "test");

            Assert.AreEqual(ExpressionHelpers.Parse("\"testA\" !== \"testB\"").Evaluate(), "testA" != "testB");
        }
    }
}
