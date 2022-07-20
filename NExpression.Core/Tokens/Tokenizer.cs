using System.Text;

namespace NExpression.Core.Tokens
{
    public class Tokenizer
    {
        private Token CurrentToken { get; set; }
        public string? TokenString { get; private set; }
        public bool OpeningDoubleQuote { get; private set; }
        public bool OpeningSingleQuote { get; private set; }

        public char[] CharArrays { get; }
        private int Index { set; get; }

        private char CurrentChar => Index < CharArrays.Length ? CharArrays[Index] : '\0';
        private char NextChar => Index + 1 < CharArrays.Length ? CharArrays[Index + 1] : '\0';
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

        private void GoNextChar() => Index++;
        private void SkipChar(int SkipCount) => Index += SkipCount;

        public void NextToken()
        {
            // Skip whitespace
            while (char.IsWhiteSpace(CurrentChar))
            {
                GoNextChar();
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
                    this.TokenString = CurrentChar.ToString();
                    CurrentToken = Token.Character;
                }
                GoNextChar();
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
                    this.TokenString = CurrentChar.ToString();
                    CurrentToken = Token.Character;
                }
                GoNextChar();
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
                        GoNextChar();
                        CurrentToken = Token.OpenParenthesis;
                        return;
                    case ')':
                        GoNextChar();
                        CurrentToken = Token.CloseParenthesis;
                        return;
                    case '[':
                        GoNextChar();
                        CurrentToken = Token.OpenBlacket;
                        return;
                    case ']':
                        GoNextChar();
                        CurrentToken = Token.CloseBlacket;
                        return;
                    case '{':
                        GoNextChar();
                        CurrentToken = Token.OpenBrace;
                        return;
                    case '}':
                        GoNextChar();
                        CurrentToken = Token.CloseBrace;
                        return;
                    case ',':
                        GoNextChar();
                        CurrentToken = Token.Comma;
                        return;
                    case ';':
                        GoNextChar();
                        CurrentToken = Token.SemiColon;
                        return;
                    case '.':
                        GoNextChar();
                        CurrentToken = Token.Dot;
                        return;
                    case '"':
                        GoNextChar();
                        CurrentToken = Token.DoubleQuote;
                        this.OpeningDoubleQuote = true;
                        return;
                    case '\'':
                        GoNextChar();
                        CurrentToken = Token.SingleQuote;
                        this.OpeningSingleQuote = true;
                        return;
                    case '+':
                        GoNextChar();
                        CurrentToken = Token.SingleCross;
                        if (CurrentChar == '+')
                        {
                            GoNextChar();
                            CurrentToken = Token.DoubleCross;
                        }
                        else if (CurrentChar == '=')
                        {
                            GoNextChar();
                            CurrentToken = Token.SingleCrossAndEqual;
                        }
                        return;
                    case '-':
                        GoNextChar();
                        CurrentToken = Token.SingleDash;
                        if (CurrentChar == '-')
                        {
                            GoNextChar();
                            CurrentToken = Token.DoubleDash;
                        }
                        else if (CurrentChar == '=')
                        {
                            GoNextChar();
                            CurrentToken = Token.SingleDashAndEqual;
                        }
                        return;
                    case '*':
                        GoNextChar();
                        CurrentToken = Token.SingleAsterisk;
                        if (CurrentChar == '=')
                        {
                            GoNextChar();
                            CurrentToken = Token.SingleAsteriskAndEqual;
                        }
                        return;
                    case '/':
                        GoNextChar();
                        CurrentToken = Token.SingleSlash;
                        if (CurrentChar == '=')
                        {
                            GoNextChar();
                            CurrentToken = Token.SingleSlashAndEqual;
                        }
                        return;
                    case '%':
                        GoNextChar();
                        CurrentToken = Token.SinglePercent;
                        if (CurrentChar == '=')
                        {
                            GoNextChar();
                            CurrentToken = Token.SinglePercentAndEqual;
                        }
                        return;
                    case '&':
                        GoNextChar();
                        if (CurrentChar == '&')
                        {
                            GoNextChar();
                            CurrentToken = Token.DoubleAmpersand;
                        }
                        else if (CurrentChar == '=')
                        {
                            GoNextChar();
                            CurrentToken = Token.SingleAmpersandAndEqual;
                        }
                        else
                        {
                            CurrentToken = Token.SingleAmpersand;
                        }
                        return;
                    case '?':
                        GoNextChar();
                        if (CurrentChar == '?')
                        {
                            GoNextChar();
                            CurrentToken = Token.DoubleQuestion;
                            if (CurrentChar == '=')
                            {
                                GoNextChar();
                                CurrentToken = Token.DoubleQuestionAndEqual;
                            }
                        }
                        else
                        {
                            CurrentToken = Token.SingleQuestion;
                        }
                        return;
                    case ':':
                        GoNextChar();
                        CurrentToken = Token.SingleColon;
                        return;
                    case '|':
                        GoNextChar();
                        if (CurrentChar == '|')
                        {
                            GoNextChar();
                            CurrentToken = Token.DoublePipe;
                        }
                        else if (CurrentChar == '=')
                        {
                            GoNextChar();
                            CurrentToken = Token.SinglePipeAndEqual;
                        }
                        else
                        {
                            CurrentToken = Token.SinglePipe;
                        }
                        return;
                    case '^':
                        GoNextChar();
                        CurrentToken = Token.SingleCaret;
                        if (CurrentChar == '=')
                        {
                            GoNextChar();
                            CurrentToken = Token.SingleCaretAndEqual;
                        }
                        return;
                    case '~':
                        GoNextChar();
                        CurrentToken = Token.SingleTilde;
                        return;

                    case '!':
                        GoNextChar();
                        if (CurrentChar == '=')
                        {
                            GoNextChar();
                            if (CurrentChar == '=')
                            {
                                GoNextChar();
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
                        GoNextChar();
                        if (CurrentChar == '=')
                        {
                            GoNextChar();
                            if (CurrentChar == '=')
                            {
                                GoNextChar();
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
                        GoNextChar();
                        if (CurrentChar == '>')
                        {
                            GoNextChar();
                            CurrentToken = Token.DoubleGreaterThan;
                            if (CurrentChar == '=')
                            {
                                GoNextChar();
                                CurrentToken = Token.DoubleGreaterThanAndEqual;
                            }
                        }
                        else if (CurrentChar == '=')
                        {
                            GoNextChar();
                            CurrentToken = Token.SingleGreaterThanAndEqual;
                        }
                        else
                        {
                            CurrentToken = Token.SingleGreaterThan;
                        }
                        return;

                    case '<':
                        GoNextChar();
                        if (CurrentChar == '<')
                        {
                            GoNextChar();
                            CurrentToken = Token.DoubleLessThan;
                            if (CurrentChar == '=')
                            {
                                GoNextChar();
                                CurrentToken = Token.DoubleLessThanAndEqual;
                            }
                        }
                        else if (CurrentChar == '=')
                        {
                            GoNextChar();
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
                            this.TokenString = this.ReadIdentifier();

                            this.CurrentToken = this.ReadKeyword(TokenString);
                        }
                        else
                        {
                            GoNextChar();
                        }
                        return;
                }
            }
        }

        private void ReadNumber()
        {
            if (this.CurrentChar == '0')
            {
                if (this.NextChar == 'x' || this.NextChar == 'X')
                {
                    this.CurrentToken = Token.Hexadecimal;
                    this.SkipChar(2);
                }
                else if (this.NextChar == 'b' || this.NextChar == 'b')
                {
                    this.CurrentToken = Token.Binary;
                    this.SkipChar(2);
                }
                else if (char.IsDigit(this.NextChar))
                {
                    this.CurrentToken = Token.Octal;
                }
                else
                {
                    this.CurrentToken = Token.NonFloatingDecimal;
                }
            }
            else
            {
                this.CurrentToken = Token.NonFloatingDecimal;
            }

            // Capture digits/decimal point
            StringBuilder StringBuilder = new StringBuilder();

            bool HaveDecimalPoint = false;
            while (true)
            {
                char CurrentChar = this.CurrentChar;

                if (this.CurrentToken == Token.NonFloatingDecimal || this.CurrentToken == Token.FloatingDecimal)
                {
                    if (char.IsDigit(CurrentChar))
                    {
                        StringBuilder.Append(CurrentChar);
                        GoNextChar();
                    }
                    else if (CurrentChar == '.' && !HaveDecimalPoint)
                    {
                        this.CurrentToken = Token.FloatingDecimal;
                        HaveDecimalPoint = true;
                        StringBuilder.Append(CurrentChar);
                        GoNextChar();
                    }
                    else break;
                }
                else if (this.CurrentToken == Token.Binary)
                {
                    if (CurrentChar == '0' || CurrentChar == '1')
                    {
                        StringBuilder.Append(CurrentChar);
                        GoNextChar();
                    }
                    else break;
                }
                else if (this.CurrentToken == Token.Hexadecimal)
                {
                    if (char.IsDigit(CurrentChar) ||
                        (CurrentChar >= 'a' && CurrentChar <= 'f') ||
                        (CurrentChar >= 'A' && CurrentChar <= 'F'))
                    {
                        StringBuilder.Append(CurrentChar);
                        GoNextChar();
                    }
                    else break;
                }
                else if (this.CurrentToken == Token.Octal)
                {
                    if (char.IsDigit(CurrentChar))
                    {
                        StringBuilder.Append(CurrentChar);
                        GoNextChar();
                    }
                    else break;
                }
            }

            string NumberString = StringBuilder.ToString();

            // Parse it
            this.TokenString = NumberString;
        }

        private string ReadIdentifier()
        {
            StringBuilder StringBuilder = new StringBuilder();

            // Accept letter, digit or underscore
            while (char.IsLetterOrDigit(CurrentChar) || CurrentChar == '_')
            {
                StringBuilder.Append(CurrentChar);
                GoNextChar();
            }

            return StringBuilder.ToString();
        }

        private Token ReadKeyword(string Identifier)
        {
            switch (Identifier.ToLower())
            {
                case "true": return Token.KeywordTrue;
                case "false": return Token.KeywordFalse;
                case "new": return Token.KeywordNew;
                case "char": return Token.KeywordChar;
                case "string": return Token.KeywordString;
                case "bool": return Token.KeywordBoolean;
                case "byte": return Token.KeywordByte;
                case "sbyte": return Token.KeywordSByte;
                case "short": return Token.KeywordShort;
                case "ushort": return Token.KeywordUShort;
                case "int": return Token.KeywordInt;
                case "uint": return Token.KeywordUInt;
                case "long": return Token.KeywordLong;
                case "ulong": return Token.KeywordULong;
                case "double": return Token.KeywordDouble;
                case "float": return Token.KeywordFloat;
                case "decimal": return Token.KeywordDecimal;
                case "null": return Token.KeywordNull;
                case "if": return Token.KeywordIf;
                default: return Token.Identifier;
            }
        }
    }
}
