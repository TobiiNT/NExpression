using NExpression.Winforms.Components.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NExpression.Winforms.Components
{
    public partial class CustomTabPage : TabPage
    {
        private CustomRichTextBox TextBoxContent { get; }
        public string Identity { get; set; }

        private string _Title;
        public string Title
        {
            get => this._Title;
            set
            {
                this._Title = value;
                this.TextboxContentChanged();
            }
        }
        public bool IsModified { get; private set; }

        public CustomTabPage(string Identity)
        {
            this.Identity = Identity;
            this.TextBoxContent = new CustomRichTextBox(this)
            {
                Dock = DockStyle.Fill,
            };

            this.Controls.Add(TextBoxContent);
        }

        public void TextboxContentChanged()
        {
            this.IsModified = CurrentContent != SavedContent;

            this.Text = this.Title + (IsModified ? "*" : "");
        }

        private string? SavedContent { set; get; }
        public string CurrentContent
        {
            get => TextBoxContent.CurrentContent;
            set => TextBoxContent.CurrentContent = value;
        }


        public string? FilePath { private set; get; }
        public void SetFileName(string FilePath)
        {
            var Info = new FileInfo(FilePath);

            this.Title = Info.Name;
            this.FilePath = FilePath;
        }

        public void OpenContent(string? FilePath)
        {
            if (FilePath != null)
            {
                string Content = File.ReadAllText(FilePath);

                this.SetFileName(FilePath);
                this.CurrentContent = Content;
            }
        }

        public bool SaveContent(string? NewFilePath = null)
        {
            if (NewFilePath != null)
            {
                this.SetFileName(NewFilePath);
            }
            if (this.FilePath != null)
            {
                File.WriteAllText(FilePath, this.CurrentContent);
                this.SavedContent = this.CurrentContent;
                this.TextboxContentChanged();
                return true;
            }
            return false;
        }
    }
}
