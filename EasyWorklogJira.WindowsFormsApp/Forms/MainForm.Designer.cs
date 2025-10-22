namespace EasyWorklogJira.WindowsFormsApp.Forms
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStripMain = new MenuStrip();
            systemToolStripMenuItem = new ToolStripMenuItem();
            configurationToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            currentUserToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            resourcesToolStripMenuItem = new ToolStripMenuItem();
            worklogToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            toolStripStatusLabelWebConnectionValue = new ToolStripStatusLabel();
            menuStripMain.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStripMain
            // 
            menuStripMain.Items.AddRange(new ToolStripItem[] { systemToolStripMenuItem, resourcesToolStripMenuItem, helpToolStripMenuItem });
            menuStripMain.Location = new Point(0, 0);
            menuStripMain.Name = "menuStripMain";
            menuStripMain.Size = new Size(1008, 24);
            menuStripMain.TabIndex = 0;
            menuStripMain.Text = "menuStrip1";
            // 
            // systemToolStripMenuItem
            // 
            systemToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { configurationToolStripMenuItem, toolStripMenuItem1, currentUserToolStripMenuItem, exitToolStripMenuItem });
            systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            systemToolStripMenuItem.Size = new Size(60, 20);
            systemToolStripMenuItem.Text = "Sistema";
            // 
            // configurationToolStripMenuItem
            // 
            configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            configurationToolStripMenuItem.Size = new Size(183, 22);
            configurationToolStripMenuItem.Text = "Configuração";
            configurationToolStripMenuItem.Click += setupToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(180, 6);
            // 
            // currentUserToolStripMenuItem
            // 
            currentUserToolStripMenuItem.Name = "currentUserToolStripMenuItem";
            currentUserToolStripMenuItem.Size = new Size(183, 22);
            currentUserToolStripMenuItem.Text = "Usuário da aplicação";
            currentUserToolStripMenuItem.Click += userApplicationToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(183, 22);
            exitToolStripMenuItem.Text = "Sair";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // resourcesToolStripMenuItem
            // 
            resourcesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { worklogToolStripMenuItem });
            resourcesToolStripMenuItem.Name = "resourcesToolStripMenuItem";
            resourcesToolStripMenuItem.Size = new Size(66, 20);
            resourcesToolStripMenuItem.Text = "Recursos";
            // 
            // worklogToolStripMenuItem
            // 
            worklogToolStripMenuItem.Name = "worklogToolStripMenuItem";
            worklogToolStripMenuItem.Size = new Size(191, 22);
            worklogToolStripMenuItem.Text = "Registro de Atividades";
            worklogToolStripMenuItem.Click += queryToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(50, 20);
            helpToolStripMenuItem.Text = "Ajuda";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(104, 22);
            aboutToolStripMenuItem.Text = "Sobre";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelWebConnectionValue });
            statusStrip.Location = new Point(0, 707);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1008, 22);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabelWebConnectionValue
            // 
            toolStripStatusLabelWebConnectionValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            toolStripStatusLabelWebConnectionValue.Name = "toolStripStatusLabelWebConnectionValue";
            toolStripStatusLabelWebConnectionValue.Size = new Size(16, 17);
            toolStripStatusLabelWebConnectionValue.Text = "...";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 729);
            Controls.Add(statusStrip);
            Controls.Add(menuStripMain);
            IsMdiContainer = true;
            MainMenuStrip = menuStripMain;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Easy Worklog Jira";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            menuStripMain.ResumeLayout(false);
            menuStripMain.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStripMain;
        private ToolStripMenuItem systemToolStripMenuItem;
        private ToolStripMenuItem configurationToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem resourcesToolStripMenuItem;
        private ToolStripMenuItem worklogToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem currentUserToolStripMenuItem;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabelWebConnectionValue;
    }
}