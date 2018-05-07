namespace Rest_Easy_Hotel_Management_System.Domain_Layer
{
    partial class GuestListForm
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
            this.guestListView = new System.Windows.Forms.ListView();
            this.listViewLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // guestListView
            // 
            this.guestListView.FullRowSelect = true;
            this.guestListView.Location = new System.Drawing.Point(30, 73);
            this.guestListView.Name = "guestListView";
            this.guestListView.Size = new System.Drawing.Size(1036, 321);
            this.guestListView.TabIndex = 0;
            this.guestListView.UseCompatibleStateImageBehavior = false;
            // 
            // listViewLabel
            // 
            this.listViewLabel.AutoSize = true;
            this.listViewLabel.BackColor = System.Drawing.Color.White;
            this.listViewLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewLabel.Location = new System.Drawing.Point(26, 31);
            this.listViewLabel.Name = "listViewLabel";
            this.listViewLabel.Size = new System.Drawing.Size(121, 22);
            this.listViewLabel.TabIndex = 1;
            this.listViewLabel.Text = "Guest Listing";
            this.listViewLabel.Click += new System.EventHandler(this.listViewLabel_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Brown;
            this.button1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(30, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 31);
            this.button1.TabIndex = 2;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GuestListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1100, 481);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listViewLabel);
            this.Controls.Add(this.guestListView);
            this.Name = "GuestListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guest Listing Page";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GuestListForm_FormClosed);
            this.Load += new System.EventHandler(this.GuestListForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView guestListView;
        private System.Windows.Forms.Label listViewLabel;
        private System.Windows.Forms.Button button1;
    }
}