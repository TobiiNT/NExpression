using NExpression.Core.Commands;
using NExpression.Core.Contexts.Interfaces;

namespace NExpression.Core.Helpers
{
    public static class CommandHelpers
    {
        public static List<SingleCommand> ParseMultiple(string LongExpressionString, IContext? ReadContext = null)
        {
            List<SingleCommand> Results = new List<SingleCommand>();

            if (LongExpressionString != null)
            {
                string[] Expressions = LongExpressionString.Split(';');

                foreach (string RawExpression in Expressions)
                {
                    string TrimmedExpression = RawExpression.Trim();

                    if (TrimmedExpression != string.Empty)
                    {
                        SingleCommand Tuple = new SingleCommand(ReadContext, TrimmedExpression);

                        Results.Add(Tuple);
                    }
                }
            }

            return Results;
        }
    }
}
