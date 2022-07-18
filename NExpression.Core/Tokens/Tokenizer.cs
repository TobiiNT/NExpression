using System.Globalization;
using System.Text;

namespace NExpression.Core.Tokens
{
    public class Tokenizer
    {
        private Token CurrentToken { get; set; }
        public object Value { get; private set; }
        public string Identifier { get; private set; }
        public bool OpeningDoubleQuote { get; private set; }
        public bool OpeningSingleQuote { get; private set; }

        public char[] CharArrays { get; }
        private int Index { set; get; }
        private char CurrentChar => Index < CharArrays.Length ? CharArrays[Index] : '\0';
        public Token Token => CurrentToken;

        public Tokenizer(string Expression)
        {
            this.CharArrays = Expression.ToCharArray();
            this.Index = 0;

            this.NextToken();
        }

        public Tokenizer(Tokenizer Tokenizer)
        {
            this.CharArrays = Tokenizer.CharArrays;
            this.Index = 0;

            this.NextToken();
        }

        private void NextChar() => Index++;

        public void NextToken()
        {
            while (char.IsWhiteSpace(CurrentChar))
            {
                NextChar();
            }

            ReadCurrentToken();
        }

        public void ReadCurrentToken()
        {
            if (this.OpeningDoubleQuote)
            {
                if (CurrentChar == '"')
                {
                    this.OpeningDoubleQuote = false;
                    CurrentToken = Token.DoubleQuote;
                }
                else
                {
                    this.Value = CurrentChar;
                    CurrentToken = Token.Character;
                }
                NextChar();
                return;
            }
            else if (this.OpeningSingleQuote)
            {
                if (CurrentChar == '\'')
                {
                    this.OpeningSingleQuote = false;
                    CurrentToken = Token.SingleQuote;
                }
                else
                {
                    this.Value = CurrentChar;
                    CurrentToken = Token.Character;
                }
                NextChar();
                return;
            }
            else
            {
                switch (CurrentChar)
                {
                    case '\0':
                        CurrentToken = Token.EOF;
                        return;
                    case '(':
                        NextChar();
                        CurrentToken = Token.OpenParenthesis;
                        return;
                    case ')':
                        NextChar();
                        CurrentToken = Token.CloseParenthesis;
                        return;
                    case ',':
                        NextChar();
                        CurrentToken = Token.Comma;
                        return;
                    case ';':
                        NextChar();
                        CurrentToken = Token.SemiColon;
                        return;
                    case '"':
                        NextChar();
                        CurrentToken = Token.DoubleQuote;
                        this.OpeningDoubleQuote = true;
                        return;
                    case '\'':
                        NextChar();
                        CurrentToken = Token.SingleQuote;
                        this.OpeningSingleQuote = true;
                        return;
                    case '+':
                        NextChar();
                        CurrentToken = Token.SingleCross;
                        if (CurrentChar == '+')
                        {
                            NextChar();
                            CurrentToken = Token.DoubleCross;
                        }
                        else if (CurrentChar == '=')
                        {
                            NextChar();
                            CurrentToken = Token.SingleCrossAndEqual;
                        }
                        return;
                    case '-':
                        NextChar();
                        CurrentToken = Token.SingleDash;
                        if (CurrentChar == '-')
                        {
                            NextChar();
                            CurrentToken = Token.DoubleDash;
                        }
                        else if (CurrentChar == '=')
                        {
                            NextChar();
                            CurrentToken = Token.SingleDashAndEqual;
                        }
                        return;
                    case '*':
                        NextChar();
                        CurrentToken = Token.SingleAsterisk;
                        if (CurrentChar == '=')
                        {
                            NextChar();
                            CurrentToken = Token.SingleAsteriskAndEqual;
                        }
                        return;
                    case '/':
                        NextChar();
                        CurrentToken = Token.SingleSlash;
                        if (CurrentChar == '=')
                        {
                            NextChar();
                            CurrentToken = Token.SingleSlashAndEqual;
                        }
                        return;
                    case '%':
                        NextChar();
                        CurrentToken = Token.SinglePercent;
                        if (CurrentChar == '=')
                        {
                            NextChar();
                            CurrentToken = Token.SinglePercentAndEqual;
                        }
                        return;
                    case '&':
                        NextChar();
                        if (CurrentChar == '&')
                        {
                            NextChar();
                            CurrentToken = Token.DoubleAmpersand;
                        }
                        else if (CurrentChar == '=')
                        {
                            NextChar();
                            CurrentToken = Token.SingleAmpersandAndEqual;
                        }
                        else
                        {
                            CurrentToken = Token.SingleAmpersand;
                        }
                        return;
                    case '?':
                        NextChar();
                        if (CurrentChar == '?')
                        {
                            NextChar();
                            CurrentToken = Token.DoubleQuestion;
                            if (CurrentChar == '=')
                            {
                                NextChar();
                                CurrentToken = Token.DoubleQuestionAndEqual;
                            }
                        }
                        else
                        {
                            CurrentToken = Token.SingleQuestion;
                        }
                        return;
                    case ':':
                        NextChar();
                        CurrentToken = Token.SingleColon;
                        return;
                    case '|':
                        NextChar();
                        if (CurrentChar == '|')
                        {
                            NextChar();
                            CurrentToken = Token.DoublePipe;
                        }
                        else if (CurrentChar == '=')
                        {
                            NextChar();
                            CurrentToken = Token.SinglePipeAndEqual;
                        }
                        else
                        {
                            CurrentToken = Token.SinglePipe;
                        }
                        return;
                    case '^':
                        NextChar();
                        CurrentToken = Token.SingleCaret;
                        if (CurrentChar == '=')
                        {
                            NextChar();
                            CurrentToken = Token.SingleCaretAndEqual;
                        }
                        return;
                    case '~':
                        NextChar();
                        CurrentToken = Token.SingleTilde;
                        return;

                    case '!':
                        NextChar();
                        if (CurrentChar == '=')
                        {
                            NextChar();
                            if (CurrentChar == '=')
                            {
                                NextChar();
                                CurrentToken = Token.SingleExclamationAndDoubleEqual;
                            }
                            else
                            {
                                CurrentToken = Token.SingleExclamationAndSingleEqual;
                            }
                        }
                        else
                        {
                            CurrentToken = Token.SingleExclamation;
                        }
                        return;

                    case '=':
                        NextChar();
                        if (CurrentChar == '=')
                        {
                            NextChar();
                            if (CurrentChar == '=')
                            {
                                NextChar();
                                CurrentToken = Token.TripleEqual;
                            }
                            else
                            {
                                CurrentToken = Token.DoupleEqual;
                            }
                        }
                        else
                        {
                            CurrentToken = Token.SingleEqual;
                        }
                        return;

                    case '>':
                        NextChar();
                        if (CurrentChar == '>')
                        {
                            NextChar();
                            CurrentToken = Token.DoubleGreaterThan;
                            if (CurrentChar == '=')
                            {
                                NextChar();
                                CurrentToken = Token.DoubleGreaterThanAndEqual;
                            }
                        }
                        else if (CurrentChar == '=')
                        {
                            NextChar();
                            CurrentToken = Token.SingleGreaterThanAndEqual;
                        }
                        else
                        {
                            CurrentToken = Token.SingleGreaterThan;
                        }
                        return;

                    case '<':
                        NextChar();
                        if (CurrentChar == '<')
                        {
                            NextChar();
                            CurrentToken = Token.DoubleLessThan;
                            if (CurrentChar == '=')
                            {
                                NextChar();
                                CurrentToken = Token.DoubleLessThanAndEqual;
                            }
                        }
                        else if (CurrentChar == '=')
                        {
                            NextChar();
                            CurrentToken = Token.SingleLessThanAndEqual;
                        }
                        else
                        {
                            CurrentToken = Token.SingleLessThan;
                        }
                        return;

                    default:
                        // Number?
                        if (char.IsDigit(CurrentChar) || CurrentChar == '.')
                        {
                            this.ReadNumber();
                        }
                        // Identifier - starts with letter or underscore
                        else if (char.IsLetter(CurrentChar) || CurrentChar == '_')
                        {
                            this.ReadIdentifier();
                        }
                        else
                        {
                            NextChar();
                        }
                        return;
                }
            }
        }

        private void ReadNumber()
        {
            // Capture digits/decimal point
            CultureInfo CultureInfo = CultureInfo.InvariantCulture;
            StringBuilder StringBuilder = new StringBuilder();

            bool HaveDecimalPoint = false;
            while (char.IsDigit(CurrentChar) || (!HaveDecimalPoint && CurrentChar == '.'))
            {
                StringBuilder.Append(CurrentChar);
                if (!HaveDecimalPoint)
                    HaveDecimalPoint = CurrentChar == '.';
                NextChar();
            }

            string NumberString = StringBuilder.ToString();

            // Parse it
            if (HaveDecimalPoint)
            {
                if (double.TryParse(NumberString, NumberStyles.AllowDecimalPoint, CultureInfo, out double DoubleValue))
                {
                    this.Value = DoubleValue;
                    this.CurrentToken = Token.Number;
                }
                else if (decimal.TryParse(NumberString, NumberStyles.AllowDecimalPoint, CultureInfo, out decimal DecimalValue))
                {
                    this.Value = DecimalValue;
                    this.CurrentToken = Token.Number;
                }
            }
            else
            {
                if (int.TryParse(NumberString, NumberStyles.Integer, CultureInfo.InvariantCulture, out int IntValue))
                {
                    this.Value = IntValue;
                    this.CurrentToken = Token.Number;
                }
                else if (long.TryParse(NumberString, NumberStyles.Integer, CultureInfo.InvariantCulture, out long LongValue))
                {
                    this.Value = LongValue;
                    this.CurrentToken = Token.Number;
                }
            }

        }

        private void ReadIdentifier()
        {
            StringBuilder StringBuilder = new StringBuilder();

            // Accept letter, digit or underscore
            while (char.IsLetterOrDigit(CurrentChar) || CurrentChar == '_')
            {
                StringBuilder.Append(CurrentChar);
                NextChar();
            }

            this.Identifier = StringBuilder.ToString();

            this.ReadKeyword(Identifier);
        }

        private void ReadKeyword(string Identifier)
        {
            switch (Identifier.ToLower())
            {
                case "true":
                case "false":
                    {
                        Value = bool.Parse(Identifier);
                        CurrentToken = Token.KeywordBoolean;
                    }
                    return;

                case "var":
                    {
                        Value = typeof(object);
                        CurrentToken = Token.KeywordVar;
                    }
                    return;

                case "null":
                    {
                        CurrentToken = Token.KeywordNull;
                    }
                    return;

                default:
                    {
                        CurrentToken = Token.Identifier;
                    }
                    return;
            }
        }
    }
}
