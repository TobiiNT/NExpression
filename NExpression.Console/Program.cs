using NExpression.Console;
using NExpression.Core.Commands;
using NExpression.Core.Contexts;
using NExpression.Core.Extensions;
using NExpression.Core.Helpers;
using NExpression.Core.Tokens;
using NExpression.Dependencies.Lists;
using NExpression.Dependencies.Maths;
using System.Runtime.InteropServices;
using System.Text;

[DllImport("kernel32.dll")]
static extern bool SetConsoleOutputCP(uint wCodePageID);
SetConsoleOutputCP(65001);
Console.OutputEncoding = Encoding.UTF8;

var MathContext = new DynamicContext("MathContext");
ResetContext();

void ResetContext()
{
    MathContext = new DynamicContext("MathContext");
    MathContext.RegisterOperation<MathAbs>("Abs");
    MathContext.RegisterOperation<CreateList>("List");
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
        int CommandIndex = 1;
        SingleCommand? CurrentCommand = null;
        try
        {
            PrintTokens(InputExpression);

            List<SingleCommand> Commands = CommandHelpers.ParseMultiple(InputExpression, MathContext);
            foreach (var SingleCommand in Commands)
            {
                SingleCommand.Parse();

                PrintTraverse(SingleCommand);

                var NodeValue = SingleCommand.Evaluate();
                Consoler.WriteLine($"[Command {CommandIndex}] Expression  = {SingleCommand.RawExpression}", ConsoleColor.Blue);
                Consoler.WriteLine($"[Command {CommandIndex}] Result      = {NodeValue}", ConsoleColor.Green);
                CommandIndex++;
            }
        }
        catch (Exception Exception)
        {
            Consoler.WriteLine($"[Command {CommandIndex}] Expression  = {CurrentCommand?.RawExpression}", ConsoleColor.Red);
            Consoler.WriteLine($"[Command {CommandIndex}] Error       = {Exception.Message}", ConsoleColor.Red);
            if (Exception.InnerException != null)
            {
                Consoler.WriteLine($"[Command {CommandIndex}] Inner Error = [{Exception.InnerException?.Message}]", ConsoleColor.Red);
            }
        }
        Consoler.WriteLine();
    }
}

static void PrintTraverse(SingleCommand Command)
{
    Consoler.WriteLine();
    Consoler.Write($"Traverse : ", ConsoleColor.Blue);
    Consoler.WriteLine(Command.RawExpression);

    var Stacks = Command.Traverse();

    int LineNumber = 1;
    foreach (var Node in Stacks)
    {
        string? Identity = Node.Identity();

        Consoler.WriteLine($"[Step {LineNumber}] => {Identity}", ConsoleColor.Cyan);

        LineNumber++;
    }
}

static void PrintTokens(string? Expression)
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

