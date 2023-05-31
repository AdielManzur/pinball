namespace pinball
{
    partial class ClientMainWin
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.conectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConnectToServer = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSignOut = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLeaveGame = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.scoreLBL = new System.Windows.Forms.Label();
            this.playerLabel = new System.Windows.Forms.Label();
            this.playerNameLbl = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conectionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1068, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // conectionToolStripMenuItem
            // 
            this.conectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConnectToServer,
            this.btnLogin,
            this.btnRegister,
            this.btnSignOut,
            this.btnLeaveGame});
            this.conectionToolStripMenuItem.Name = "conectionToolStripMenuItem";
            this.conectionToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.conectionToolStripMenuItem.Text = "Connection";
            // 
            // btnConnectToServer
            // 
            this.btnConnectToServer.Name = "btnConnectToServer";
            this.btnConnectToServer.Size = new System.Drawing.Size(169, 22);
            this.btnConnectToServer.Text = "Connect To Server";
            this.btnConnectToServer.Click += new System.EventHandler(this.connectToServer);
            // 
            // btnLogin
            // 
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(169, 22);
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.openLoginWin);
            // 
            // btnRegister
            // 
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(169, 22);
            this.btnRegister.Text = "Register";
            this.btnRegister.Click += new System.EventHandler(this.openRegWin);
            // 
            // btnSignOut
            // 
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(169, 22);
            this.btnSignOut.Text = "Sign Out";
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // btnLeaveGame
            // 
            this.btnLeaveGame.Name = "btnLeaveGame";
            this.btnLeaveGame.Size = new System.Drawing.Size(169, 22);
            this.btnLeaveGame.Text = "Leave Game";
            this.btnLeaveGame.Visible = false;
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(0, 27);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1068, 456);
            this.mainPanel.TabIndex = 1;
            // 
            // scoreLBL
            // 
            this.scoreLBL.AutoSize = true;
            this.scoreLBL.Location = new System.Drawing.Point(880, 41);
            this.scoreLBL.Name = "scoreLBL";
            this.scoreLBL.Size = new System.Drawing.Size(7, 13);
            this.scoreLBL.TabIndex = 0;
            this.scoreLBL.Text = "\r\n";
            // 
            // playerLabel
            // 
            this.playerLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.playerLabel.AutoSize = true;
            this.playerLabel.Location = new System.Drawing.Point(514, 41);
            this.playerLabel.Name = "playerLabel";
            this.playerLabel.Size = new System.Drawing.Size(0, 13);
            this.playerLabel.TabIndex = 2;
            // 
            // playerNameLbl
            // 
            this.playerNameLbl.AutoSize = true;
            this.playerNameLbl.Location = new System.Drawing.Point(12, 41);
            this.playerNameLbl.Name = "playerNameLbl";
            this.playerNameLbl.Size = new System.Drawing.Size(0, 13);
            this.playerNameLbl.TabIndex = 3;
            // 
            // ClientMainWin
            // 
            this.ClientSize = new System.Drawing.Size(1068, 481);
            this.Controls.Add(this.scoreLBL);
            this.Controls.Add(this.playerNameLbl);
            this.Controls.Add(this.playerLabel);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(200, 100);
            this.Name = "ClientMainWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ClientMainWin_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem conectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnConnectToServer;
        private System.Windows.Forms.ToolStripMenuItem btnLogin;
        private System.Windows.Forms.ToolStripMenuItem btnRegister;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label playerLabel;
        private System.Windows.Forms.Label playerNameLbl;
        private System.Windows.Forms.Label scoreLBL;
        private System.Windows.Forms.ToolStripMenuItem btnSignOut;
        private System.Windows.Forms.ToolStripMenuItem btnLeaveGame;
    }
}

