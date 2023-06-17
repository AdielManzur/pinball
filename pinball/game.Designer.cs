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
            this.components = new System.ComponentModel.Container();
            this.rightPlayer = new System.Windows.Forms.PictureBox();
            this.leftPlayer = new System.Windows.Forms.PictureBox();
            this.ball = new RJCodeAdvance.RJControls.RJCircularPictureBox();
            this.lblDebug = new System.Windows.Forms.Label();
            this.timerBallMovement = new System.Windows.Forms.Timer(this.components);
            this.countdownTimer = new System.Windows.Forms.Timer(this.components);
            this.countdownLBL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameLBL = new System.Windows.Forms.Label();
            this.playerKeysLBL = new System.Windows.Forms.Label();
            this.scoreRightLBL = new System.Windows.Forms.Label();
            this.scoreLeftLBL = new System.Windows.Forms.Label();
            this.enemyPlayerLeftLBL = new System.Windows.Forms.Label();
            this.playerWonLBL = new System.Windows.Forms.Label();
            this.backToLobbyLBL = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rightPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            this.SuspendLayout();
            // 
            // rightPlayer
            // 
            this.rightPlayer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rightPlayer.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rightPlayer.Location = new System.Drawing.Point(999, 136);
            this.rightPlayer.Name = "rightPlayer";
            this.rightPlayer.Size = new System.Drawing.Size(15, 150);
            this.rightPlayer.TabIndex = 0;
            this.rightPlayer.TabStop = false;
            // 
            // leftPlayer
            // 
            this.leftPlayer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.leftPlayer.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.leftPlayer.Location = new System.Drawing.Point(74, 147);
            this.leftPlayer.Name = "leftPlayer";
            this.leftPlayer.Size = new System.Drawing.Size(14, 150);
            this.leftPlayer.TabIndex = 0;
            this.leftPlayer.TabStop = false;
            // 
            // ball
            // 
            this.ball.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ball.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ball.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.ball.BorderColor = System.Drawing.Color.Honeydew;
            this.ball.BorderColor2 = System.Drawing.Color.Red;
            this.ball.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.ball.BorderSize = 2;
            this.ball.GradientAngle = 50F;
            this.ball.Location = new System.Drawing.Point(512, 194);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(42, 42);
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
            // timerBallMovement
            // 
            this.timerBallMovement.Interval = 10;
            this.timerBallMovement.Tick += new System.EventHandler(this.timerBallMovement_Tick);
            // 
            // countdownTimer
            // 
            this.countdownTimer.Interval = 1000;
            this.countdownTimer.Tick += new System.EventHandler(this.CountdownTimer_Tick);
            // 
            // countdownLBL
            // 
            this.countdownLBL.AutoSize = true;
            this.countdownLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.countdownLBL.Location = new System.Drawing.Point(403, 94);
            this.countdownLBL.Name = "countdownLBL";
            this.countdownLBL.Size = new System.Drawing.Size(0, 39);
            this.countdownLBL.TabIndex = 4;
            this.countdownLBL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(262, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 25);
            this.label2.TabIndex = 6;
            // 
            // nameLBL
            // 
            this.nameLBL.AutoSize = true;
            this.nameLBL.BackColor = System.Drawing.Color.Transparent;
            this.nameLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.nameLBL.Location = new System.Drawing.Point(38, 27);
            this.nameLBL.Name = "nameLBL";
            this.nameLBL.Size = new System.Drawing.Size(43, 17);
            this.nameLBL.TabIndex = 7;
            this.nameLBL.Text = "name";
            // 
            // playerKeysLBL
            // 
            this.playerKeysLBL.AutoSize = true;
            this.playerKeysLBL.BackColor = System.Drawing.Color.Transparent;
            this.playerKeysLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.playerKeysLBL.Location = new System.Drawing.Point(509, 27);
            this.playerKeysLBL.Name = "playerKeysLBL";
            this.playerKeysLBL.Size = new System.Drawing.Size(78, 17);
            this.playerKeysLBL.TabIndex = 8;
            this.playerKeysLBL.Text = "playerKeys";
            // 
            // scoreRightLBL
            // 
            this.scoreRightLBL.AutoSize = true;
            this.scoreRightLBL.BackColor = System.Drawing.Color.Transparent;
            this.scoreRightLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.scoreRightLBL.Location = new System.Drawing.Point(799, 27);
            this.scoreRightLBL.Name = "scoreRightLBL";
            this.scoreRightLBL.Size = new System.Drawing.Size(43, 17);
            this.scoreRightLBL.TabIndex = 9;
            this.scoreRightLBL.Text = "score";
            // 
            // scoreLeftLBL
            // 
            this.scoreLeftLBL.AutoSize = true;
            this.scoreLeftLBL.BackColor = System.Drawing.Color.Transparent;
            this.scoreLeftLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.scoreLeftLBL.Location = new System.Drawing.Point(262, 27);
            this.scoreLeftLBL.Name = "scoreLeftLBL";
            this.scoreLeftLBL.Size = new System.Drawing.Size(43, 17);
            this.scoreLeftLBL.TabIndex = 9;
            this.scoreLeftLBL.Text = "score";
            // 
            // enemyPlayerLeftLBL
            // 
            this.enemyPlayerLeftLBL.AutoSize = true;
            this.enemyPlayerLeftLBL.BackColor = System.Drawing.Color.Transparent;
            this.enemyPlayerLeftLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.enemyPlayerLeftLBL.Location = new System.Drawing.Point(262, 147);
            this.enemyPlayerLeftLBL.Name = "enemyPlayerLeftLBL";
            this.enemyPlayerLeftLBL.Size = new System.Drawing.Size(519, 25);
            this.enemyPlayerLeftLBL.TabIndex = 10;
            this.enemyPlayerLeftLBL.Text = "The enemy player left. press Space to go back to the lobby";
            this.enemyPlayerLeftLBL.Visible = false;
            // 
            // playerWonLBL
            // 
            this.playerWonLBL.AutoSize = true;
            this.playerWonLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.playerWonLBL.Location = new System.Drawing.Point(295, 223);
            this.playerWonLBL.Name = "playerWonLBL";
            this.playerWonLBL.Size = new System.Drawing.Size(0, 31);
            this.playerWonLBL.TabIndex = 11;
            // 
            // backToLobbyLBL
            // 
            this.backToLobbyLBL.AutoSize = true;
            this.backToLobbyLBL.BackColor = System.Drawing.Color.Transparent;
            this.backToLobbyLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.backToLobbyLBL.Location = new System.Drawing.Point(452, 273);
            this.backToLobbyLBL.Name = "backToLobbyLBL";
            this.backToLobbyLBL.Size = new System.Drawing.Size(211, 17);
            this.backToLobbyLBL.TabIndex = 12;
            this.backToLobbyLBL.Text = "press Space to go back to lobby";
            this.backToLobbyLBL.Visible = false;
            // 
            // game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::pinball.Properties.Resources.pong_game_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1068, 460);
            this.Controls.Add(this.backToLobbyLBL);
            this.Controls.Add(this.playerWonLBL);
            this.Controls.Add(this.enemyPlayerLeftLBL);
            this.Controls.Add(this.leftPlayer);
            this.Controls.Add(this.scoreLeftLBL);
            this.Controls.Add(this.scoreRightLBL);
            this.Controls.Add(this.playerKeysLBL);
            this.Controls.Add(this.nameLBL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.countdownLBL);
            this.Controls.Add(this.lblDebug);
            this.Controls.Add(this.ball);
            this.Controls.Add(this.rightPlayer);
            this.DoubleBuffered = true;
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
        private System.Windows.Forms.Timer timerBallMovement;
        private System.Windows.Forms.Timer countdownTimer;
        private System.Windows.Forms.Label countdownLBL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label nameLBL;
        private System.Windows.Forms.Label playerKeysLBL;
        private System.Windows.Forms.Label scoreRightLBL;
        private System.Windows.Forms.Label scoreLeftLBL;
        private System.Windows.Forms.Label enemyPlayerLeftLBL;
        private System.Windows.Forms.Label playerWonLBL;
        private System.Windows.Forms.Label backToLobbyLBL;
    }
}