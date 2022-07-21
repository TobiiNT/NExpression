using NExpression.Console;
using NExpression.Core.Commands;
using NExpression.Core.Contexts;
using NExpression.Core.Extensions;
using NExpression.Core.Helpers;
using NExpression.Core.Tokens;
using System.Runtime.InteropServices;
using System.Text;

[DllImport("kernel32.dll")]
static extern bool SetConsoleOutputCP(uint wCodePageID);
SetConsoleOutputCP(65001);
Console.OutputEncoding = Encoding.UTF8;

var MathContext = CreateThreeLevelContext();
ResetContext();

void ResetContext()
{
    MathContext = CreateThreeLevelContext();
}

bool IsPrintTokens = false;
bool IsPrintTraverse = true;

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
        WriteAllVariale(MathContext, "", 0);
    }
    else
    {
        int CommandIndex = 1;
        SingleCommand? CurrentCommand = null;
        try
        {
            if (IsPrintTokens) { PrintTokens(InputExpression); }

            List<SingleCommand> Commands = CommandHelpers.ParseMultiple(InputExpression, MathContext);
            foreach (var SingleCommand in Commands)
            {
                SingleCommand.Parse();

                if (IsPrintTraverse) { PrintTraverse(SingleCommand); }

                var NodeValue = SingleCommand.Evaluate();
                
                Consoler.WriteLine($"[Command {CommandIndex}] Expression  = {SingleCommand.RawExpression ?? "null"}", ConsoleColor.Blue);
                Consoler.WriteLine($"[Command {CommandIndex}] Result      = {NodeValue.Identity()}", ConsoleColor.Green);
                CommandIndex++;
            }

            //WriteAllVariale(MathContext, "", 0);
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

        Consoler.Write($"[Step {LineNumber}] => ", ConsoleColor.White);
        Consoler.Write($"{Identity} = ", ConsoleColor.White);
        Consoler.Write($"{Node.Evaluate()}", ConsoleColor.Green);
        Consoler.WriteLine();
      
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

static void WriteAllVariale(DynamicContext Context, string Parent, int Level)
{
    var AllVariables = Context.GetAllVariables();

    for (int i = 0; i < Level; i++)
    {
        Console.Write("   ");
    }
    Consoler.WriteLine($"+ [{Context.Name}] Total variables = {AllVariables.Count}", ConsoleColor.Cyan);

    int CurrentLevel = Level;
    foreach (var Variable in AllVariables)
    {
        if (Variable.Value is DynamicContext InnerContext)
        {
            for (int i = 0; i < CurrentLevel; i++)
            {
                Console.Write("   ");
            }
            Consoler.WriteLine($"+ [{Variable.Key}] => Context", ConsoleColor.Green);
            WriteAllVariale(InnerContext, Context.Name, CurrentLevel + 1);
        }
        else
        {
            for (int i = 0; i < CurrentLevel; i++)
            {
                Console.Write("   ");
            }
            Consoler.WriteLine($"+ [{Variable.Key}] => {Variable.Value}", ConsoleColor.Blue);
        }
    }
}

static DynamicContext CreateThreeLevelContext()
{
    var Number = new DynamicContext("Number");
    Number["Name"] = "Number";

    var Floating = new DynamicContext("Floating");
    Floating["Name"] = "Floating";

    var NonFloating = new DynamicContext("NonFloating");
    NonFloating["Name"] = "NonFloating";

    var Double = new DynamicContext("Double");
    Double["Name"] = typeof(double);
    Double["Value"] = double.MaxValue;

    var Decimal = new DynamicContext("Decimal");
    Decimal["Name"] = typeof(decimal);
    Decimal["Value"] = decimal.MaxValue;

    var Integer = new DynamicContext("Integer");
    Integer["Name"] = typeof(int);
    Integer["Value"] = int.MaxValue;

    var Long = new DynamicContext("Long");
    Long["Name"] = typeof(long);
    Long["Value"] = long.MaxValue;

    Floating["doubleNum"] = Double;
    Floating["decimalNum"] = Decimal;

    NonFloating["intNum"] = Integer;
    NonFloating["longNum"] = Long;

    Number["Floating"] = Floating;
    Number["NonFloating"] = NonFloating;

    return Number;
}