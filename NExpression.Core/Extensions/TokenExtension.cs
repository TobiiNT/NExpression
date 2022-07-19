using NExpression.Core.Tokens;

namespace NExpression.Core.Extensions
{
    public static class TokenExtension
    {
        public static string Symbol(this Token Token)
        {
            switch (Token)
            {
                case Token.OpenParenthesis: return "(";
                case Token.CloseParenthesis: return ")";
                case Token.OpenBlacket: return "[";
                case Token.CloseBlacket: return "]";
                case Token.OpenBrace: return "{";
                case Token.CloseBrace: return "}";
                case Token.Comma: return ",";
                case Token.Dot: return ".";
                case Token.SingleColon: return ":";
                case Token.SemiColon: return ";";
                case Token.SingleExclamation: return "!";
                case Token.SingleQuestion: return "?";
                case Token.DoubleQuestion: return "??";
                case Token.DoubleQuestionAndEqual: return "??=";
                case Token.SingleQuote: return "\'";
                case Token.DoubleQuote: return "\"";
                case Token.SingleDash: return "-";
                case Token.SingleDashAndEqual: return "-=";
                case Token.DoubleDash: return "--";
                case Token.SingleCross: return "+";
                case Token.SingleCrossAndEqual: return "+=";
                case Token.DoubleCross: return "++";
                case Token.SingleAsterisk: return "*";
                case Token.SingleAsteriskAndEqual: return "*=";
                case Token.SingleSlash: return "/";
                case Token.SingleSlashAndEqual: return "/=";
                case Token.SingleBackSlash: return "\\";
                case Token.SinglePercent: return "%";
                case Token.SinglePercentAndEqual: return "$=";
                case Token.SingleTilde: return "~";
                case Token.SingleCaret: return "^";
                case Token.SingleCaretAndEqual: return "^=";
                case Token.SinglePipe: return "|";
                case Token.DoublePipe: return "||";
                case Token.SinglePipeAndEqual: return "|=";
                case Token.SingleAmpersand: return "&";
                case Token.DoubleAmpersand: return "&&";
                case Token.SingleAmpersandAndEqual: return "&=";
                case Token.SingleGreaterThan: return ">";
                case Token.DoubleGreaterThan: return ">>";
                case Token.SingleGreaterThanAndEqual: return ">=";
                case Token.DoubleGreaterThanAndEqual: return ">>=";
                case Token.SingleLessThan: return "<";
                case Token.DoubleLessThan: return "<<";
                case Token.SingleLessThanAndEqual: return "<=";
                case Token.DoubleLessThanAndEqual: return "<<=";
                case Token.SingleEqual: return "=";
                case Token.DoupleEqual: return "==";
                case Token.TripleEqual: return "===";
                case Token.SingleExclamationAndSingleEqual: return "!=";
                case Token.SingleExclamationAndDoubleEqual: return "!==";
                case Token.Identifier: return "identifier";
                case Token.Character: return "character";
                case Token.KeywordVar: return "var";
                case Token.KeywordTrue: return "true";
                case Token.KeywordFalse: return "false";
                case Token.KeywordNull: return "null";
                default: return Token.ToString();
            }
        }
    }
}
