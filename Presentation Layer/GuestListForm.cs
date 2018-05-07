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

namespace Rest_Easy_Hotel_Management_System.Domain_Layer
{
    public partial class GuestListForm : Form
    {
        #region DataMembers

        private bool guestListFormClosed = false;    //necessary to determine if the form has been closed
        private GuestController guestController;
        private Home mdiForm;

        #endregion

        #region Properties
        public bool GuestListFormClosed
        {
            get { return guestListFormClosed; }
            set { guestListFormClosed = value; }
        }


        #endregion
        public GuestListForm(GuestController aController)
        {
            InitializeComponent();
            guestController = aController;
        }

        #region Form Events

        private void GuestListForm_Load(object sender, EventArgs e)
        {
            guestListView.View = View.Details;
            setUpGuestListView();           
            mdiForm = (Home)this.MdiParent;

            this.ControlBox = false;
        }

        private void GuestListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            guestListFormClosed = true;
        }

        #endregion

        #region Setting Up ListView Control
        //these methods set up the list view control

        public void setUpGuestListView()
        {
            ListViewItem guestDetails;
            Collection<Guest> guests = guestController.AllGuests; 

            //Clear current List View control
            guestListView.Clear();

            //Set up the collumns of the List View 
            guestListView.Columns.Insert(0, "GuestID", 120, HorizontalAlignment.Left);
           // guestListView.Columns.Insert(1, "Title", 120, HorizontalAlignment.Left);
            guestListView.Columns.Insert(1, "FirstName", 120, HorizontalAlignment.Left);
            guestListView.Columns.Insert(2, "Surname", 120, HorizontalAlignment.Left);
            guestListView.Columns.Insert(3, "AddressLine1", 120, HorizontalAlignment.Left);
            guestListView.Columns.Insert(4, "AddressLine2", 120, HorizontalAlignment.Left);
            guestListView.Columns.Insert(5, "Country", 120, HorizontalAlignment.Left);
            guestListView.Columns.Insert(6, "Postal Code", 120, HorizontalAlignment.Left);
            guestListView.Columns.Insert(7, "Telephone", 120, HorizontalAlignment.Left);
            guestListView.Columns.Insert(8, "Email", 120, HorizontalAlignment.Left);

            //add guest details to each ListView item
            foreach(Guest guest in guests)
            {
                guestDetails = new ListViewItem();
                guestDetails.Text = Convert.ToString(guest.GuestID);
               // guestDetails.SubItems.Add(guest.Title);
                guestDetails.SubItems.Add(guest.FirstName);
                guestDetails.SubItems.Add(guest.Surname);
                guestDetails.SubItems.Add(guest.AddressLine1);
                guestDetails.SubItems.Add(guest.AddressLine2);
                guestDetails.SubItems.Add(guest.Country);
                guestDetails.SubItems.Add(guest.PostalCode);
                guestDetails.SubItems.Add(guest.TelephoneNumber);
                guestDetails.SubItems.Add(guest.EmailAddress);

                guestListView.Items.Add(guestDetails);
                    
            }
            guestListView.Refresh();
            guestListView.GridLines = true;



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

        private void listViewLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
