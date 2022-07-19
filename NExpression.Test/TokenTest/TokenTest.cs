using NExpression.Core.Helpers;
using NExpression.Core.Tokens;

namespace NExpression.Test.TokenTest
{
    [TestClass]
    public class TokenTest
    {
        [TestMethod]
        public void AddSubtractTest()
        {
            var Tokenizer = TokenHelpers.Parse("1 + 2 - 3 + 4 - 5");

            var TestValues = new List<(Token, object?)>()
            {
               (Token.NonFloatingDecimal, 1),
               (Token.SingleCross, null),
               (Token.NonFloatingDecimal, 2),
               (Token.SingleDash, null),
               (Token.NonFloatingDecimal, 3 ),
               (Token.SingleCross, null),
               (Token.NonFloatingDecimal, 4),
               (Token.SingleDash, null),
               (Token.NonFloatingDecimal, 5),
            };

            TestTokenizer(Tokenizer, TestValues);
        }

        [TestMethod]
        public void MultiplyDivideModulusTest()
        {
            var Tokenizer = TokenHelpers.Parse("1 * 2 / 3 % 4");

            var TestValues = new List<(Token, object?)>()
            {
               (Token.NonFloatingDecimal, 1),
               (Token.SingleAsterisk, null),
               (Token.NonFloatingDecimal, 2),
               (Token.SingleSlash, null),
               (Token.NonFloatingDecimal, 3 ),
               (Token.SinglePercent, null),
               (Token.NonFloatingDecimal, 4),
            };

            TestTokenizer(Tokenizer, TestValues);
        }

        [TestMethod]
        public void ShiftTest()
        {
            var Tokenizer = TokenHelpers.Parse("1 << 2 >> 3 << 4");

            var TestValues = new List<(Token, object?)>()
            {
               (Token.NonFloatingDecimal, 1),
               (Token.DoubleLessThan, null),
               (Token.NonFloatingDecimal, 2),
               (Token.DoubleGreaterThan, null),
               (Token.NonFloatingDecimal, 3 ),
               (Token.DoubleLessThan, null),
               (Token.NonFloatingDecimal, 4),
            };

            TestTokenizer(Tokenizer, TestValues);
        }

        [TestMethod]
        public void ComparisionsTest()
        {
            var Tokenizer = TokenHelpers.Parse("1 > 2 < 3 >= 4 <= 5 == 6 != 7");

            var TestValues = new List<(Token, object?)>()
            {
               (Token.NonFloatingDecimal, 1),
               (Token.SingleGreaterThan, null),
               (Token.NonFloatingDecimal, 2),
               (Token.SingleLessThan, null),
               (Token.NonFloatingDecimal, 3 ),
               (Token.SingleGreaterThanAndEqual, null),
               (Token.NonFloatingDecimal, 4),
               (Token.SingleLessThanAndEqual, null),
               (Token.NonFloatingDecimal, 5),
               (Token.DoupleEqual, null),
               (Token.NonFloatingDecimal, 6),
               (Token.SingleExclamationAndSingleEqual, null),
               (Token.NonFloatingDecimal, 7),
            };

            TestTokenizer(Tokenizer, TestValues);
        }

        [TestMethod]
        public void BitwiseTest()
        {
            var Tokenizer = TokenHelpers.Parse("1 | 2 & 3 ^ 4");

            var TestValues = new List<(Token, object?)>()
            {
               (Token.NonFloatingDecimal, 1),
               (Token.SinglePipe, null),
               (Token.NonFloatingDecimal, 2),
               (Token.SingleAmpersand, null),
               (Token.NonFloatingDecimal, 3 ),
               (Token.SingleCaret, null),
               (Token.NonFloatingDecimal, 4),
            };

            TestTokenizer(Tokenizer, TestValues);
        }

        [TestMethod]
        public void ConditionalTest()
        {
            var Tokenizer = TokenHelpers.Parse("1 && 2 || 3");

            var TestValues = new List<(Token, object?)>()
            {
               (Token.NonFloatingDecimal, 1),
               (Token.DoubleAmpersand, null),
               (Token.NonFloatingDecimal, 2),
               (Token.DoublePipe, null),
               (Token.NonFloatingDecimal, 3 ),
            };

            TestTokenizer(Tokenizer, TestValues);
        }

        [TestMethod]
        public void IdentifierTest()
        {
            var Tokenizer = TokenHelpers.Parse("a + b / pi");

            var TestValues = new List<(Token, object?)>()
            {
               (Token.Identifier, "a"),
               (Token.SingleCross, null),
               (Token.Identifier, "b"),
               (Token.SingleSlash, null),
               (Token.Identifier, "pi" ),
            };

            TestTokenizer(Tokenizer, TestValues);
        }

        [TestMethod]
        public void SymbolTest()
        {
            var Tokenizer = TokenHelpers.Parse("(1 + 2) / (3 - 4)");

            var TestValues = new List<(Token, object?)>()
            {
               (Token.OpenParenthesis, null),
               (Token.NonFloatingDecimal, 1),
               (Token.SingleCross, null),
               (Token.NonFloatingDecimal, 2),
               (Token.CloseParenthesis, null),
               (Token.SingleSlash, null),
               (Token.OpenParenthesis, null),
               (Token.NonFloatingDecimal, 3),
               (Token.SingleDash, null),
               (Token.NonFloatingDecimal, 4),
               (Token.CloseParenthesis, null),
            };

            TestTokenizer(Tokenizer, TestValues);
        }

        [TestMethod]
        public void StringTest()
        {
            var Tokenizer = TokenHelpers.Parse("\"abc\"");

            var TestValues = new List<(Token, object?)>()
            {
               (Token.DoubleQuote, null),
               (Token.Character, "a"),
               (Token.Character, "b"),
               (Token.Character, "c"),
               (Token.DoubleQuote, null),
            };

            TestTokenizer(Tokenizer, TestValues);
        }

        [TestMethod]
        public void CharTest()
        {
            var Tokenizer = TokenHelpers.Parse("\'a\'");

            var TestValues = new List<(Token, object?)>()
            {
               (Token.SingleQuote, null),
               (Token.Character, 'a'),
               (Token.SingleQuote, null),
            };

            TestTokenizer(Tokenizer, TestValues);
        }

        private void TestTokenizer(Tokenizer Tokenizer, List<(Token, object?)> TestValues)
        {
            foreach (var TestValue in TestValues)
            {
                Token ExpectedToken = TestValue.Item1;
                object? ExpectedValue = TestValue.Item2;

                Assert.AreEqual(Tokenizer.Token, ExpectedToken);
                if (ExpectedToken == Token.FloatingDecimal || ExpectedToken == Token.NonFloatingDecimal)
                {
                    Assert.IsNotNull(ExpectedValue);
                    Assert.AreEqual(Tokenizer.TokenString, ExpectedValue.ToString());
                }
                else if (ExpectedToken == Token.KeywordTrue)
                {
                    Assert.IsNotNull(ExpectedValue);
                    Assert.AreEqual(Tokenizer.TokenString, true);
                }
                else if (ExpectedToken == Token.KeywordFalse)
                {
                    Assert.IsNotNull(ExpectedValue);
                    Assert.AreEqual(Tokenizer.TokenString, false);
                }
                else if (ExpectedToken == Token.Identifier)
                {
                    Assert.IsNotNull(ExpectedValue);
                    Assert.AreEqual(Tokenizer.TokenString, (string)ExpectedValue);
                }
                else if (ExpectedToken == Token.Character)
                {
                    Assert.IsNotNull(ExpectedValue);
                    Assert.AreEqual(Tokenizer.TokenString, ExpectedValue.ToString());
                }
                Tokenizer.NextToken();
            }
        }
    }
}