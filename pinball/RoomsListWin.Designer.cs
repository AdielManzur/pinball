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
            this.SuspendLayout();
            // 
            // lbxRooms
            // 
            this.lbxRooms.FormattingEnabled = true;
            this.lbxRooms.Location = new System.Drawing.Point(161, 46);
            this.lbxRooms.Name = "lbxRooms";
            this.lbxRooms.Size = new System.Drawing.Size(465, 368);
            this.lbxRooms.TabIndex = 0;
            // 
            // RoomsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbxRooms);
            this.Name = "RoomsList";
            this.Text = "RoomsList";
            this.Load += new System.EventHandler(this.RoomsList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxRooms;
    }
}