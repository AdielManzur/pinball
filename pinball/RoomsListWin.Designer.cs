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
            this.rjButton1 = new RJCodeAdvance.RJControls.RJButton();
            this.SuspendLayout();
            // 
            // lbxRooms
            // 
            this.lbxRooms.FormattingEnabled = true;
            this.lbxRooms.Location = new System.Drawing.Point(150, 43);
            this.lbxRooms.Name = "lbxRooms";
            this.lbxRooms.Size = new System.Drawing.Size(465, 277);
            this.lbxRooms.TabIndex = 0;
            this.lbxRooms.SelectedIndexChanged += new System.EventHandler(this.LbxRooms_SelectedIndexChanged);
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton1.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.BorderRadius = 0;
            this.rjButton1.BorderSize = 0;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.Location = new System.Drawing.Point(322, 345);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(163, 50);
            this.rjButton1.TabIndex = 1;
            this.rjButton1.Text = "update list";
            this.rjButton1.TextColor = System.Drawing.Color.White;
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.Click += new System.EventHandler(this.rjButton1_Click);
            // 
            // RoomsListWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rjButton1);
            this.Controls.Add(this.lbxRooms);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RoomsListWin";
            this.Text = "RoomsList";
            this.Load += new System.EventHandler(this.RoomsList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxRooms;
        private RJCodeAdvance.RJControls.RJButton rjButton1;
    }
}