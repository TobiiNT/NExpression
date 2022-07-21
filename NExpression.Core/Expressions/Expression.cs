using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Parsers;
using NExpression.Core.Expressions.Parsers.Interfaces;
using NExpression.Core.Tokens;

namespace NExpression.Core.Expressions
{
    public class Expression
    {
        private static List<Token> TokensPostfix = new List<Token> { Token.DoubleCross, Token.DoubleDash, Token.SingleExclamation, Token.OpenBlacket };
        private static List<Token> TokensUnary = new List<Token> { Token.SingleCross, Token.SingleDash, Token.SingleExclamation, Token.SingleTilde, Token.DoubleCross, Token.DoubleDash };
        private static List<Token> TokensMultiplyDivideModulus = new List<Token> { Token.SingleAsterisk, Token.SingleSlash, Token.SinglePercent };
        private static List<Token> TokensAddSubtract = new List<Token> { Token.SingleCross, Token.SingleDash };
        private static List<Token> TokensBitwiseShift = new List<Token> { Token.DoubleLessThan, Token.DoubleGreaterThan };
        private static List<Token> TokensLessGreaterComparisions = new List<Token> { Token.SingleGreaterThan, Token.SingleGreaterThanAndEqual, Token.SingleLessThan, Token.SingleLessThanAndEqual };
        private static List<Token> TokensEqualNotEqualComparisions = new List<Token> { Token.DoupleEqual, Token.SingleExclamationAndSingleEqual, Token.TripleEqual, Token.SingleExclamationAndDoubleEqual };
        private static List<Token> TokensBitwiseAND = new List<Token> { Token.SingleAmpersand };
        private static List<Token> TokensBitwiseXOR = new List<Token> { Token.SingleCaret };
        private static List<Token> TokensBitwiseOR = new List<Token> { Token.SinglePipe };
        private static List<Token> TokensLogicalAND = new List<Token> { Token.DoubleAmpersand };
        private static List<Token> TokensLogicalOR = new List<Token> { Token.DoublePipe };
        private static List<Token> TokensLogicalIFNULL = new List<Token> { Token.DoubleQuestion };
        private static List<Token> TokensString = new List<Token> { Token.DoubleQuote, Token.SingleQuote };
        private static List<Token> TokensTernaryCondition = new List<Token> { Token.SingleQuestion, Token.SingleColon };
        private static List<Token> TokensAssignValue = new List<Token> { Token.SingleEqual, Token.SingleCrossAndEqual, Token.SingleDashAndEqual, Token.SingleAsteriskAndEqual, Token.SingleDashAndEqual, Token.SinglePercentAndEqual, Token.SingleAmpersandAndEqual, Token.SingleCaretAndEqual, Token.SinglePipeAndEqual, Token.DoubleLessThanAndEqual, Token.DoubleGreaterThanAndEqual, Token.DoubleQuestionAndEqual };
        private Tokenizer Tokenizer { set; get; }
        public IParser Parser { set; get; }

        public Expression(Tokenizer Tokenizer, IContext? Context)
        {
            this.Tokenizer = Tokenizer;

            IParser ParseLeaf = new LeafParser(Context, Tokenizer, this);
            IParser ParsePostfix = new PostfixParser(Context, Tokenizer, ParseLeaf, TokensPostfix);
            IParser ParseUnary = new UnaryParser(Context, Tokenizer, ParsePostfix, TokensUnary);
            IParser ParseMultiplyDivideModulus = new ExpressionParser(Tokenizer, ParseUnary, TokensMultiplyDivideModulus);
            IParser ParseAddSubtract = new ExpressionParser(Tokenizer, ParseMultiplyDivideModulus, TokensAddSubtract);
            IParser ParseBitwiseShift = new ExpressionParser(Tokenizer, ParseAddSubtract, TokensBitwiseShift);
            IParser ParseLessGreaterComparisions = new ExpressionParser(Tokenizer, ParseBitwiseShift, TokensLessGreaterComparisions);
            IParser ParseEqualNotEqualComparisions = new ExpressionParser(Tokenizer, ParseLessGreaterComparisions, TokensEqualNotEqualComparisions);
            IParser ParseBitwiseAND = new ExpressionParser(Tokenizer, ParseEqualNotEqualComparisions, TokensBitwiseAND);
            IParser ParseBitwiseXOR = new ExpressionParser(Tokenizer, ParseBitwiseAND, TokensBitwiseXOR);
            IParser ParseBitwiseOR = new ExpressionParser(Tokenizer, ParseBitwiseXOR, TokensBitwiseOR);
            IParser ParseLogicalAND = new ExpressionParser(Tokenizer, ParseBitwiseOR, TokensLogicalAND);
            IParser ParseLogicalOR = new ExpressionParser(Tokenizer, ParseLogicalAND, TokensLogicalOR);
            IParser ParseLogicalIFNULL = new ExpressionParser(Tokenizer, ParseLogicalOR, TokensLogicalIFNULL);
            IParser ParseString = new CharacterParser(Tokenizer, ParseLogicalIFNULL, TokensString);
            IParser ParseTernaryCondition = new TernaryParser(Tokenizer, ParseString, TokensTernaryCondition);
            IParser ParseAssignValue = new AssignmentParser(Context, Tokenizer, ParseTernaryCondition, TokensAssignValue);
            IParser ParseEmpty = new EmptyParser(ParseAssignValue);

            this.Parser = ParseEmpty;
        }

        public INode ParseExpression<T>()
        {
            var ResultExpression = this.Parser.NextParser.Parse<T>();

            if (Tokenizer.Token != Token.EOF)
                throw new ExpressionSyntaxException("Unexpected characters at end of expression");

            return ResultExpression;
        }
    }
}
