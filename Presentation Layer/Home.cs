using Rest_Easy_Hotel_Management_System.Domain_Layer;
using Rest_Easy_Hotel_Management_System.Presentation_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rest_Easy_Hotel_Management_System
{
    public partial class Home : Form
    {

        #region DataMembers
        //these are all the child forms and necesseray controllers
        private GuestListForm guestListForm;
        private GuestController guestController;
        private GuestForm guestForm;
        private CheckAvailability checkAvailabilityForm;
        private BookingListForm bookingListForm;
        

        private RoomController roomController;
        private RoomRateController roomRateController;      
        private BookingController bookingController;
        private PaymentController paymentController;


        #endregion

        #region properties

        public BookingListForm BookingListForm
        {
            get { return bookingListForm; }
            set { bookingListForm = value; }
        }

        public GuestListForm currentGuestListForm
        {
            get { return guestListForm; }
            set { guestListForm = value; }
        }

        public BookingController BookingController
        {
            get { return bookingController; }
            set { bookingController = value; }
        }

        public GuestController GuestController
        {
            get { return guestController; }
            set { guestController = value; }
        }

        private RoomController RoomController
        {
            get { return roomController; }
            set { roomController = value; }
        }

        public RoomRateController RoomRateController
        {
            get { return roomRateController; }
            set { roomRateController = value; }
        }


        #endregion



        public Home()
        {
            InitializeComponent();
            guestController = new GuestController();
            bookingController = new BookingController();
            roomController = new RoomController();
            roomRateController = new RoomRateController();
            paymentController = new PaymentController();
        }



        private void Home_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;

            this.ControlBox = false;

        }


        #region Menu Click Events

        private void addNewGuestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (guestForm == null)
            {
                CreateNewGuestForm();
            }
            if (guestForm.guestFormClosed)
            {
                CreateNewGuestForm();
            }
            guestForm.Show();
        }

        private void viewAllGuestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(guestListForm==null)
            { 
                CreateNewGuestListForm();   
            }
            if(guestListForm.GuestListFormClosed)
            {
                CreateNewGuestListForm();
            }
            guestListForm.setUpGuestListView();   //reset the list view control 
            guestListForm.Show();
        }



        private void viewBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bookingListForm == null)
            {
                CreateNewBookingListForm();
            }
            if (bookingListForm.BookingListFormClosed)
            {
                CreateNewBookingListForm();
            }
            bookingListForm.setUpBookingListView();   //reset the list view control 
            bookingListForm.Show();
        }


        private void makeABookingToolStripMenuItem_Click(object sender, EventArgs e)
        {


                CreateCheckAvailabilityForm();
                checkAvailabilityForm.Show();
        }

        #endregion

        #region Create Child Forms

        private void CreateNewGuestListForm()
        {
            guestListForm = new GuestListForm(guestController);
            guestListForm.MdiParent = this;
            guestListForm.StartPosition = FormStartPosition.CenterParent;
        }

        private void CreateNewGuestForm()
        {
            guestForm = new GuestForm (guestController, paymentController, GuestForm.FormState.Add);
            guestForm.MdiParent = this;        // Setting the MDI Parent
            guestForm.StartPosition = FormStartPosition.CenterParent;
        }

        private void CreateNewBookingListForm()
        {
            bookingListForm = new BookingListForm(bookingController);
            bookingListForm.MdiParent = this;        // Setting the MDI Parent
            bookingListForm.StartPosition = FormStartPosition.CenterParent;
        }

        private void CreateCheckAvailabilityForm()
        {
            checkAvailabilityForm = new CheckAvailability(bookingController, roomController, roomRateController, guestController, paymentController);
            checkAvailabilityForm.MdiParent = this;        // Setting the MDI Parent
            checkAvailabilityForm.StartPosition = FormStartPosition.CenterParent;
        }

        #endregion

        private void editGuestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guestForm = new GuestForm(guestController, paymentController, GuestForm.FormState.Edit);
            guestForm.MdiParent = this;        // Setting the MDI Parent
            guestForm.StartPosition = FormStartPosition.CenterParent;
            guestForm.Show();
        }



        private void deleteGuestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guestForm = new GuestForm(guestController, paymentController, GuestForm.FormState.Delete);
            guestForm.MdiParent = this;        // Setting the MDI Parent
            guestForm.StartPosition = FormStartPosition.CenterParent;
            guestForm.Show();
        }



        private void logoutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {
                this.Hide();
                LogInForm obj = new LogInForm();
                obj.Show();
            }

        }



        private void deleteABookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookingEditDeleteForm bookingEditDeleteForm = new BookingEditDeleteForm(bookingController, BookingEditDeleteForm.thisFormState.Delete, roomController, roomRateController);
            bookingEditDeleteForm.MdiParent = this;        // Setting the MDI Parent
            bookingEditDeleteForm.StartPosition = FormStartPosition.CenterParent;
            bookingEditDeleteForm.Show();
        }

        private void editABookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookingEditDeleteForm bookingEditDeleteForm = new BookingEditDeleteForm(bookingController, BookingEditDeleteForm.thisFormState.Edit, roomController, roomRateController);
            bookingEditDeleteForm.MdiParent = this;        // Setting the MDI Parent
            bookingEditDeleteForm.StartPosition = FormStartPosition.CenterParent;
            bookingEditDeleteForm.Show();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void generateOccupancyReToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm rf = new ReportForm(bookingController);
            rf.MdiParent = this;        // Setting the MDI Parent
            rf.StartPosition = FormStartPosition.CenterParent;
            rf.Show();
        }








    }
}
