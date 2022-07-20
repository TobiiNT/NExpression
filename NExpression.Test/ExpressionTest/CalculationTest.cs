using NExpression.Core.Helpers;

namespace NExpression.Test.ExpressionTest
{
    [TestClass]
    public class CalculationTest
    {
        [TestMethod]
        public void NegativeNumberTest()
        {
            // Negative
            Assert.AreEqual(ExpressionHelpers.Parse("-10").Evaluate(), -10);

            // Positive
            Assert.AreEqual(ExpressionHelpers.Parse("+10").Evaluate(), +10);

            // Negative of LeftValue negative
            Assert.AreEqual(ExpressionHelpers.Parse("-(-10)").Evaluate(), -(-10));

            // Woah!
            Assert.AreEqual(ExpressionHelpers.Parse("-+-+-10").Evaluate(), -+-+-10);

            // All together now
            Assert.AreEqual(ExpressionHelpers.Parse("10 + -20 - +30").Evaluate(), 10 + -20 - +30);
        }

        [TestMethod]
        public void AddSubtractTest()
        {
            // Add 
            Assert.AreEqual(ExpressionHelpers.Parse("10 + 20").Evaluate(), 10 + 20);

            // Subtract 
            Assert.AreEqual(ExpressionHelpers.Parse("10 - 20").Evaluate(), 10 - 20);

            // Sequence
            Assert.AreEqual(ExpressionHelpers.Parse("10 + 20 - 40 + 100").Evaluate(), 10 + 20 - 40 + 100);

            // Sequence
            Assert.AreEqual(ExpressionHelpers.Parse("10 + 20 - 40 + 100").Evaluate(), 10 + 20 - 40 + 100);
        }

        [TestMethod]
        public void MultiplyDivideTest()
        {
            Assert.AreEqual(ExpressionHelpers.Parse("10 * 20").Evaluate(), 10 * 20);

            Assert.AreEqual(ExpressionHelpers.Parse("10 / 20").Evaluate(), 10 / 20);

            Assert.AreEqual(ExpressionHelpers.Parse("10 * 20 / 50").Evaluate(), 10 * 20 / 50);
            
            Assert.ThrowsException<DivideByZeroException>(() => ExpressionHelpers.Parse("2 / 0").Evaluate());
        }

        [TestMethod]
        public void ModulusTest()
        {
            Assert.AreEqual(ExpressionHelpers.Parse("10 % 4").Evaluate(), 10 % 4);

            Assert.AreEqual(ExpressionHelpers.Parse("20 % 20").Evaluate(), 20 % 20);

            Assert.AreEqual(ExpressionHelpers.Parse("200 % 50").Evaluate(), 200 % 50);
           
            Assert.AreEqual(ExpressionHelpers.Parse("201 % 50").Evaluate(), 201 % 50);
        }

        [TestMethod]
        public void OrderOfOperationTest()
        {
            Assert.AreEqual(ExpressionHelpers.Parse("10 + 20 * 30").Evaluate(), 10 + 20 * 30);

            Assert.AreEqual(ExpressionHelpers.Parse("(10 + 20) * 30").Evaluate(), (10 + 20) * 30);

            Assert.AreEqual(ExpressionHelpers.Parse("-(10 + 20) * 30").Evaluate(), -(10 + 20) * 30);

            Assert.AreEqual(ExpressionHelpers.Parse("-((10 + 20) * 5) * 30").Evaluate(), -((10 + 20) * 5) * 30);
            
            Assert.AreEqual(ExpressionHelpers.Parse("(10)").Evaluate(), (10));

            //Assert.ThrowsException<SyntaxException>(ExpressionHelpers.Parse("((30 - 5) * 4").Evaluate);
        }
    }
}
