using NExpression.Core.Commands;
using NExpression.Core.Contexts;
using NExpression.Core.Extensions;
using NExpression.Core.Helpers;
using NExpression.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NExpression.Console
{
    public static class PrintTokens
    {
        public static void Print(string? Expression)
        {
            Consoler.WriteLine();
            Consoler.Write($"Print tokens : ", ConsoleColor.Blue);
            Consoler.WriteLine(Expression);

            var Tokens = TokenHelpers.Parse(Expression);

            int LineNumber = 1;
            do
            {
                Consoler.WriteLine($"[Token {LineNumber++}] {Tokens.Token.Symbol()} ", ConsoleColor.Cyan);
                Tokens.NextToken();
            }
            while (Tokens.Token != Token.EOF);
        }

    }
}
