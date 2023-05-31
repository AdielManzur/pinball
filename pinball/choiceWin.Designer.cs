namespace pinball
{
    partial class choiceWin
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
            this.btnOpenWatingRoom = new System.Windows.Forms.Button();
            this.btnJoinGame = new System.Windows.Forms.Button();
            this.playerLBL = new System.Windows.Forms.Label();
            this.playerPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.playerPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenWatingRoom
            // 
            this.btnOpenWatingRoom.Location = new System.Drawing.Point(245, 189);
            this.btnOpenWatingRoom.Name = "btnOpenWatingRoom";
            this.btnOpenWatingRoom.Size = new System.Drawing.Size(157, 68);
            this.btnOpenWatingRoom.TabIndex = 0;
            this.btnOpenWatingRoom.Text = "Open new Waiting Room";
            this.btnOpenWatingRoom.UseVisualStyleBackColor = true;
            this.btnOpenWatingRoom.Click += new System.EventHandler(this.BtnOpenWatingRoom_Click);
            // 
            // btnJoinGame
            // 
            this.btnJoinGame.Location = new System.Drawing.Point(664, 189);
            this.btnJoinGame.Name = "btnJoinGame";
            this.btnJoinGame.Size = new System.Drawing.Size(157, 68);
            this.btnJoinGame.TabIndex = 0;
            this.btnJoinGame.Text = "Join Game";
            this.btnJoinGame.UseVisualStyleBackColor = true;
            this.btnJoinGame.Click += new System.EventHandler(this.BtnJoinGame_Click);
            // 
            // playerLBL
            // 
            this.playerLBL.AutoSize = true;
            this.playerLBL.BackColor = System.Drawing.Color.Transparent;
            this.playerLBL.Location = new System.Drawing.Point(520, 102);
            this.playerLBL.Name = "playerLBL";
            this.playerLBL.Size = new System.Drawing.Size(33, 13);
            this.playerLBL.TabIndex = 7;
            this.playerLBL.Text = "name";
            this.playerLBL.Click += new System.EventHandler(this.playerLBL_Click);
            // 
            // playerPicture
            // 
            this.playerPicture.BackColor = System.Drawing.Color.Transparent;
            this.playerPicture.Image = global::pinball.Properties.Resources.profile;
            this.playerPicture.Location = new System.Drawing.Point(501, 27);
            this.playerPicture.Name = "playerPicture";
            this.playerPicture.Size = new System.Drawing.Size(70, 70);
            this.playerPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerPicture.TabIndex = 6;
            this.playerPicture.TabStop = false;
            this.playerPicture.Click += new System.EventHandler(this.playerPicture_Click);
            // 
            // choiceWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1068, 456);
            this.Controls.Add(this.playerLBL);
            this.Controls.Add(this.playerPicture);
            this.Controls.Add(this.btnJoinGame);
            this.Controls.Add(this.btnOpenWatingRoom);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "choiceWin";
            this.Text = "waitingRoom";
            this.Load += new System.EventHandler(this.WaitingRoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.playerPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenWatingRoom;
        private System.Windows.Forms.Button btnJoinGame;
        private System.Windows.Forms.Label playerLBL;
        private System.Windows.Forms.PictureBox playerPicture;
    }
}