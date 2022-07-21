namespace NExpression.Winforms
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabControlMain = new NExpression.Winforms.Components.CustomTabControl();
            this.SplitContainerMain = new System.Windows.Forms.SplitContainer();
            this.TabControlEvaluation = new System.Windows.Forms.TabControl();
            this.TabPageConsole = new System.Windows.Forms.TabPage();
            this.TabPageDebug = new System.Windows.Forms.TabPage();
            this.MenuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerMain)).BeginInit();
            this.SplitContainerMain.Panel1.SuspendLayout();
            this.SplitContainerMain.Panel2.SuspendLayout();
            this.SplitContainerMain.SuspendLayout();
            this.TabControlEvaluation.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStripMain
            // 
            this.MenuStripMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.runToolStripMenuItem});
            this.MenuStripMain.Location = new System.Drawing.Point(0, 0);
            this.MenuStripMain.Name = "MenuStripMain";
            this.MenuStripMain.Size = new System.Drawing.Size(778, 33);
            this.MenuStripMain.TabIndex = 1;
            this.MenuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(188, 34);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(188, 34);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(188, 34);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(188, 34);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(188, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(59, 29);
            this.runToolStripMenuItem.Text = "&Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // TabControlMain
            // 
            this.TabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlMain.Location = new System.Drawing.Point(0, 0);
            this.TabControlMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TabControlMain.Name = "TabControlMain";
            this.TabControlMain.Size = new System.Drawing.Size(776, 387);
            this.TabControlMain.TabIndex = 2;
            // 
            // SplitContainerMain
            // 
            this.SplitContainerMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SplitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerMain.Location = new System.Drawing.Point(0, 33);
            this.SplitContainerMain.Name = "SplitContainerMain";
            this.SplitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainerMain.Panel1
            // 
            this.SplitContainerMain.Panel1.Controls.Add(this.TabControlMain);
            // 
            // SplitContainerMain.Panel2
            // 
            this.SplitContainerMain.Panel2.Controls.Add(this.TabControlEvaluation);
            this.SplitContainerMain.Size = new System.Drawing.Size(778, 511);
            this.SplitContainerMain.SplitterDistance = 389;
            this.SplitContainerMain.TabIndex = 3;
            // 
            // TabControlEvaluation
            // 
            this.TabControlEvaluation.Controls.Add(this.TabPageConsole);
            this.TabControlEvaluation.Controls.Add(this.TabPageDebug);
            this.TabControlEvaluation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlEvaluation.Location = new System.Drawing.Point(0, 0);
            this.TabControlEvaluation.Name = "TabControlEvaluation";
            this.TabControlEvaluation.SelectedIndex = 0;
            this.TabControlEvaluation.Size = new System.Drawing.Size(776, 116);
            this.TabControlEvaluation.TabIndex = 0;
            // 
            // TabPageConsole
            // 
            this.TabPageConsole.Location = new System.Drawing.Point(4, 35);
            this.TabPageConsole.Name = "TabPageConsole";
            this.TabPageConsole.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageConsole.Size = new System.Drawing.Size(768, 77);
            this.TabPageConsole.TabIndex = 0;
            this.TabPageConsole.Text = "Console";
            this.TabPageConsole.UseVisualStyleBackColor = true;
            // 
            // TabPageDebug
            // 
            this.TabPageDebug.Location = new System.Drawing.Point(4, 34);
            this.TabPageDebug.Name = "TabPageDebug";
            this.TabPageDebug.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageDebug.Size = new System.Drawing.Size(770, 80);
            this.TabPageDebug.TabIndex = 1;
            this.TabPageDebug.Text = "Debug";
            this.TabPageDebug.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(778, 544);
            this.Controls.Add(this.SplitContainerMain);
            this.Controls.Add(this.MenuStripMain);
            this.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Black;
            this.MainMenuStrip = this.MenuStripMain;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormMain";
            this.Text = "NExpression Evaluator";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.MenuStripMain.ResumeLayout(false);
            this.MenuStripMain.PerformLayout();
            this.SplitContainerMain.Panel1.ResumeLayout(false);
            this.SplitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerMain)).EndInit();
            this.SplitContainerMain.ResumeLayout(false);
            this.TabControlEvaluation.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip MenuStripMain;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem runToolStripMenuItem;
        private Components.CustomTabControl TabControlMain;
        private SplitContainer SplitContainerMain;
        private TabControl TabControlEvaluation;
        private TabPage TabPageConsole;
        private TabPage TabPageDebug;
    }
}