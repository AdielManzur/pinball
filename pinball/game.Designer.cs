namespace pinball
{
    partial class game
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
            this.rightPlayer = new System.Windows.Forms.PictureBox();
            this.leftPlayer = new System.Windows.Forms.PictureBox();
            this.ball = new RJCodeAdvance.RJControls.RJCircularPictureBox();
            this.lblDebug = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rightPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            this.SuspendLayout();
            // 
            // rightPlayer
            // 
            this.rightPlayer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rightPlayer.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rightPlayer.Location = new System.Drawing.Point(1015, 166);
            this.rightPlayer.Name = "rightPlayer";
            this.rightPlayer.Size = new System.Drawing.Size(15, 150);
            this.rightPlayer.TabIndex = 0;
            this.rightPlayer.TabStop = false;
            // 
            // leftPlayer
            // 
            this.leftPlayer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.leftPlayer.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.leftPlayer.Location = new System.Drawing.Point(74, 177);
            this.leftPlayer.Name = "leftPlayer";
            this.leftPlayer.Size = new System.Drawing.Size(14, 150);
            this.leftPlayer.TabIndex = 0;
            this.leftPlayer.TabStop = false;
            this.leftPlayer.Click += new System.EventHandler(this.leftPlayer_Click);
            // 
            // ball
            // 
            this.ball.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ball.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ball.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.ball.BorderColor = System.Drawing.Color.RoyalBlue;
            this.ball.BorderColor2 = System.Drawing.Color.HotPink;
            this.ball.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.ball.BorderSize = 2;
            this.ball.GradientAngle = 50F;
            this.ball.Location = new System.Drawing.Point(509, 225);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(36, 36);
            this.ball.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ball.TabIndex = 2;
            this.ball.TabStop = false;
            // 
            // lblDebug
            // 
            this.lblDebug.AutoSize = true;
            this.lblDebug.Location = new System.Drawing.Point(89, 27);
            this.lblDebug.Name = "lblDebug";
            this.lblDebug.Size = new System.Drawing.Size(0, 13);
            this.lblDebug.TabIndex = 3;
            // 
            // game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1084, 520);
            this.Controls.Add(this.lblDebug);
            this.Controls.Add(this.ball);
            this.Controls.Add(this.leftPlayer);
            this.Controls.Add(this.rightPlayer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(100, 200);
            this.Name = "game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "game";
            this.Load += new System.EventHandler(this.Game_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.rightPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox rightPlayer;
        private System.Windows.Forms.PictureBox leftPlayer;
        private RJCodeAdvance.RJControls.RJCircularPictureBox ball;
        private System.Windows.Forms.Label lblDebug;
    }
}