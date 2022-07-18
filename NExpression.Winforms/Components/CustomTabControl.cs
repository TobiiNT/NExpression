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
    public partial class CustomTabControl : UserControl
    {
        public CustomTabControl()
        {
            InitializeComponent();
        }

        public void AddTab(object TabKey, string TabName)
        {
            TabPage TabPage = new TabPage()
            {
                Name = "TabPage " + TabKey,
                Text = TabName,
                BackColor = SystemColors.Control,
                Tag = TabKey,
            };

            CustomRichTextBox Textbox = new CustomRichTextBox()
            {
                Name = "Textbox " + TabKey,
                Dock = DockStyle.Fill,
                Tag = TabKey,
            };

            TabPage.Controls.Add(Textbox);

            this.TabControl.TabPages.Add(TabPage);
            this.TabControl.SelectedIndex = TabControl.TabPages.Count - 1;
        }

        public object GetCurrentTabTag()
        {
            if (this.TabControl.TabPages.Count > 0)
            {
                var SelectedTab = this.TabControl.SelectedTab;

                return SelectedTab.Tag;
            }
            return "";
        }
        public string GetCurrentTabTextBoxValue()
        {
            if (this.TabControl.TabPages.Count > 0)
            {
                var SelectedTab = this.TabControl.SelectedTab;

                return GetTextboxValue(SelectedTab.Tag);
            }
            return "";
        }
        public string GetTextboxValue(object Key)
        {
            var TabPage = this.TabControl.TabPages["TabPage " + Key];
            var Textbox = TabPage.Controls["TextBox " + Key];

            if (Textbox is CustomRichTextBox CustomTextBox)
                return CustomTextBox.GetText();
            return "";
        }
    }
}
