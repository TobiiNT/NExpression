using NExpression.Core.Exceptions;
using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Nodes.NodeDatas.Strings;
using NExpression.Core.Expressions.Parsers.Interfaces;
using NExpression.Core.Tokens;
using System.Text;

namespace NExpression.Core.Expressions.Parsers
{
    internal class CharacterParser : IParser
    {
        public Tokenizer Tokenizer { private set; get; }
        public IParser NextParser { private set; get; }
        public List<Token> MaskToken { private set; get; }

        public CharacterParser(Tokenizer Tokenizer, IParser NextParser, List<Token> MaskToken)
        {
            this.Tokenizer = Tokenizer;
            this.NextParser = NextParser;
            this.MaskToken = MaskToken;
        }

        public INode Parse<T>()
        {
            var LeftNode = NextParser.Parse<T>();

            while (true)
            {
                Token CurrentToken = Tokenizer.Token;

                if (MaskToken.Contains(CurrentToken))
                {
                    if (CurrentToken == Token.DoubleQuote)
                    {
                        StringBuilder StringValue = new StringBuilder();
                        while (true)
                        {
                            Tokenizer.NextToken();

                            if (Tokenizer.Token == Token.EOF)
                                throw new ExpressionSyntaxException("Missing close parenthesis");

                            if (Tokenizer.Token == Token.DoubleQuote)
                                break;

                            StringValue.Append(Tokenizer.TokenString);
                        }
                        Tokenizer.NextToken();

                        return new NodeString(StringValue.ToString());
                    }
                    else if (CurrentToken == Token.SingleQuote)
                    {
                        char Value = '\u0000';
                        while (true)
                        {
                            Tokenizer.NextToken();

                            if (Tokenizer.Token == Token.EOF)
                                throw new ExpressionSyntaxException("Missing close parenthesis");

                            if (Tokenizer.Token == Token.SingleQuote)
                            {
                                break;
                            }
                            else if (Value != '\u0000')
                            {
                                throw new InvalidCastException("Cannot cast value to char");
                            }

                            if (!char.TryParse(Tokenizer.TokenString, out Value))
                            {
                                throw new InvalidCastException("Cannot cast value to char");
                            }
                        }
                        Tokenizer.NextToken();

                        return new NodeChar(Value);
                    }
                }
                else return LeftNode;
            }
        }
    }
}
