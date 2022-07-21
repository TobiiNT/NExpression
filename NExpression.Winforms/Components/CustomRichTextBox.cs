using NExpression.Winforms.Components.Delegates;
using NExpression.Winforms.Extensions;
using System.Text;
using System.Text.RegularExpressions;

namespace NExpression.Winforms.Components
{
    public partial class CustomRichTextBox : UserControl
    {
        public List<Tuple<int, int>> FormattingPhase = new List<Tuple<int, int>>();
        public RichTextBox CurrentTextBox => this.TextBoxText;

        private CustomTabPage Parent { get; }
        public CustomRichTextBox(CustomTabPage Parent)
        {
            InitializeComponent();

            this.Parent = Parent;
        }

        #region Custom
        public int GetWidth()
        {
            int Width;

            int TotalLines = TextBoxText.Lines.Length;

            if (TotalLines <= 99)
            {
                Width = 20 + (int)TextBoxText.Font.Size;
            }
            else if (TotalLines <= 999)
            {
                Width = 30 + (int)TextBoxText.Font.Size;
            }
            else
            {
                Width = 50 + (int)TextBoxText.Font.Size;
            }

            return Width;
        }

        public void AddLineNumbers()
        {
            Point BasePoint = new Point(0, 0);
            // get First Index & First Line from richTextBox1    
            int FirstIndex = TextBoxText.GetCharIndexFromPosition(BasePoint);
            int FirstLine = TextBoxText.GetLineFromCharIndex(FirstIndex);
            // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    
            BasePoint.X = ClientRectangle.Width;
            BasePoint.Y = ClientRectangle.Height;
            // get Last Index & Last Line from richTextBox1    
            int LastIndex = TextBoxText.GetCharIndexFromPosition(BasePoint);
            int LastLine = TextBoxText.GetLineFromCharIndex(LastIndex);
            // set Center alignment to LineNumberTextBox    
            TextBoxLineNumber.SelectionAlignment = HorizontalAlignment.Center;
            // set LineNumberTextBox text to null & width to getWidth() function value    
            TextBoxLineNumber.Text = "";
            TextBoxLineNumber.Width = GetWidth();
            // now add each line number to LineNumberTextBox upto last line    
            var StringBuilder = new StringBuilder(LastLine * 3);
            for (int i = FirstLine; i <= LastLine + 1; i++)
            {
                StringBuilder.Append(i + 1 + "\n");
            }
            TextBoxLineNumber.Text = StringBuilder.ToString();
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
            this.TextBoxText.ForeColor = Color.Black;
            this.CheckCaret();
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
            this.Parent.TextboxContentChanged();
            
            this.TextBoxText.ForeColor = Color.Black;
            this.FormatColor();
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
        #endregion

        public string CurrentContent
        {
            get => TextBoxText.Text;
            set => TextBoxText.Text = value;
        }
    }
}
