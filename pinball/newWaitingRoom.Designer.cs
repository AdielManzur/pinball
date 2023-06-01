namespace pinball
{
    partial class newWaitingRoom
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
            this.loadGif = new System.Windows.Forms.PictureBox();
            this.BackButton = new System.Windows.Forms.PictureBox();
            this.waitingLBL = new System.Windows.Forms.Label();
            this.waitingTimer = new System.Windows.Forms.Timer(this.components);
            this.playerLBL = new System.Windows.Forms.Label();
            this.playerPicture = new RJCodeAdvance.RJControls.RJCircularPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.loadGif)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // loadGif
            // 
            this.loadGif.Image = global::pinball.Properties.Resources.loading_gif;
            this.loadGif.Location = new System.Drawing.Point(520, 261);
            this.loadGif.Name = "loadGif";
            this.loadGif.Size = new System.Drawing.Size(48, 46);
            this.loadGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadGif.TabIndex = 2;
            this.loadGif.TabStop = false;
            // 
            // BackButton
            // 
            this.BackButton.Image = global::pinball.Properties.Resources.returnButton;
            this.BackButton.Location = new System.Drawing.Point(12, 12);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(64, 72);
            this.BackButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BackButton.TabIndex = 1;
            this.BackButton.TabStop = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // waitingLBL
            // 
            this.waitingLBL.AutoSize = true;
            this.waitingLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.waitingLBL.Location = new System.Drawing.Point(470, 199);
            this.waitingLBL.Name = "waitingLBL";
            this.waitingLBL.Size = new System.Drawing.Size(0, 31);
            this.waitingLBL.TabIndex = 3;
            // 
            // waitingTimer
            // 
            this.waitingTimer.Enabled = true;
            this.waitingTimer.Interval = 1000;
            this.waitingTimer.Tick += new System.EventHandler(this.waitingTimer_Tick);
            // 
            // playerLBL
            // 
            this.playerLBL.AutoSize = true;
            this.playerLBL.BackColor = System.Drawing.Color.Transparent;
            this.playerLBL.Location = new System.Drawing.Point(965, 87);
            this.playerLBL.Name = "playerLBL";
            this.playerLBL.Size = new System.Drawing.Size(33, 13);
            this.playerLBL.TabIndex = 7;
            this.playerLBL.Text = "name";
            // 
            // playerPicture
            // 
            this.playerPicture.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.playerPicture.BorderColor = System.Drawing.Color.Transparent;
            this.playerPicture.BorderColor2 = System.Drawing.Color.Transparent;
            this.playerPicture.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.playerPicture.BorderSize = 2;
            this.playerPicture.GradientAngle = 50F;
            this.playerPicture.Image = global::pinball.Properties.Resources.profile;
            this.playerPicture.Location = new System.Drawing.Point(948, 10);
            this.playerPicture.Name = "playerPicture";
            this.playerPicture.Size = new System.Drawing.Size(74, 74);
            this.playerPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerPicture.TabIndex = 9;
            this.playerPicture.TabStop = false;
            // 
            // newWaitingRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 520);
            this.Controls.Add(this.playerPicture);
            this.Controls.Add(this.playerLBL);
            this.Controls.Add(this.waitingLBL);
            this.Controls.Add(this.loadGif);
            this.Controls.Add(this.BackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "newWaitingRoom";
            this.Text = "newWaitingRoom";
            this.Load += new System.EventHandler(this.NewWaitingRoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.loadGif)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox BackButton;
        private System.Windows.Forms.PictureBox loadGif;
        private System.Windows.Forms.Label waitingLBL;
        private System.Windows.Forms.Timer waitingTimer;
        private System.Windows.Forms.Label playerLBL;
        private RJCodeAdvance.RJControls.RJCircularPictureBox playerPicture;
    }
}