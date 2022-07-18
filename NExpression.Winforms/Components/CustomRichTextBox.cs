using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NExpression.Winforms.Components
{
    public partial class CustomRichTextBox : UserControl
    {
        public CustomRichTextBox()
        {
            InitializeComponent();
        }

        public int getWidth()
        {
            int w = 25;
            // get total lines of richTextBox1    
            int line = TextBoxText.Lines.Length;

            if (line <= 99)
            {
                w = 20 + (int)TextBoxText.Font.Size;
            }
            else if (line <= 999)
            {
                w = 30 + (int)TextBoxText.Font.Size;
            }
            else
            {
                w = 50 + (int)TextBoxText.Font.Size;
            }

            return w;
        }

        public void AddLineNumbers()
        {
            // create & set Point pt to (0,0)    
            Point pt = new Point(0, 0);
            // get First Index & First Line from richTextBox1    
            int First_Index = TextBoxText.GetCharIndexFromPosition(pt);
            int First_Line = TextBoxText.GetLineFromCharIndex(First_Index);
            // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    
            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height;
            // get Last Index & Last Line from richTextBox1    
            int Last_Index = TextBoxText.GetCharIndexFromPosition(pt);
            int Last_Line = TextBoxText.GetLineFromCharIndex(Last_Index);
            // set Center alignment to LineNumberTextBox    
            TextBoxLineNumber.SelectionAlignment = HorizontalAlignment.Center;
            // set LineNumberTextBox text to null & width to getWidth() function value    
            TextBoxLineNumber.Text = "";
            TextBoxLineNumber.Width = getWidth();
            // now add each line number to LineNumberTextBox upto last line    
            for (int i = First_Line; i <= Last_Line + 1; i++)
            {
                TextBoxLineNumber.Text += i + 1 + "\n";
            }
        }

        private void LineNumberRichTextBox_Load(object sender, EventArgs e)
        {
            TextBoxLineNumber.Font = TextBoxText.Font;
            TextBoxText.Select();
            AddLineNumbers();
        }

        private void LineNumberRichTextBox_Resize(object sender, EventArgs e)
        {
            AddLineNumbers();
        }

        private void TextBoxText_SelectionChanged(object sender, EventArgs e)
        {
            Point pt = TextBoxText.GetPositionFromCharIndex(TextBoxText.SelectionStart);
            if (pt.X == 1)
            {
                AddLineNumbers();
            }
        }

        private void TextBoxText_VScroll(object sender, EventArgs e)
        {
            TextBoxLineNumber.Text = "";
            AddLineNumbers();
            TextBoxLineNumber.Invalidate();
        }

        private void TextBoxText_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxText.Text == "")
            {
                AddLineNumbers();
            }
        }

        private void TextBoxText_FontChanged(object sender, EventArgs e)
        {
            TextBoxLineNumber.Font = TextBoxText.Font;
            TextBoxText.Select();
            AddLineNumbers();
        }

        private void TextBoxLineNumber_MouseDown(object sender, MouseEventArgs e)
        {
            TextBoxText.Select();
            TextBoxLineNumber.DeselectAll();
        }

        public string GetText() => TextBoxText.Text;
    }
}
