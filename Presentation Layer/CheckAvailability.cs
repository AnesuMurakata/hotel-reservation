using Rest_Easy_Hotel_Management_System.Domain_Layer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rest_Easy_Hotel_Management_System.Presentation_Layer
{
    public partial class CheckAvailability : Form
    {
        //get rid of lateer 

        #region DataMembers

        private bool checkAvailabilityFormClosed = false;    //necessary to determine if the form has been closed
        private BookingController bookingController;
        private RoomController roomController;
        private RoomRateController roomRateController;
        private GuestController guestController;
        private PaymentController paymentController;


        private Home mdiForm;

        #region Properties
        public bool CheckListFormClosed
        {
            get { return checkAvailabilityFormClosed; }
            set { checkAvailabilityFormClosed = value; }
        }

        #endregion

        public CheckAvailability(BookingController aBController, RoomController aRController, RoomRateController aRRController, GuestController aGConntroller, PaymentController aPController)
        {
            InitializeComponent();
            bookingController = aBController;
            roomController = aRController;
            roomRateController = aRRController;
            guestController = aGConntroller;
            paymentController = aPController;
        }
        #endregion
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void CheckAvailability_Load(object sender, EventArgs e)
        {
            mdiForm = (Home)this.MdiParent;
            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");
            comboBox1.Items.Add("4");

            this.ControlBox = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //capture the booking details from the textboxes

            if (comboBox1.SelectedIndex == -1)//Nothing selected
            {
                MessageBox.Show("Please select number of guests from the drop down list", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
                return;
            }

            else if (dateTimePicker2.Value < dateTimePicker1.Value)
            {
                MessageBox.Show("Check out date should be a later date than the check in date", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePicker1.Focus();
                return;
            }

            else
            {
                //check the availability
                Collection<Room> Avail;
                Avail = bookingController.CheckAvailability(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date, roomController.AllRooms);
                DialogResult result;
                Booking aBooking;

                //if there are bookings available
                if (Avail.Count() > 0)
                {
                    result = MessageBox.Show("Booking for " + dateTimePicker1.Value.ToShortDateString() + " - " + dateTimePicker2.Value.ToShortDateString() + " is available\nClick yes to confirm", "Confirm Reservation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);


                    if (result == DialogResult.Yes)
                    {
                        this.Hide();

                        //make the booking with all the fields we currently have
                        aBooking = new Booking();

                        aBooking.BookingID = bookingController.GenerateBookingID();
                        aBooking.ReservationDate = DateTime.Today.ToShortDateString();
                        aBooking.StartDate = dateTimePicker1.Value.ToShortDateString();
                        aBooking.EndDate = dateTimePicker2.Value.ToShortDateString();
                        aBooking.RoomNumber = Avail[0].RoomNumber;                                             //assigned to the first available room
                        aBooking.NoOfGuests = comboBox1.SelectedItem.ToString();
                        aBooking.Price = bookingController.CalculateBookingPrice(dateTimePicker1.Value, dateTimePicker2.Value, roomRateController.AllRoomRates);
                        aBooking.DepositAmount = (aBooking.Price / 10);
                        aBooking.DepositPaid = "false";


                        ReservationDetailsDisplayForm obj = new ReservationDetailsDisplayForm(bookingController, roomController, guestController, aBooking, paymentController);   //this must change to the capture guest details
                        obj.Show();
                    }

                    if (result == DialogResult.No)         //if they want to stay on this page
                    {

                    }


                }
                //if there are no bookings available
                else
                {
                    result = MessageBox.Show("Reservation unavailable\nPlease select new dates", "Reservation Unvailable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    //to select new dates
                    if (result == DialogResult.OK)
                    {

                    }




                }



            }
            
            
            
        
        }
        private void CheckAvailability_FormClosed(object sender, FormClosedEventArgs e)
        {
            checkAvailabilityFormClosed = true;
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
