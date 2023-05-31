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
            // choiceWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 456);
            this.Controls.Add(this.btnJoinGame);
            this.Controls.Add(this.btnOpenWatingRoom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "choiceWin";
            this.Text = "waitingRoom";
            this.Load += new System.EventHandler(this.WaitingRoom_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenWatingRoom;
        private System.Windows.Forms.Button btnJoinGame;
    }
}