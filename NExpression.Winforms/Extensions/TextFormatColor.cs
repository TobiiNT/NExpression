using NExpression.Winforms.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NExpression.Winforms.Extensions
{
    internal static class TextFormatColor
    {
        public static Dictionary<string, Color> TextFormatColors = new Dictionary<string, Color>()
        {
            { "while", Color.Blue },
            { "for", Color.Blue },
            { "foreach", Color.Blue },
            { "if", Color.Blue },
            { "else", Color.Blue },
            { "try", Color.Blue },
            { "catch", Color.Blue },
            { "true", Color.Blue },
            { "false", Color.Blue },
            { "new", Color.Blue },
            { "null", Color.Blue },
            { "Char", Color.Green },
            { "String", Color.Green },
            { "Boolean", Color.Green },
            { "Byte", Color.Green },
            { "SByte", Color.Green },
            { "Short", Color.Green },
            { "UShort ", Color.Green },
            { "Int", Color.Green },
            { "UInt", Color.Green },
            { "Long", Color.Green },
            { "ULong", Color.Green },
            { "Double", Color.Green },
            { "Float", Color.Green },
            { "Decimal", Color.Green },
            { "char", Color.Blue },
            { "string", Color.Blue },
            { "boolean", Color.Blue },
            { "byte", Color.Blue },
            { "sbyte", Color.Blue },
            { "short", Color.Blue },
            { "ushort ", Color.Blue },
            { "int", Color.Blue },
            { "uInt", Color.Blue },
            { "long", Color.Blue },
            { "ulong", Color.Blue },
            { "double", Color.Blue },
            { "float", Color.Blue },
            { "decimal", Color.Blue }
        };
        public static void CheckCaret(this CustomRichTextBox TextBox)
        {
            RichTextBox TextBoxText = TextBox.CurrentTextBox;

            System.Diagnostics.Debug.WriteLine("Caret " + TextBoxText.SelectionStart);
        }
        public static void FormatColor(this CustomRichTextBox TextBox)
        {
            RichTextBox TextBoxText = TextBox.CurrentTextBox;

            int CurrentCaret = TextBoxText.SelectionStart;
            foreach (var Phase in TextBoxText.Text.Split(' '))
            {
                if (TextFormatColors.TryGetValue(Phase, out Color Color))
                {
                    var matchString = Regex.Escape(Phase);
                    foreach (Match match in Regex.Matches(TextBoxText.Text, matchString))
                    {
                        if (!TextBox.FormattingPhase.Contains(new Tuple<int, int>(match.Index, Phase.Length)))
                        {
                            TextBoxText.Select(match.Index, Phase.Length);
                            TextBoxText.SelectionColor = Color;
                            TextBoxText.Select(CurrentCaret, 0);

                            bool IsInside = match.Index <= CurrentCaret && CurrentCaret <= match.Index + Phase.Length;

                            if (!IsInside)
                            {
                                TextBoxText.SelectionColor = TextBoxText.ForeColor;
                            }
                        }
                    };
                }
                else
                {
                    var matchString = Regex.Escape(Phase);
                    foreach (Match match in Regex.Matches(TextBoxText.Text, matchString))
                    {
                        var Tuple = new Tuple<int, int>(match.Index, Phase.Length);
                        if (TextBox.FormattingPhase.Contains(Tuple))
                        {
                            TextBoxText.Select(match.Index, Phase.Length);
                            TextBoxText.SelectionColor = TextBoxText.ForeColor;

                            TextBoxText.Select(CurrentCaret, 0);
                            TextBoxText.SelectionColor = TextBoxText.ForeColor;

                            TextBox.FormattingPhase.Add(Tuple);
                        }
                    };
                }
            }
        }
    }
}
