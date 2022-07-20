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
        private Tokenizer Tokenizer { set; get; }
        public IParser Parser { set; get; }

        public Expression(Tokenizer Tokenizer, IContext? Context)
        {
            this.Tokenizer = Tokenizer;

            IParser ParseLeaf = new LeafParser(Context, Tokenizer, this);
            IParser ParsePostfix = new PostfixParser(Context, Tokenizer, ParseLeaf, new List<Token> { Token.DoubleCross, Token.DoubleDash, Token.SingleExclamation, Token.OpenBlacket });
            IParser ParseUnary = new UnaryParser(Context, Tokenizer, ParsePostfix, new List<Token> { Token.SingleCross, Token.SingleDash, Token.SingleExclamation, Token.SingleTilde, Token.DoubleCross, Token.DoubleDash });
            IParser ParseMultiplyDivideModulus = new ExpressionParser(Tokenizer, ParseUnary, new List<Token> { Token.SingleAsterisk, Token.SingleSlash, Token.SinglePercent });
            IParser ParseAddSubtract = new ExpressionParser(Tokenizer, ParseMultiplyDivideModulus, new List<Token> { Token.SingleCross, Token.SingleDash });
            IParser ParseBitwiseShift = new ExpressionParser(Tokenizer, ParseAddSubtract, new List<Token> { Token.DoubleLessThan, Token.DoubleGreaterThan });
            IParser ParseLessGreaterComparisions = new ExpressionParser(Tokenizer, ParseBitwiseShift, new List<Token> { Token.SingleGreaterThan, Token.SingleGreaterThanAndEqual, Token.SingleLessThan, Token.SingleLessThanAndEqual });
            IParser ParseEqualNotEqualComparisions = new ExpressionParser(Tokenizer, ParseLessGreaterComparisions, new List<Token> { Token.DoupleEqual, Token.SingleExclamationAndSingleEqual, Token.TripleEqual, Token.SingleExclamationAndDoubleEqual });
            IParser ParseBitwiseAND = new ExpressionParser(Tokenizer, ParseEqualNotEqualComparisions, new List<Token> { Token.SingleAmpersand });
            IParser ParseBitwiseXOR = new ExpressionParser(Tokenizer, ParseBitwiseAND, new List<Token> { Token.SingleCaret });
            IParser ParseBitwiseOR = new ExpressionParser(Tokenizer, ParseBitwiseXOR, new List<Token> { Token.SinglePipe });
            IParser ParseLogicalAND = new ExpressionParser(Tokenizer, ParseBitwiseOR, new List<Token> { Token.DoubleAmpersand });
            IParser ParseLogicalOR = new ExpressionParser(Tokenizer, ParseLogicalAND, new List<Token> { Token.DoublePipe });
            IParser ParseLogicalIFNULL = new ExpressionParser(Tokenizer, ParseLogicalOR, new List<Token> { Token.DoubleQuestion });
            IParser ParseString = new CharacterParser(Tokenizer, ParseLogicalIFNULL, new List<Token> { Token.DoubleQuote, Token.SingleQuote });
            IParser ParseTernaryCondition = new TernaryParser(Tokenizer, ParseString, new List<Token> { Token.SingleQuestion, Token.SingleColon });
            IParser ParseAssignValue = new AssignmentParser(Context, Tokenizer, ParseTernaryCondition, new List<Token> { Token.SingleEqual, Token.SingleCrossAndEqual, Token.SingleDashAndEqual, Token.SingleAsteriskAndEqual, Token.SingleDashAndEqual, Token.SinglePercentAndEqual, Token.SingleAmpersandAndEqual, Token.SingleCaretAndEqual, Token.SinglePipeAndEqual, Token.DoubleLessThanAndEqual, Token.DoubleGreaterThanAndEqual, Token.DoubleQuestionAndEqual });
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
