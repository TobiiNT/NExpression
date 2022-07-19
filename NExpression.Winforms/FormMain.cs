using NExpression.Core.Commands;
using NExpression.Core.Contexts;
using NExpression.Core.Helpers;
using NExpression.Winforms.Components;

namespace NExpression.Winforms
{
    public partial class FormMain : Form
    {
        public Dictionary<object, DynamicContext> Contexts { get; set; }

        public FormMain()
        {
            InitializeComponent();

            this.Contexts = new Dictionary<object, DynamicContext>();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            AddTab("New Tab");
        }

        private void AddTab(string TabName)
        {
            object Timestamp = DateTime.Now.Ticks;

            if (!this.Contexts.ContainsKey(Timestamp))
            {
                var Context = new DynamicContext("Context " + Timestamp);

                this.Contexts.Add(Timestamp, Context);

                this.CustomTabControl.AddTab(Timestamp, TabName);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTab("New Tab");
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Contexts.TryGetValue(CustomTabControl.GetCurrentTabTag(), out DynamicContext Context))
            {
                string? InputExpressions = CustomTabControl.GetCurrentTabTextBoxValue();

                Execute(InputExpressions, Context);
                //var Tokens = TokenHelpers.Parse(Expression);
                //Consoler.Write($"Tokens      = ", ConsoleColor.Cyan);
                //do
                //{
                //    Consoler.Write($"{Tokens.Token.Symbol()} ", ConsoleColor.Cyan);
                //    Tokens.NextToken();
                //}
                //while (Tokens.Token != Token.EOF);
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
                MessageBox.Show($"{CurrentCommand.RawExpression}\r\n" +
                                $"Error = {Exception.Message}", $"[{CommandIndex}]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (Exception.InnerException != null)
                {
                    MessageBox.Show(Exception.InnerException?.Message, "Inner Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}