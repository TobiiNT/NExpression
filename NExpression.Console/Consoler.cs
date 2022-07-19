namespace NExpression.Console
{
    internal class Consoler
    {
        public static void WriteLine(string? Value = "", ConsoleColor Color = ConsoleColor.White)
        {
            if (Value == string.Empty)
            {
                System.Console.WriteLine();
            }
            else
            {
                System.Console.ForegroundColor = Color;
                System.Console.WriteLine(Value);
                System.Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void Write(string Value = "", ConsoleColor Color = ConsoleColor.White)
        {
            System.Console.ForegroundColor = Color;
            System.Console.Write(Value);
            System.Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
