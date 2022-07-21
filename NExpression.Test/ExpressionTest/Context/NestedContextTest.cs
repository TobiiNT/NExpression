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

            ExpressionHelpers.Parse("Family = new Context()", MainContext).Evaluate();

            ExpressionHelpers.Parse("Family.Members = 2", MainContext).Evaluate();

            Assert.AreEqual(ExpressionHelpers.Parse("Family.Members", MainContext).Evaluate(), 2);
            
            ExpressionHelpers.Parse("Family.Father = new Context()", MainContext).Evaluate();

            ExpressionHelpers.Parse("Family.Father.Age = 40", MainContext).Evaluate();

            Assert.AreEqual(ExpressionHelpers.Parse("Family.Father.Age", MainContext).Evaluate(), 40);

            ExpressionHelpers.Parse("Family.Mother = new Context()", MainContext).Evaluate();

            ExpressionHelpers.Parse("Family.Mother.Age = 35", MainContext).Evaluate();

            Assert.AreEqual(ExpressionHelpers.Parse("Family.Mother.Age", MainContext).Evaluate(), 35);
        }

        [TestMethod]
        public void CommandThreeLevelContext()
        {
            var NumberContext = new DynamicContext("Number");

            ExpressionHelpers.Parse("Name = \"Number\"", NumberContext).Evaluate();

            Assert.AreEqual(ExpressionHelpers.Parse("Name", NumberContext).Evaluate(), "Number");

            ExpressionHelpers.Parse("Floating = new Context()", NumberContext).Evaluate();

            ExpressionHelpers.Parse("Floating.Name = \"Floating\"", NumberContext).Evaluate();

            Assert.AreEqual(ExpressionHelpers.Parse("Floating.Name", NumberContext).Evaluate(), "Floating");

            ExpressionHelpers.Parse("NonFloating = new Context()", NumberContext).Evaluate();

            ExpressionHelpers.Parse("NonFloating.Name = \"NonFloating\"", NumberContext).Evaluate();

            Assert.AreEqual(ExpressionHelpers.Parse("NonFloating.Name", NumberContext).Evaluate(), "NonFloating");

            ExpressionHelpers.Parse("Floating.DoubleNum = new Context()", NumberContext).Evaluate();

            ExpressionHelpers.Parse("Floating.DoubleNum.Name = \"Double\"", NumberContext).Evaluate();
            
            Assert.AreEqual(ExpressionHelpers.Parse("Floating.DoubleNum.Name", NumberContext).Evaluate(), "Double");

            ExpressionHelpers.Parse("Floating.DecimalNum = new Context()", NumberContext).Evaluate();

            ExpressionHelpers.Parse("Floating.DecimalNum.Name = \"Decimal\"", NumberContext).Evaluate();

            Assert.AreEqual(ExpressionHelpers.Parse("Floating.DecimalNum.Name", NumberContext).Evaluate(), "Decimal");

            ExpressionHelpers.Parse("NonFloating.IntegerNum = new Context()", NumberContext).Evaluate();

            ExpressionHelpers.Parse("NonFloating.IntegerNum.Name = \"Integer\"", NumberContext).Evaluate();

            Assert.AreEqual(ExpressionHelpers.Parse("NonFloating.IntegerNum.Name", NumberContext).Evaluate(), "Integer");

            ExpressionHelpers.Parse("NonFloating.LongNum = new Context()", NumberContext).Evaluate();

            ExpressionHelpers.Parse("NonFloating.LongNum.Name = \"Long\"", NumberContext).Evaluate();

            Assert.AreEqual(ExpressionHelpers.Parse("NonFloating.LongNum.Name", NumberContext).Evaluate(), "Long");

        }
    }
}
