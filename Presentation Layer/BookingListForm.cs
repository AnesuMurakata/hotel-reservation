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
    public partial class BookingListForm : Form
    {
        #region Data Members
        private bool bookingListFormClosed = false;

        private BookingController bookingController;
        private Home mdiForm;
        #endregion

        #region Properties

         public bool BookingListFormClosed
        {
            get { return bookingListFormClosed; }
            set { bookingListFormClosed = value; }
        }


        #endregion


        public BookingListForm(BookingController aController)
        {
            InitializeComponent();
            bookingController = aController;
        }

        #region Form Events
        private void BookingListForm_Load(object sender, EventArgs e)
        {
            bookingListView.View = View.Details;
            setUpBookingListView();
            mdiForm = (Home)this.MdiParent;

            this.ControlBox = false;

        }
        private void BookingListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            bookingListFormClosed = true;
        }
        #endregion

        #region Setting Up ListView Control
        //these methods set up the list view control

        public void setUpBookingListView()
        {
            ListViewItem bookingDetails;
            Collection<Booking> bookings = bookingController.AllBookings;

            //Clear current List View control
            bookingListView.Clear();

            //Set up the collumns of the List View 
            bookingListView.Columns.Insert(0, "Booking ID", 100, HorizontalAlignment.Left);
            bookingListView.Columns.Insert(1, "Guest ID", 100, HorizontalAlignment.Left);
            bookingListView.Columns.Insert(2, "Room No", 100, HorizontalAlignment.Left);
            bookingListView.Columns.Insert(3, "Reservation Date", 100, HorizontalAlignment.Left);
            bookingListView.Columns.Insert(4, "Start Date", 100, HorizontalAlignment.Left);
            bookingListView.Columns.Insert(5, "End Date", 100, HorizontalAlignment.Left);
            bookingListView.Columns.Insert(6, "No of Guests", 100, HorizontalAlignment.Left);

            bookingListView.Columns.Insert(7, "Price", 100, HorizontalAlignment.Left);
            bookingListView.Columns.Insert(8, "Deposit Amount", 100, HorizontalAlignment.Left);
            bookingListView.Columns.Insert(9, "Deposit Paid", 100, HorizontalAlignment.Left);


            //add guest details to each ListView item
            foreach (Booking booking in bookings)
            {
                bookingDetails = new ListViewItem();
                bookingDetails.Text = Convert.ToString(booking.BookingID);
                bookingDetails.SubItems.Add(booking.GuestID);
                bookingDetails.SubItems.Add(booking.RoomNumber);
                bookingDetails.SubItems.Add(booking.ReservationDate);
                bookingDetails.SubItems.Add(booking.StartDate);
                bookingDetails.SubItems.Add(booking.EndDate);
                bookingDetails.SubItems.Add(booking.NoOfGuests);
             
                bookingDetails.SubItems.Add(Convert.ToString(booking.Price));
                bookingDetails.SubItems.Add(Convert.ToString(booking.DepositAmount));
                bookingDetails.SubItems.Add(booking.DepositPaid);
        

                bookingListView.Items.Add(bookingDetails);

            }
            bookingListView.Refresh();
            bookingListView.GridLines = true;



        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to close", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
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

        private void listViewTitleLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
