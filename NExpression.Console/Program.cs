using NExpression.Console;
using NExpression.Core.Commands;
using NExpression.Core.Contexts;
using NExpression.Core.Extensions;
using NExpression.Core.Helpers;
using NExpression.Core.Tokens;
using NExpression.Dependencies.Maths;
using System.Runtime.InteropServices;
using System.Text;

[DllImport("kernel32.dll")]
static extern bool SetConsoleOutputCP(uint wCodePageID);
SetConsoleOutputCP(65001);
Console.OutputEncoding = Encoding.UTF8;

//NExpressionCreateAndEvaluateTest();

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
        PrintAllVariables.Print(MathContext, 0);
    }
    else
    {
        int CommandIndex = 1;
        SingleCommand? CurrentCommand = null;
        try
        {
            if (IsPrintTokens) { PrintTokens.Print(InputExpression); }

            List<SingleCommand> Commands = CommandHelpers.ParseMultiple(InputExpression, MathContext);
            foreach (var SingleCommand in Commands)
            {
                CurrentCommand = SingleCommand;

                SingleCommand.Parse();

                if (IsPrintTraverse) { PrintTraverse.Print(SingleCommand); }

                var NodeValue = SingleCommand.Evaluate();

                try
                {
                    Consoler.WriteLine($"[Command {CommandIndex}] Expression  = {SingleCommand.RawExpression ?? "null"}", ConsoleColor.Blue);
                    Consoler.WriteLine($"[Command {CommandIndex}] Result      = {NodeValue.Identity()}", ConsoleColor.Green);
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

static DynamicContext CreateThreeLevelContext()
{
    var Number = new DynamicContext("Number");
    Number.RegisterOperation<MathAbs>("numAbs");
    Number["Name"] = "Number";

    var Floating = new DynamicContext("Floating");
    Floating.RegisterOperation<MathAbs>("floatAbs");
    Floating["Name"] = "Floating";

    var NonFloating = new DynamicContext("NonFloating");
    NonFloating.RegisterOperation<MathAbs>("nonFloatAbs");
    NonFloating["Name"] = "NonFloating";

    var Double = new DynamicContext("Double");
    Double.RegisterOperation<MathAbs>("doubleAbs");
    Double["Name"] = typeof(double);
    Double["Value"] = double.MaxValue;

    var Decimal = new DynamicContext("Decimal");
    Decimal.RegisterOperation<MathAbs>("decimalAbs");
    Decimal["Name"] = typeof(decimal);
    Decimal["Value"] = decimal.MaxValue;

    var Integer = new DynamicContext("Integer");
    Integer.RegisterOperation<MathAbs>("integerAbs");
    Integer["Name"] = typeof(int);
    Integer["Value"] = int.MaxValue;

    var Long = new DynamicContext("Long");
    Long.RegisterOperation<MathAbs>("longAbs");
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

static Dictionary<string, object?> NExpressionCreateAndEvaluateTest()
{
    var Context = new DynamicContext();
    ExpressionHelpers.Parse($"a = 0", Context).Evaluate();
    ExpressionHelpers.Parse($"b = 1", Context).Evaluate();
    ExpressionHelpers.Parse($"c = 1", Context).Evaluate();

    Dictionary<string, object?> Values = new Dictionary<string, object?>(1000000);
    for (int i = 0; i < 1000000; i++)
    {
        ExpressionHelpers.Parse($"a = b", Context).Evaluate();
        ExpressionHelpers.Parse($"b = c", Context).Evaluate();
        ExpressionHelpers.Parse($"c = a + b", Context).Evaluate();
        ExpressionHelpers.Parse($"c{i} = c", Context).Evaluate();
        object? Value = ExpressionHelpers.Parse($"c{i}", Context).Evaluate();
        Values.Add($"c{i}", Value);
    }
    return Values;
}