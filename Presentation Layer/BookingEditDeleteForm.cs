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
    public partial class BookingEditDeleteForm : Form
    {
        public BookingController bookingController;
        private Home mdiForm;
        private thisFormState myState;
        private RoomController roomController;
        private RoomRateController roomRateController;
        
        public enum thisFormState
        {
            Edit =0,
            Delete=1
        }

        public BookingEditDeleteForm(BookingController aBController, thisFormState aState, RoomController aRController, RoomRateController aRRController)
        {
            InitializeComponent();
            bookingController = aBController;
            roomController = aRController;
            myState = aState;
            roomRateController = aRRController;
            if(myState ==thisFormState.Delete)
            {
                button3.Text = "Delete";
            }
            else
            {
                button3.Text = "Save";
            }
        }

        private void BookingEditDeleteForm_Load(object sender, EventArgs e)
        {

            mdiForm = (Home)this.MdiParent;
            ResetTextBoxes();
            ShowTextFieldsAndLabels(false);
            button3.Visible = false;
            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");
            comboBox1.Items.Add("4");
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            comboBox1.Visible = false;



            
        }
        //search button click 
        private void button1_Click(object sender, EventArgs e)
        {
            //data validation

            //check if the field is empty
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please input a Booking ID", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //https://msdn.microsoft.com/en-us/library/system.windows.forms.messageboxicon(v=vs.110).aspx
                textBox1.Focus(); //focuses on text box with error

                return;
            }
            //if the guest doesnt exist
            else if (bookingController.FindByBookingID(textBox1.Text) == null)
            {
                MessageBox.Show("Booking not found", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
                textBox1.Focus();
                return;
            }
            else 

            {
                

                //populate textboxes with relevenat booking details
                Booking temp = bookingController.FindByBookingID(textBox1.Text);
                //if the booing has passed
                if((DateTime.Today.Date)>= Convert.ToDateTime(temp.StartDate).Date)
                {
                    if (myState == thisFormState.Delete)
                    {
                        if((DateTime.Today.Date)> Convert.ToDateTime(temp.EndDate).Date)
                        {
                            MessageBox.Show("Booking cannot be deleted it as it has already lapsed", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox1.Text = "";
                            textBox1.Focus();
                            return;
                        }
                        else
                        {
                             MessageBox.Show("Booking cannot be deleted as it is in progress", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox1.Text = "";
                            textBox1.Focus();
                            return;
                        }
                        
                    }
                    else
                    {
                        if ((DateTime.Today.Date) > Convert.ToDateTime(temp.EndDate).Date)
                        {
                            MessageBox.Show("Booking cannot be editted it as it has already lapsed", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox1.Text = "";
                            textBox1.Focus();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Booking cannot be editted as it is in progress", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox1.Text = "";
                            textBox1.Focus();
                            return;
                        }
                    }
                }





               //if the guest exists





                //toggle search functionality off
                ToggleSearchFunctionality(false);
                //show all the controll and button 3
                ShowTextFieldsAndLabels(true);
                button3.Visible = true;

               
                textBox2.Text = temp.BookingID;
                textBox3.Text = temp.GuestID;
                textBox4.Text = temp.RoomNumber;
                textBox5.Text = temp.ReservationDate;
                textBox6.Text = temp.StartDate;
                textBox7.Text = temp.EndDate;
                textBox8.Text = temp.NoOfGuests;
                textBox9.Text = temp.Price.ToString();
                textBox10.Text = temp.DepositAmount.ToString();
                textBox11.Text = temp.DepositPaid.ToString();



                if (myState == thisFormState.Delete)
                {
                    //change relevant labels name
                    label2.Text = "Delete Booking with BookingID: ";
                    button3.Text = "Delete";
                    //toggle enabled off
                    ToggleTextBoxesEnabled(false);






                }
                if (myState == thisFormState.Edit)

                {
                    //change relevant labels name
                    label2.Text = "Edit Booking with BookingID: ";
                    button3.Text = "Save";
                    //toggle enabled on
                    ToggleTextBoxesEnabled(true);
                    //set relevenat text boxes to false
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    textBox5.Enabled = false;
                    textBox6.Visible = false;
                    textBox7.Visible = false;
                    textBox8.Visible = false;
                    textBox9.Enabled = false;
                    textBox10.Enabled = false;
                    textBox11.Enabled = false;
                    dateTimePicker1.Value = (Convert.ToDateTime(textBox6.Text)).Date;
                    dateTimePicker2.Value = (Convert.ToDateTime(textBox7.Text)).Date;
                    dateTimePicker1.Visible = true;
                    dateTimePicker2.Visible = true;
                    comboBox1.Visible = true;
                    comboBox1.Text = textBox8.Text;





               
            }




           


            }

            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }




        private void ShowTextFieldsAndLabels(bool b)
        {
            label2.Visible = b;
            label3.Visible = b;
            label4.Visible = b;
            label5.Visible = b;
            label6.Visible = b;
            label7.Visible = b;
            label8.Visible = b;
            label9.Visible = b;
            label10.Visible = b;
            label11.Visible = b;

            textBox2.Visible = b;
            textBox3.Visible = b;
            textBox4.Visible = b;
            textBox5.Visible = b;
            textBox6.Visible = b;
            textBox7.Visible = b;
            textBox8.Visible = b;
            textBox9.Visible = b;
            textBox10.Visible = b;
            textBox11.Visible = b;
  

        }
        private void ToggleSearchFunctionality(bool b)
        {
            label1.Visible = b;
            textBox1.Visible = b;
            button1.Visible = b;
        }
        private void ToggleTextBoxesEnabled(bool b)
        {
            textBox2.Enabled = b;
            textBox3.Enabled = b;
            textBox4.Enabled = b;
            textBox5.Enabled = b;
            textBox6.Enabled = b;
            textBox7.Enabled = b;
            textBox8.Enabled = b;
            textBox9.Enabled = b;
            textBox10.Enabled = b;
            textBox11.Enabled = b;
        }




        public void ResetTextBoxes()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Booking b = new Booking();
            b.BookingID = textBox2.Text;
            b.GuestID =   textBox3.Text;
            b.RoomNumber= textBox4.Text;
            b.ReservationDate= textBox5.Text;
            b.StartDate = textBox6.Text;
            b.EndDate = textBox7.Text;
            b.NoOfGuests = textBox8.Text;
            b.Price = Convert.ToDecimal(textBox9.Text);
            b.DepositAmount = Convert.ToDecimal(textBox10.Text);
            b.DepositPaid = textBox11.Text;
            

            if(myState ==thisFormState.Delete)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete booking", "Delete guest", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                //populate the text boxes
                if (result == DialogResult.Yes)
                {
                    //we must delete the guest tell them guest has been successfully deleted
                    bookingController.Delete(b);
                    MessageBox.Show("Booking has been succesfully deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();


                }
                else
                {
                    //reset the controls
                    ShowTextFieldsAndLabels(false);
                    ResetTextBoxes();
                    button3.Visible =false;
                    ToggleSearchFunctionality(true);
                }
            }
            if(myState ==thisFormState.Edit)
            {
                //validate that start date less than end date
                if(dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
                {
                    MessageBox.Show("Start date value cannot be greater than end date value", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Collection<Room> avail = bookingController.CheckAvailability(dateTimePicker1.Value, dateTimePicker2.Value, roomController.AllRooms, b);
                //ensure that the booking is actually available
                if (avail.Count ==0)
                {
                    MessageBox.Show("New Dates are unvailable", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {

                    //set the room Number
                    b.RoomNumber = avail[0].RoomNumber;
                    //set the start date
                    b.StartDate = dateTimePicker1.Value.ToShortDateString();
                    //set the end date
                    b.EndDate = dateTimePicker2.Value.ToShortDateString();
                    //set the price 
                    b.Price = bookingController.CalculateBookingPrice(dateTimePicker1.Value, dateTimePicker2.Value ,roomRateController.AllRoomRates);
                    //set the deposit 
                    b.DepositAmount =(b.Price/10);
                    //set the deposit paid to false
                    b.DepositPaid = "false";
                    //set number of guests 
                    b.NoOfGuests = comboBox1.Text;

                    bookingController.Edit(b);

                    MessageBox.Show("Your booking has been successfully changed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    return;

                }

               



            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
