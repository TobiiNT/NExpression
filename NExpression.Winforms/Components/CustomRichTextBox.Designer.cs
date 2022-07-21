namespace NExpression.Winforms.Components
{
    partial class CustomRichTextBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TextBoxLineNumber = new System.Windows.Forms.RichTextBox();
            this.TextBoxText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // TextBoxLineNumber
            // 
            this.TextBoxLineNumber.BackColor = System.Drawing.SystemColors.Control;
            this.TextBoxLineNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxLineNumber.Cursor = System.Windows.Forms.Cursors.PanNE;
            this.TextBoxLineNumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.TextBoxLineNumber.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TextBoxLineNumber.ForeColor = System.Drawing.Color.Olive;
            this.TextBoxLineNumber.Location = new System.Drawing.Point(0, 0);
            this.TextBoxLineNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TextBoxLineNumber.Name = "TextBoxLineNumber";
            this.TextBoxLineNumber.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.TextBoxLineNumber.Size = new System.Drawing.Size(26, 446);
            this.TextBoxLineNumber.TabIndex = 1;
            this.TextBoxLineNumber.Text = "";
            this.TextBoxLineNumber.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TextBoxLineNumber_MouseDown);
            // 
            // TextBoxText
            // 
            this.TextBoxText.AcceptsTab = true;
            this.TextBoxText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxText.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TextBoxText.Location = new System.Drawing.Point(26, 0);
            this.TextBoxText.Name = "TextBoxText";
            this.TextBoxText.Size = new System.Drawing.Size(580, 446);
            this.TextBoxText.TabIndex = 2;
            this.TextBoxText.Text = "";
            this.TextBoxText.SelectionChanged += new System.EventHandler(this.TextBoxText_SelectionChanged);
            this.TextBoxText.VScroll += new System.EventHandler(this.TextBoxText_VScroll);
            this.TextBoxText.FontChanged += new System.EventHandler(this.TextBoxText_FontChanged);
            this.TextBoxText.TextChanged += new System.EventHandler(this.TextBoxText_TextChanged);
            // 
            // CustomRichTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TextBoxText);
            this.Controls.Add(this.TextBoxLineNumber);
            this.Name = "CustomRichTextBox";
            this.Size = new System.Drawing.Size(606, 446);
            this.Load += new System.EventHandler(this.LineNumberRichTextBox_Load);
            this.Resize += new System.EventHandler(this.LineNumberRichTextBox_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private RichTextBox TextBoxLineNumber;
        private RichTextBox TextBoxText;
    }
}
