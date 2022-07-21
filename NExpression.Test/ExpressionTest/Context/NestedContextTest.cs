using NExpression.Core.Contexts;
using NExpression.Core.Helpers;

namespace NExpression.Test.ExpressionTest.Context
{
    [TestClass]
    public class NestedContextTest
    {
        [TestMethod]
        public void ReadTwoLevelContext()
        {
            var Family = new DynamicContext("Family");
            Family["Members"] = 2;

            var Father = new DynamicContext("Father");
            Father["Age"] = 40;

            var Mother = new DynamicContext("Mother");
            Mother["Age"] = 35;

            Family["Father"] = Father;
            Family["Mother"] = Mother;

            Assert.AreEqual(ExpressionHelpers.Parse("Members", Family).Evaluate(), 2);

            Assert.AreEqual(ExpressionHelpers.Parse("Father.Age", Family).Evaluate(), 40);

            Assert.AreEqual(ExpressionHelpers.Parse("Mother.Age", Family).Evaluate(), 35);
        }

        [TestMethod]
        public void ReadThreeLevelContext()
        {
            var Number = new DynamicContext("Number");
            Number["Name"] = "Number";

            var Floating = new DynamicContext("Floating");
            Floating["Name"] = "Floating";

            var NonFloating = new DynamicContext("NonFloating");
            NonFloating["Name"] = "NonFloating";

            var Double = new DynamicContext("Double");
            Double["Name"] = "Double";

            var Decimal = new DynamicContext("Decimal");
            Decimal["Name"] = "Decimal";

            var Integer = new DynamicContext("Integer");
            Integer["Name"] = "Integer";

            var Long = new DynamicContext("Long");
            Long["Name"] = "Long";

            Floating["doubleNum"] = Double;
            Floating["decimalNum"] = Decimal;

            NonFloating["integerNum"] = Integer;
            NonFloating["longNum"] = Long;

            Number["Floating"] = Floating;
            Number["NonFloating"] = NonFloating;

            Assert.AreEqual(ExpressionHelpers.Parse("Name", Number).Evaluate(), "Number");

            Assert.AreEqual(ExpressionHelpers.Parse("Floating.Name", Number).Evaluate(), "Floating");

            Assert.AreEqual(ExpressionHelpers.Parse("NonFloating.Name", Number).Evaluate(), "NonFloating");

            Assert.AreEqual(ExpressionHelpers.Parse("Floating.doubleNum.Name", Number).Evaluate(), "Double");

            Assert.AreEqual(ExpressionHelpers.Parse("Floating.decimalNum.Name", Number).Evaluate(), "Decimal");

            Assert.AreEqual(ExpressionHelpers.Parse("NonFloating.integerNum.Name", Number).Evaluate(), "Integer");

            Assert.AreEqual(ExpressionHelpers.Parse("NonFloating.longNum.Name", Number).Evaluate(), "Long");
        }

        [TestMethod]
        public void CommandTwoLevelContext()
        {
            var MainContext = new DynamicContext("Main");

            ExpressionHelpers.Parse("A = new Context()", MainContext).Evaluate();

        }
    }
}
