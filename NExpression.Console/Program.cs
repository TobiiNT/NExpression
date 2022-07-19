using NExpression.Console;
using NExpression.Core.Commands;
using NExpression.Core.Contexts;
using NExpression.Core.Expressions.Nodes.NodeDatas;
using NExpression.Core.Extensions;
using NExpression.Core.Helpers;
using NExpression.Core.Tokens;
using NExpression.Maths;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

[DllImport("kernel32.dll")]
static extern bool SetConsoleOutputCP(uint wCodePageID);
SetConsoleOutputCP(65001);
Console.OutputEncoding = Encoding.UTF8;

var MathContext = new DynamicContext("MathContext");
ResetContext();

void ResetContext()
{
    MathContext = new DynamicContext("MathContext");
    MathContext.RegisterOperation<MathAbs>("abs");
    MathContext["PI"] = Math.PI;
    MathContext["E"] = Math.E;
}

while (true)
{
    Consoler.Write($"Your expression : ");
    string? InputExpression = Console.ReadLine();

    if (InputExpression == "!exit")
        break;

    if (InputExpression == "!clear")
    {
        Console.Clear();
        ResetContext();
    }
    else if (InputExpression == "!list")
    {
        Consoler.WriteLine();

        var AllVariables = MathContext.GetAllVariables();
        Consoler.WriteLine($"Total variables = {AllVariables.Count}", ConsoleColor.Green);
        foreach (var Variable in AllVariables)
        {
            Consoler.WriteLine($"- {Variable.Key} => {Variable.Value}", ConsoleColor.Blue);
        }
        Console.WriteLine();
    }
    else
    {
        Consoler.WriteLine();

        int CommandIndex = 1;
        SingleCommand? CurrentCommand = null;
        try
        {
            PrintTokens(InputExpression);

            List<SingleCommand> Commands = CommandHelpers.ParseMultiple(InputExpression, MathContext);
            foreach (var SingleCommand in Commands)
            {
                CurrentCommand = SingleCommand;

                CurrentCommand.Parse();

                PrintTraverse(SingleCommand);

                var NodeValue = CurrentCommand.Evaluate();

                Consoler.WriteLine($"[{CommandIndex}] Expression  = {CurrentCommand.RawExpression}", ConsoleColor.Blue);
                Consoler.WriteLine($"[{CommandIndex}] Result      = {NodeValue}", ConsoleColor.Green);
                CommandIndex++;
            }
        }
        catch (Exception Exception)
        {
            Consoler.WriteLine($"[{CommandIndex}] Expression  = {CurrentCommand?.RawExpression}", ConsoleColor.Red);
            Consoler.WriteLine($"[{CommandIndex}] Error       = {Exception.Message}", ConsoleColor.Red);
            if (Exception.InnerException != null)
            {
                Consoler.WriteLine($"[{CommandIndex}] Inner Error  = [{Exception.InnerException?.Message}]", ConsoleColor.Red);
            }
        }
        Consoler.WriteLine();
    }
}

static void PrintTraverse(SingleCommand Command)
{
    var Stacks = Command.Traverse();

    int LineNumber = 1;
    foreach (var Node in Stacks)
    {
        string? Identity = Node.Identity();

        Consoler.WriteLine($"Step {LineNumber} => {Identity}", ConsoleColor.Cyan);

        LineNumber++;
    }
}

static void PrintTokens(string Expression)
{
    var Tokens = TokenHelpers.Parse(Expression);
    Consoler.Write($"Tokens      = ", ConsoleColor.Cyan);
    do
    {
        Consoler.Write($"{Tokens.Token.Symbol()} ", ConsoleColor.Cyan);
        Tokens.NextToken();
    }
    while (Tokens.Token != Token.EOF);
}

