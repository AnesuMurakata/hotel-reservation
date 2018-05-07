namespace Rest_Easy_Hotel_Management_System
{
    partial class Home
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
            this.bookingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeABookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewBookingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editABookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteABookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllGuestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editGuestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteGuestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateOccupancyReToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bookingsToolStripMenuItem,
            this.guestsToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(599, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bookingsToolStripMenuItem
            // 
            this.bookingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.makeABookingToolStripMenuItem,
            this.editABookingToolStripMenuItem,
            this.deleteABookingToolStripMenuItem,
            this.viewBookingsToolStripMenuItem});
            this.bookingsToolStripMenuItem.Name = "bookingsToolStripMenuItem";
            this.bookingsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.bookingsToolStripMenuItem.Text = "Bookings";
            // 
            // makeABookingToolStripMenuItem
            // 
            this.makeABookingToolStripMenuItem.Name = "makeABookingToolStripMenuItem";
            this.makeABookingToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.makeABookingToolStripMenuItem.Text = "Make Booking";
            this.makeABookingToolStripMenuItem.Click += new System.EventHandler(this.makeABookingToolStripMenuItem_Click);
            // 
            // viewBookingsToolStripMenuItem
            // 
            this.viewBookingsToolStripMenuItem.Name = "viewBookingsToolStripMenuItem";
            this.viewBookingsToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.viewBookingsToolStripMenuItem.Text = "View Bookings";
            this.viewBookingsToolStripMenuItem.Click += new System.EventHandler(this.viewBookingsToolStripMenuItem_Click);
            // 
            // editABookingToolStripMenuItem
            // 
            this.editABookingToolStripMenuItem.Name = "editABookingToolStripMenuItem";
            this.editABookingToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.editABookingToolStripMenuItem.Text = "Edit Booking";
            this.editABookingToolStripMenuItem.Click += new System.EventHandler(this.editABookingToolStripMenuItem_Click);
            // 
            // deleteABookingToolStripMenuItem
            // 
            this.deleteABookingToolStripMenuItem.Name = "deleteABookingToolStripMenuItem";
            this.deleteABookingToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.deleteABookingToolStripMenuItem.Text = "Delete Booking";
            this.deleteABookingToolStripMenuItem.Click += new System.EventHandler(this.deleteABookingToolStripMenuItem_Click);
            // 
            // guestsToolStripMenuItem
            // 
            this.guestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editGuestsToolStripMenuItem,
            this.viewAllGuestsToolStripMenuItem,
            this.deleteGuestToolStripMenuItem});
            this.guestsToolStripMenuItem.Name = "guestsToolStripMenuItem";
            this.guestsToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.guestsToolStripMenuItem.Text = "Guests";
            // 
            // viewAllGuestsToolStripMenuItem
            // 
            this.viewAllGuestsToolStripMenuItem.Name = "viewAllGuestsToolStripMenuItem";
            this.viewAllGuestsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewAllGuestsToolStripMenuItem.Text = "View Guests";
            this.viewAllGuestsToolStripMenuItem.Click += new System.EventHandler(this.viewAllGuestsToolStripMenuItem_Click);
            // 
            // editGuestsToolStripMenuItem
            // 
            this.editGuestsToolStripMenuItem.Name = "editGuestsToolStripMenuItem";
            this.editGuestsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editGuestsToolStripMenuItem.Text = "Edit Guest";
            this.editGuestsToolStripMenuItem.Click += new System.EventHandler(this.editGuestsToolStripMenuItem_Click);
            // 
            // deleteGuestToolStripMenuItem
            // 
            this.deleteGuestToolStripMenuItem.Name = "deleteGuestToolStripMenuItem";
            this.deleteGuestToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteGuestToolStripMenuItem.Text = "Delete Guest";
            this.deleteGuestToolStripMenuItem.Click += new System.EventHandler(this.deleteGuestToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateOccupancyReToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            this.reportsToolStripMenuItem.Click += new System.EventHandler(this.reportsToolStripMenuItem_Click);
            // 
            // generateOccupancyReToolStripMenuItem
            // 
            this.generateOccupancyReToolStripMenuItem.Name = "generateOccupancyReToolStripMenuItem";
            this.generateOccupancyReToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.generateOccupancyReToolStripMenuItem.Text = "Generate Occupancy Report";
            this.generateOccupancyReToolStripMenuItem.Click += new System.EventHandler(this.generateOccupancyReToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click_1);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Rest_Easy_Hotel_Management_System.Properties.Resources.blue_gradient_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(599, 575);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home Page";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Home_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bookingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllGuestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editGuestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeABookingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewBookingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editABookingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteABookingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteGuestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateOccupancyReToolStripMenuItem;

    }
}

