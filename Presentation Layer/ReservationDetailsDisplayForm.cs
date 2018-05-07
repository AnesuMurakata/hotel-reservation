using Rest_Easy_Hotel_Management_System.Domain_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rest_Easy_Hotel_Management_System.Presentation_Layer
{
    public partial class ReservationDetailsDisplayForm : Form
    {
        private BookingController bookingController;
        private RoomController roomController;
        private GuestController guestController;
        private Booking obj;
        private PaymentController paymentController;
        private Home mdiForm;

        public ReservationDetailsDisplayForm(BookingController abookingController, RoomController aroomController, GuestController aGController, Booking b ,PaymentController aPController)
        {
            InitializeComponent();
            bookingController = abookingController;
            roomController = aroomController;
            guestController = aGController;
            paymentController = aPController;
            obj = b;
        }

        public void setupTextFields()
        {
            
            textBox1.Text = obj.BookingID;
            textBox2.Text = obj.ReservationDate; //DateTime.Today.ToShortDateString();
            textBox3.Text = obj.StartDate;
            textBox4.Text = obj.EndDate;
            textBox5.Text = obj.RoomNumber;
            textBox6.Text = obj.NoOfGuests;
            textBox7.Text = Convert.ToString(obj.Price); //price 
            textBox8.Text = Convert.ToString(obj.DepositAmount); // deposit amount
        }




        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            GuestForm guest = new GuestForm(guestController, paymentController, GuestForm.FormState.WhileBooking, obj, bookingController);
            guest.Show();
        }

        private void ReservationDetailsDisplayForm_Load(object sender, EventArgs e)
        {
            setupTextFields();
            mdiForm = (Home)this.MdiParent;
            this.ControlBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            //populate the text boxes
            if (result == DialogResult.Yes)
            {

                this.Hide();
            }
            if (result == DialogResult.No)
            {

                return;
            }

        }
    }
}
