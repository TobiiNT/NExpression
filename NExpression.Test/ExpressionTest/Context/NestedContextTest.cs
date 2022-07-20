using NExpression.Core.Contexts;
using NExpression.Core.Helpers;
using NExpression.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            Floating["Double"] = Double;
            Floating["Decimal"] = Decimal;

            NonFloating["Integer"] = Integer;
            NonFloating["Long"] = Long;

            Number["Floating"] = Floating;
            Number["NonFloating"] = NonFloating;

            Assert.AreEqual(ExpressionHelpers.Parse("Name", Number).Evaluate(), "Number");

            Assert.AreEqual(ExpressionHelpers.Parse("Floating.Name", Number).Evaluate(), "Floating");

            Assert.AreEqual(ExpressionHelpers.Parse("NonFloating.Name", Number).Evaluate(), "NonFloating");

            Assert.AreEqual(ExpressionHelpers.Parse("Floating.Double.Name", Number).Evaluate(), "Double");

            Assert.AreEqual(ExpressionHelpers.Parse("Floating.Decimal.Name", Number).Evaluate(), "Decimal");

            Assert.AreEqual(ExpressionHelpers.Parse("NonFloating.Integer.Name", Number).Evaluate(), "Integer");

            Assert.AreEqual(ExpressionHelpers.Parse("NonFloating.Long.Name", Number).Evaluate(), "Long");
        }

        [TestMethod]
        public void CommandTwoLevelContext()
        {
            var MainContext = new DynamicContext("Main");

            ExpressionHelpers.Parse("A = new Context()", MainContext).Evaluate();

        }
    }
}
