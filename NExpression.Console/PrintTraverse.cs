using NExpression.Core.Commands;
using NExpression.Core.Contexts;
using NExpression.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NExpression.Console
{
    public static class PrintTraverse
    {
        public static void Print(SingleCommand Command)
        {
            Consoler.WriteLine();
            Consoler.Write($"Traverse : ", ConsoleColor.Blue);
            Consoler.WriteLine(Command.RawExpression);

            var Stacks = Command.Traverse();

            int LineNumber = 1;
            foreach (var Node in Stacks)
            {
                string? Identity = Node.Identity();

                Consoler.Write($"[Step {LineNumber}] => ", ConsoleColor.White);
                Consoler.Write($"{Identity}", ConsoleColor.White);
                try
                {
                    //Consoler.Write($" = {Node.Evaluate()}", ConsoleColor.Green);
                }
                catch (Exception Exception)
                {
                    Consoler.Write($" => {Exception.Message}", ConsoleColor.Red);
                    break;
                }
                finally
                {
                    Consoler.WriteLine();
                    LineNumber++;
                }
            }
        }

    }
}
