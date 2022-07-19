using NExpression.Core.Contexts.Interfaces;
using NExpression.Core.Expressions;
using NExpression.Core.Expressions.Nodes.Interfaces;
using NExpression.Core.Helpers;

namespace NExpression.Core.Commands
{
    public class SingleCommand
    {
        public IContext? Context { get; }
        public string RawExpression { get; }
        private INode? ParsedNode { set; get; }

        public SingleCommand(IContext? Context, string RawExpression)
        {
            this.Context = Context;
            this.RawExpression = RawExpression.Trim();
        }

        public void Parse()
        {
            var Tokenizer = TokenHelpers.Parse(RawExpression);
            var CompleteExpression = new Expression(Tokenizer, Context);

            this.ParsedNode = CompleteExpression?.ParseExpression<object>();
        }

        public object? Evaluate() => this.ParsedNode?.Evaluate(Context);
        public object? Traverse() => this.ParsedNode?.Traverse();
    }
}
