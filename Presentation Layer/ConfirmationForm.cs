using Rest_Easy_Hotel_Management_System.Domain_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rest_Easy_Hotel_Management_System.Presentation_Layer
{
    public partial class ConfirmationForm : Form
    {


        private Guest g;
        private Booking b;
        
        private Home mdiForm;
        public ConfirmationForm(Guest guest, Booking booking)
        {
            InitializeComponent();
            g = guest;
            b = booking;

        }

        private void button1_Click(object sender, EventArgs e)
        {
                 
            MessageBox.Show("Mail sent", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        
        }

        private void ConfirmationForm_Load(object sender, EventArgs e)
        {

            richTextBox1.AppendText("Dear " + g.FirstName +" "+ g.Surname + "\n" + "\n");
            richTextBox1.AppendText("We would like to welcome you to the RestEasy Hotel Group");
            richTextBox1.AppendText("Thank you for making your booking and making our hotels your first choice." + "\n" + "\n");
            richTextBox1.AppendText("Your booking details are shown below : " + "\n" + "\n");

            richTextBox1.AppendText("Reservation date : " + b.ReservationDate + "\n");
            richTextBox1.AppendText("Check In Date : " + b.StartDate + "\n");
            richTextBox1.AppendText("Check Out Date: " + b.EndDate + "\n");
            richTextBox1.AppendText("Number of Guests : " + b.NoOfGuests + "\n");
            richTextBox1.AppendText("Total Price : " + b.Price + "\n");
            richTextBox1.AppendText("Deposit Amount : " + b.DepositAmount + "\n");
            richTextBox1.AppendText("Booking Reference Number : " + b.BookingID + "\n" + "\n");
            richTextBox1.AppendText("We hope you rest easy!");



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
