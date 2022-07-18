using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Tokens;

namespace NExpression.Core.Expressions.Parsers.Interfaces
{
    public interface IParser
    {
        IParser NextParser { get; }
        Tokenizer Tokenizer { get; }
        INode Parse<T>();

    }
}
