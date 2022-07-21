using System.Linq;

namespace NExpression.Winforms.Components
{
    public partial class CustomTabControl : UserControl
    {
        public CustomTabControl()
        {
            InitializeComponent();
        }

        public CustomTabPage? GetTabByFileName(string FileName)
        {
            foreach (CustomTabPage Tab in this.TabControl.TabPages)
            {
                if (Tab.FilePath == FileName)
                    return Tab;
            }
            return null;
        }

        public void FocusTab(CustomTabPage Tab)
        {
            this.TabControl.SelectedTab = this.TabControl.TabPages[Tab.Name];
        }

        public CustomTabPage AddTab(string Identity, string TabName, string TabContent = "")
        {
            CustomTabPage TabPage = new CustomTabPage(Identity)
            {
                Name = "TabPage " + Identity,
                Title = TabName,
                BackColor = SystemColors.Control,
            };
            TabPage.CurrentContent = TabContent;

            this.TabControl.TabPages.Add(TabPage);
            this.TabControl.SelectedIndex = TabControl.TabPages.Count - 1;

            return TabPage;
        }

        public CustomTabPage? GetCurrentTab()
        {
            if (this.TabControl.TabPages.Count > 0)
            {
                return (CustomTabPage)this.TabControl.SelectedTab;
            }
            return null;
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
