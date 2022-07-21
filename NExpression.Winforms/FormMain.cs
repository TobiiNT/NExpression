using NExpression.Core.Commands;
using NExpression.Core.Contexts;
using NExpression.Core.Helpers;
using NExpression.Winforms.Components;

namespace NExpression.Winforms
{
    public partial class FormMain : Form
    {
        public Dictionary<string, DynamicContext> Contexts { get; set; }

        public FormMain()
        {
            InitializeComponent();

            this.Contexts = new Dictionary<string, DynamicContext>();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            AddTab("New Tab");
        }

        private CustomTabPage AddTab(string TabName = "", string TabContent = "")
        {
            string Timestamp = DateTime.Now.Ticks.ToString();

            if (!this.Contexts.ContainsKey(Timestamp))
            {
                var Context = new DynamicContext("Context " + Timestamp);

                this.Contexts.Add(Timestamp, Context);

                return this.TabControlMain.AddTab(Timestamp, TabName, TabContent);
            }
            return null;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTab("New Tab");
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var CurrentTab = TabControlMain.GetCurrentTab();

            if (CurrentTab != null && this.Contexts.TryGetValue(CurrentTab.Identity, out DynamicContext Context))
            {
                string? InputExpressions = CurrentTab.CurrentContent;

                Execute(InputExpressions, Context);
            }
        }

        private void Execute(string InputExpressions, DynamicContext Context)
        {
            int CommandIndex = 1;
            SingleCommand? CurrentCommand = null;
            try
            {
                List<SingleCommand> Commands = CommandHelpers.ParseMultiple(InputExpressions, Context);
                foreach (var SingleCommand in Commands)
                {
                    CurrentCommand = SingleCommand;

                    CurrentCommand.Parse();

                    var NodeValue = CurrentCommand.Evaluate();

                    MessageBox.Show($"{CurrentCommand.RawExpression}\r\n" +
                                    $"Result = {NodeValue}", $"[{CommandIndex}]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CommandIndex++;
                }
            }
            catch (Exception Exception)
            {
                MessageBox.Show($"{CurrentCommand?.RawExpression}\r\n" +
                                $"Error = {Exception.Message}", $"[{CommandIndex}]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (Exception.InnerException != null)
                {
                    MessageBox.Show(Exception.InnerException?.Message, "Inner Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile(false);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile(true);
        }
        private void SaveFile(bool SaveAs)
        {
            var CurrentTab = TabControlMain.GetCurrentTab();

            if (CurrentTab != null)
            {
                if (CurrentTab.FilePath == null || SaveAs)
                {
                    string? SaveFilePath = FileDialogHelpers.SaveFileDialogAndGetResult();

                    if (SaveFilePath != null)
                    {
                        if (SaveAs)
                        {
                            string OldContent = CurrentTab.CurrentContent;
                            CurrentTab = this.AddTab();
                            CurrentTab.CurrentContent = OldContent;
                        }

                        CurrentTab.SaveContent(SaveFilePath);
                    }
                }
                else
                {
                    CurrentTab.SaveContent();
                }
            }
        }

        private void OpenFile()
        {
            string[]? OpenFilePaths = FileDialogHelpers.OpenFileDialogAndGetResults();

            if (OpenFilePaths != null)
            {
                foreach (var FilePath in OpenFilePaths)
                {
                    var CurrentTab = TabControlMain.GetTabByFileName(FilePath);

                    if (CurrentTab != null)
                    {
                        TabControlMain.FocusTab(CurrentTab);
                    }
                    else
                    {
                        CurrentTab = this.AddTab();

                        CurrentTab.OpenContent(FilePath);
                    }
                }
            }
        }
    }
}