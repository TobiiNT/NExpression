using NExpression.Core.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NExpression.Console
{
    public static class PrintAllVariables
    {
        public static void Print(DynamicContext Context, int Level)
        {
            var AllVariables = Context.GetAllVariables();

            for (int i = 0; i < Level; i++)
            {
                Consoler.Write("   ");
            }
            Consoler.WriteLine($"+ [{Context.Name}] Total variables = {AllVariables.Count}", ConsoleColor.Cyan);

            int CurrentLevel = Level;
            foreach (var Variable in AllVariables)
            {
                if (Variable.Value is DynamicContext InnerContext)
                {
                    for (int i = 0; i < CurrentLevel; i++)
                    {
                        Consoler.Write("   ");
                    }
                    Consoler.WriteLine($"+ [{Variable.Key}] => Context", ConsoleColor.Green);
                    PrintAllVariables.Print(InnerContext, CurrentLevel + 1);
                }
                else
                {
                    for (int i = 0; i < CurrentLevel; i++)
                    {
                        Consoler.Write("   ");
                    }
                    Consoler.WriteLine($"+ [{Variable.Key}] => {Variable.Value}", ConsoleColor.Blue);
                }
            }
        }

    }
}
