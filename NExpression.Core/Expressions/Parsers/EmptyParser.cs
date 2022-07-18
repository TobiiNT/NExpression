using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Expressions.Parsers.Interfaces;
using NExpression.Core.Tokens;

namespace NExpression.Core.Expressions.Parsers
{
    internal class EmptyParser : IParser
    {
        public Tokenizer Tokenizer => throw new NotImplementedException();
        public IParser NextParser { private set; get; }
        public IContext Context => throw new NotImplementedException();

        public EmptyParser(IParser NextParser)
        {
            this.NextParser = NextParser;
        }

        public INode Parse<T>() => NextParser.Parse<T>();
    }
}
