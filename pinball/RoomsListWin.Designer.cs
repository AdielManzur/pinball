namespace pinball
{
    partial class RoomsListWin
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
            this.lbxRooms = new System.Windows.Forms.ListBox();
            this.btnUpdateRooms = new RJCodeAdvance.RJControls.RJButton();
            this.lbl = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.PictureBox();
            this.playerLBL = new System.Windows.Forms.Label();
            this.playerPicture = new RJCodeAdvance.RJControls.RJCircularPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BackButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // lbxRooms
            // 
            this.lbxRooms.FormattingEnabled = true;
            this.lbxRooms.Location = new System.Drawing.Point(281, 60);
            this.lbxRooms.Name = "lbxRooms";
            this.lbxRooms.Size = new System.Drawing.Size(465, 277);
            this.lbxRooms.TabIndex = 0;
            this.lbxRooms.SelectedIndexChanged += new System.EventHandler(this.LbxRooms_SelectedIndexChanged);
            // 
            // btnUpdateRooms
            // 
            this.btnUpdateRooms.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnUpdateRooms.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.btnUpdateRooms.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnUpdateRooms.BorderRadius = 10;
            this.btnUpdateRooms.BorderSize = 0;
            this.btnUpdateRooms.FlatAppearance.BorderSize = 0;
            this.btnUpdateRooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateRooms.ForeColor = System.Drawing.Color.White;
            this.btnUpdateRooms.Location = new System.Drawing.Point(445, 355);
            this.btnUpdateRooms.Name = "btnUpdateRooms";
            this.btnUpdateRooms.Size = new System.Drawing.Size(163, 50);
            this.btnUpdateRooms.TabIndex = 1;
            this.btnUpdateRooms.Text = "update list";
            this.btnUpdateRooms.TextColor = System.Drawing.Color.White;
            this.btnUpdateRooms.UseVisualStyleBackColor = false;
            this.btnUpdateRooms.Click += new System.EventHandler(this.btnUpdateRooms_Click);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl.Location = new System.Drawing.Point(396, 24);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(0, 25);
            this.lbl.TabIndex = 3;
            // 
            // BackButton
            // 
            this.BackButton.Image = global::pinball.Properties.Resources.returnButton;
            this.BackButton.Location = new System.Drawing.Point(12, 12);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(64, 64);
            this.BackButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BackButton.TabIndex = 2;
            this.BackButton.TabStop = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // playerLBL
            // 
            this.playerLBL.AutoSize = true;
            this.playerLBL.BackColor = System.Drawing.Color.Transparent;
            this.playerLBL.Location = new System.Drawing.Point(982, 87);
            this.playerLBL.Name = "playerLBL";
            this.playerLBL.Size = new System.Drawing.Size(33, 13);
            this.playerLBL.TabIndex = 5;
            this.playerLBL.Text = "name";
            this.playerLBL.Click += new System.EventHandler(this.playerLBL_Click);
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
            this.playerPicture.Location = new System.Drawing.Point(961, 12);
            this.playerPicture.Name = "playerPicture";
            this.playerPicture.Size = new System.Drawing.Size(74, 74);
            this.playerPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerPicture.TabIndex = 9;
            this.playerPicture.TabStop = false;
            this.playerPicture.Click += new System.EventHandler(this.pictureProfile_Click);
            // 
            // RoomsListWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 456);
            this.Controls.Add(this.playerPicture);
            this.Controls.Add(this.playerLBL);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.btnUpdateRooms);
            this.Controls.Add(this.lbxRooms);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RoomsListWin";
            this.Text = "RoomsList";
            this.Load += new System.EventHandler(this.RoomsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BackButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxRooms;
        private RJCodeAdvance.RJControls.RJButton btnUpdateRooms;
        private System.Windows.Forms.PictureBox BackButton;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label playerLBL;
        private RJCodeAdvance.RJControls.RJCircularPictureBox playerPicture;
    }
}