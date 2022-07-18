using NExpression.Core.Exceptions;
using NExpression.Core.Helpers;

namespace NExpression.Test.ExpressionTest
{
    [TestClass]
    public class BitwiseTest
    {
        [TestMethod]
        public void BitwiseShiftLeftTest()
        {
            Assert.AreEqual(ExpressionHelpers.Parse("2 << 2").Evaluate(), 2 << 2);

            Assert.AreEqual(ExpressionHelpers.Parse("1024 << 9").Evaluate(), 1024 << 9);

            Assert.AreEqual(ExpressionHelpers.Parse("-2 << 2 << 2").Evaluate(), -2 << 2 << 2);

            Assert.AreEqual(ExpressionHelpers.Parse("-2 << (2 << 2)").Evaluate(), -2 << (2 << 2));

            Assert.AreEqual(ExpressionHelpers.Parse("-2 << 2").Evaluate(), -2 << 2);

            Assert.AreEqual(ExpressionHelpers.Parse("-2 << 0").Evaluate(), -2 << 0);

            Assert.ThrowsException<InvalidMathOperatorException>(ExpressionHelpers.Parse("2 << -2").Evaluate);

            Assert.ThrowsException<NullContextException>(ExpressionHelpers.Parse("LeftValue << RightValue").Evaluate);

            Assert.ThrowsException<InvalidMathOperatorException>(ExpressionHelpers.Parse("\"LeftValue\" << \"RightValue\"").Evaluate);
        }

        [TestMethod]
        public void BitwiseShiftRightTest()
        {
            Assert.AreEqual(ExpressionHelpers.Parse("2 >> 2").Evaluate(), 2 >> 2);

            Assert.AreEqual(ExpressionHelpers.Parse("1024 >> 9").Evaluate(),  1024 >> 9);

            Assert.AreEqual(ExpressionHelpers.Parse("-2 >> 2 >> 2").Evaluate(), -2 >> 2 >> 2);

            Assert.AreEqual(ExpressionHelpers.Parse("-2 >> (2 >> 2)").Evaluate(), -2 >> (2 >> 2));

            Assert.AreEqual(ExpressionHelpers.Parse("-2 >> 2").Evaluate(), -2 >> 2);
                                                                                   
            Assert.AreEqual(ExpressionHelpers.Parse("-2 >> 0").Evaluate(), -2 >> 0);
            
            Assert.ThrowsException<InvalidMathOperatorException>(ExpressionHelpers.Parse("-2 >> -2").Evaluate);
            
            Assert.ThrowsException<NullContextException>(ExpressionHelpers.Parse("LeftValue >> RightValue").Evaluate);

            Assert.ThrowsException<InvalidMathOperatorException>(ExpressionHelpers.Parse("\"LeftValue\" >> \"RightValue\"").Evaluate);
        }

        [TestMethod]
        public void BitwiseANDTest()
        {
            Assert.AreEqual(ExpressionHelpers.Parse("1 & 0").Evaluate(), 1 & 0);

            Assert.AreEqual(ExpressionHelpers.Parse("1024 & 9").Evaluate(), 1024 & 9);

            Assert.AreEqual(ExpressionHelpers.Parse("0 & 0").Evaluate(), 0 & 0);

            Assert.ThrowsException<InvalidMathOperatorException>(ExpressionHelpers.Parse("0.2 & 5").Evaluate);

            Assert.ThrowsException<InvalidMathOperatorException>(ExpressionHelpers.Parse("5 & 0.2").Evaluate);

            Assert.ThrowsException<NullContextException>(ExpressionHelpers.Parse("LeftValue & RightValue").Evaluate);

            Assert.ThrowsException<InvalidMathOperatorException>(ExpressionHelpers.Parse("\"LeftValue\" & \"RightValue\"").Evaluate);
        }

        [TestMethod]
        public void BitwiseORTest()
        {
            Assert.AreEqual(ExpressionHelpers.Parse("1 | 0").Evaluate(), 1 | 0);

            Assert.AreEqual(ExpressionHelpers.Parse("1024 | 9").Evaluate(),1024 | 9);

            Assert.AreEqual(ExpressionHelpers.Parse("0 | 0").Evaluate(), 0 | 0);

            Assert.ThrowsException<InvalidMathOperatorException>(ExpressionHelpers.Parse("0.2 | 5").Evaluate);

            Assert.ThrowsException<InvalidMathOperatorException>(ExpressionHelpers.Parse("5 | 0.2").Evaluate);

            Assert.ThrowsException<NullContextException>(ExpressionHelpers.Parse("LeftValue | RightValue").Evaluate);

            Assert.ThrowsException<InvalidMathOperatorException>(ExpressionHelpers.Parse("\"LeftValue\" | \"RightValue\"").Evaluate);
        }

        [TestMethod]
        public void BitwiseXORTest()
        {
            Assert.AreEqual(ExpressionHelpers.Parse("1 ^ 0").Evaluate(), 1 ^ 0);

            Assert.AreEqual(ExpressionHelpers.Parse("1024 ^ 9").Evaluate(), 1024 ^ 9);

            Assert.AreEqual(ExpressionHelpers.Parse("0 ^ 0").Evaluate(), 0 ^ 0);

            Assert.ThrowsException<InvalidMathOperatorException>(ExpressionHelpers.Parse("0.2 ^ 5").Evaluate);

            Assert.ThrowsException<InvalidMathOperatorException>(ExpressionHelpers.Parse("5 ^ 0.2").Evaluate);

            Assert.ThrowsException<NullContextException>(ExpressionHelpers.Parse("LeftValue ^ RightValue").Evaluate);

            Assert.ThrowsException<InvalidMathOperatorException>(ExpressionHelpers.Parse("\"LeftValue\" ^ \"RightValue\"").Evaluate);
        }

        [TestMethod]
        public void BitwiseNOTTest()
        {
            Assert.AreEqual(ExpressionHelpers.Parse("~1").Evaluate(), ~1);

            Assert.AreEqual(ExpressionHelpers.Parse("~-1").Evaluate(), ~-1);

            Assert.AreEqual(ExpressionHelpers.Parse("~~~-5").Evaluate(), ~~~-5);

            Assert.ThrowsException<InvalidMathOperatorException>(ExpressionHelpers.Parse("~true").Evaluate);

            Assert.ThrowsException<NullContextException>(ExpressionHelpers.Parse("~LeftValue").Evaluate);

            Assert.ThrowsException<InvalidMathOperatorException>(ExpressionHelpers.Parse("~\"LeftValue\"").Evaluate);
        }
    }
}
