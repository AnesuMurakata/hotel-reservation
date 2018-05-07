namespace Rest_Easy_Hotel_Management_System.Presentation_Layer
{
    partial class BookingListForm
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
            this.listViewTitleLabel = new System.Windows.Forms.Label();
            this.bookingListView = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewTitleLabel
            // 
            this.listViewTitleLabel.AutoSize = true;
            this.listViewTitleLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewTitleLabel.Location = new System.Drawing.Point(43, 49);
            this.listViewTitleLabel.Name = "listViewTitleLabel";
            this.listViewTitleLabel.Size = new System.Drawing.Size(138, 22);
            this.listViewTitleLabel.TabIndex = 0;
            this.listViewTitleLabel.Text = "Bookings List";
            this.listViewTitleLabel.Click += new System.EventHandler(this.listViewTitleLabel_Click);
            // 
            // bookingListView
            // 
            this.bookingListView.Location = new System.Drawing.Point(47, 88);
            this.bookingListView.Name = "bookingListView";
            this.bookingListView.Size = new System.Drawing.Size(881, 314);
            this.bookingListView.TabIndex = 1;
            this.bookingListView.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Brown;
            this.button1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(47, 423);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 31);
            this.button1.TabIndex = 2;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BookingListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(979, 503);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bookingListView);
            this.Controls.Add(this.listViewTitleLabel);
            this.Name = "BookingListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Booking List Page";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BookingListForm_FormClosed);
            this.Load += new System.EventHandler(this.BookingListForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label listViewTitleLabel;
        private System.Windows.Forms.ListView bookingListView;
        private System.Windows.Forms.Button button1;
    }
}