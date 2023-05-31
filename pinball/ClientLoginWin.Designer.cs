namespace pinball
{
    partial class ClientLoginWin
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.txbPass = new System.Windows.Forms.TextBox();
            this.txbUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.playerPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.playerPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.Location = new System.Drawing.Point(277, 230);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(161, 60);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // txbPass
            // 
            this.txbPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbPass.Location = new System.Drawing.Point(277, 192);
            this.txbPass.Name = "txbPass";
            this.txbPass.Size = new System.Drawing.Size(161, 20);
            this.txbPass.TabIndex = 1;
            this.txbPass.TextChanged += new System.EventHandler(this.txbPass_TextChanged);
            // 
            // txbUsername
            // 
            this.txbUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbUsername.Location = new System.Drawing.Point(277, 143);
            this.txbUsername.Name = "txbUsername";
            this.txbUsername.Size = new System.Drawing.Size(161, 20);
            this.txbUsername.TabIndex = 1;
            this.txbUsername.TextChanged += new System.EventHandler(this.TxbUsername_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(280, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "username";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "password";
            // 
            // playerPicture
            // 
            this.playerPicture.BackColor = System.Drawing.Color.Transparent;
            this.playerPicture.Image = global::pinball.Properties.Resources.profile;
            this.playerPicture.Location = new System.Drawing.Point(316, 42);
            this.playerPicture.Name = "playerPicture";
            this.playerPicture.Size = new System.Drawing.Size(70, 70);
            this.playerPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerPicture.TabIndex = 7;
            this.playerPicture.TabStop = false;
            // 
            // ClientLoginWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 456);
            this.Controls.Add(this.playerPicture);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbUsername);
            this.Controls.Add(this.txbPass);
            this.Controls.Add(this.btnLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ClientLoginWin";
            this.Text = "ClientLoginWin";
            this.Load += new System.EventHandler(this.ClientLoginWin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.playerPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txbPass;
        private System.Windows.Forms.TextBox txbUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox playerPicture;
    }
}