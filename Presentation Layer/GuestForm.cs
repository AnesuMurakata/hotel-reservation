using Rest_Easy_Hotel_Management_System.Domain_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; //for using regex
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rest_Easy_Hotel_Management_System.Presentation_Layer
{
    public partial class GuestForm : Form
    {
        public Guest guest;
        public GuestController guestController;
        public bool guestFormClosed = false;
        private Home mdiForm;
        private FormState myState = FormState.WhileBooking;
        private PaymentController paymentController;
        private Booking aBooking;
        private BookingController bookingController;

        public enum FormState
        {
            Add =0,
            Edit =1,
            Delete =2, 
            WhileBooking =3,
        
        }
        public GuestForm(GuestController aController, PaymentController aPController, FormState aState)
            : base()
        {
            InitializeComponent();
            guestController = aController;
            paymentController = aPController;
            myState = aState;
       
        }
     



        public GuestForm(GuestController aController, PaymentController aPController, FormState aState, Booking b, BookingController bookingController) : base()
        {
            InitializeComponent();
            guestController = aController;
            paymentController =aPController;
            this.bookingController = bookingController;
            myState = aState;
            aBooking = b;
        }

        private void GuestForm_Load(object sender, EventArgs e)
        {
            mdiForm=(Home)this.MdiParent;
            showRequiredFields(myState);

            this.ControlBox = false;
           
        }

        private void GuestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            guestFormClosed = true;
        }

        private void GuestForm_Activated(object sender, EventArgs e)
        {
            guestFormClosed = false;
         
        }

      

        private void button2_Click(object sender, EventArgs e) //add guest
        {
            if ((myState == FormState.Add) || ((myState == FormState.WhileBooking) && button2.Text == "Add Guest")
                || (myState ==FormState.Edit))
            {
                Regex validateEmail = new Regex(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");


                //https://msdn.microsoft.com/en-us/library/01escwtf(v=vs.110).aspx



                Regex testForNonNumeric = new Regex(@"\D");

                Regex testForLetters = new Regex(@"^[a-zA-Z ]+$"); // @"^[a-zA-Z ]+$" for space character 



                if (FirstNameTextBox.Text == "")
                {
                    MessageBox.Show("Please Enter First Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //https://msdn.microsoft.com/en-us/library/system.windows.forms.messageboxicon(v=vs.110).aspx
                    FirstNameTextBox.Focus(); //focuses on text box with error

                    return;
                }

                else if (LastNameTextBox.Text == "")
                {
                    MessageBox.Show("Please Enter Last Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LastNameTextBox.Focus();
                    return;
                }

              

              




                else if (TelephoneTextBox.Text == "")
                {
                    MessageBox.Show("Please Enter Your Telephone Number", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TelephoneTextBox.Focus();
                    return;
                }

                else if (TelephoneTextBox.TextLength < 10)
                {
                    MessageBox.Show("Telephone number must contains 10 digits", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TelephoneTextBox.Focus();
                    return;
                }

                else if (TelephoneTextBox.TextLength > 10)
                {
                    MessageBox.Show("Telephone number must contains 10 digits", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TelephoneTextBox.Focus();
                    return;
                }

                else if (testForNonNumeric.IsMatch(TelephoneTextBox.Text))
                {
                    MessageBox.Show("Telephone number must contain digits only", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TelephoneTextBox.Focus();
                    return;
                }

                else if (EmailTextBox.Text == "")
                {
                    MessageBox.Show("Please Enter An Email Address", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EmailTextBox.Focus();
                    return;
                }

                else if (!validateEmail.IsMatch(EmailTextBox.Text))
                {
                    MessageBox.Show("Invalid Email Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EmailTextBox.Focus();
                    return;

                }

               
                else
                {

                    


                    //go to next form 
                    if (myState ==FormState.Add)
                    {
                        guest = PopulateObject();
                        guestController.ADD(guest);
                        MessageBox.Show("Guest successfully added", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearAll();
                        this.Hide();
                    }
                    if (myState ==FormState.WhileBooking)
                    {

                        guest = PopulateObject();
                        aBooking.DepositPaid = "false";
                        aBooking.GuestID = guest.GuestID;

                        bookingController.ADD(aBooking);
                        guestController.ADD(guest);
                        MessageBox.Show("Guest successfully added and booking successfully made", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                      
                        //would they like to pay now
                        DialogResult result = MessageBox.Show("Would you like to pay now", "Pay now?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            PaymentDetailsForm paymentDetailsForm = new PaymentDetailsForm(paymentController,
                                aBooking, guest, bookingController);
                            paymentDetailsForm.MdiParent = (Home)this.MdiParent;        // Setting the MDI Parent
                            paymentDetailsForm.StartPosition = FormStartPosition.CenterParent;
                            this.Hide();
                            paymentDetailsForm.Show();
                        }
                        else
                        {
                            //go straight to the email

                            ConfirmationForm cf = new ConfirmationForm(guest, aBooking);

                            cf.StartPosition = FormStartPosition.CenterParent;
                            cf.Show();
                            this.Hide();
                        }
                        ClearAll();

                     
                    }
                    if (myState == FormState.Edit)
                    {
                        Guest g =new Guest();
                        g.GuestID= textBox1.Text;
                        g.FirstName= FirstNameTextBox.Text;
                        g.Surname = LastNameTextBox.Text;

                        g.TelephoneNumber = TelephoneTextBox.Text;
                        g.EmailAddress = EmailTextBox.Text;


                        DialogResult result = MessageBox.Show("Are you sure you want to edit guest", "Edit Guest", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        //populate the text boxes
                        if (result == DialogResult.Yes)
                        {
                            //we must delete the guest tell them guest has been successfully deleted
                            guestController.Edit(g);
                            MessageBox.Show("Guest successfully editted", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearAll();
                            
                            this.Hide();


                        }
                        else
                        {
                            //reset the controls
                            showRequiredFields(FormState.Edit);
                        }






                        
                    }




                }

            }

            else if (((myState == FormState.WhileBooking) && (button2.Text == "Verify Guest")) || (myState == FormState.Delete))
            {
               
                    
                    if (GuestIDTextBox.Text == "")
                    {
                        MessageBox.Show("Please Enter A Guest ID to search for", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        GuestIDTextBox.Focus();
                        return;
                    }
                    else if(guestController.FindByGuestID(GuestIDTextBox.Text) ==null)
                    {
                        MessageBox.Show("Guest not found", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        GuestIDTextBox.Focus();
                        return;
                    }
                    else
                    {
                        Guest temp = guestController.FindByGuestID(GuestIDTextBox.Text);
                        FirstNameTextBox.Text = temp.FirstName;
                        LastNameTextBox.Text = temp.Surname;

                        TelephoneTextBox.Text = temp.TelephoneNumber;

                        EmailTextBox.Text = temp.EmailAddress;
                        GuestIDTextBox.Text = temp.GuestID;


                        if(myState ==FormState.WhileBooking)
                        {
                            MessageBox.Show("Guest has been verified", "Verified", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //add the booking
                            aBooking.GuestID = temp.GuestID;
                            aBooking.DepositPaid = "false";
                            bookingController.ADD(aBooking);
                            MessageBox.Show("Booking has been successfully made", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                            //populate the text boxes
                            DialogResult result = MessageBox.Show("Would you like to pay now", "Pay now?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                PaymentDetailsForm paymentDetailsForm = new PaymentDetailsForm(paymentController,aBooking, temp, bookingController);
                                paymentDetailsForm.MdiParent = (Home)this.MdiParent;        // Setting the MDI Parent
                                paymentDetailsForm.StartPosition = FormStartPosition.CenterParent;
                                this.Hide();
                                paymentDetailsForm.Show();
                            }
                            else
                            {
                                //go straight to the email

                                ConfirmationForm cf = new ConfirmationForm(temp, aBooking);

                                cf.StartPosition = FormStartPosition.CenterParent;
                                cf.Show();
                                this.Hide();
                            }
                        }
                        if(myState ==FormState.Delete)
                        {
                           DialogResult result = MessageBox.Show("Are you sure you want to delete guest", "Delete guest", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                            //populate the text boxes
                           if (result == DialogResult.Yes)
                           {
                               //we must delete the guest tell them guest has been successfully deleted
                               guestController.Delete(temp);
                               MessageBox.Show("Guest has been deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               this.Hide();


                           }
                           else
                           {
                               //reset the controls
                               showRequiredFields(FormState.Delete);
                           }
                            
                        }

                        
                        
                     }
            }
       
            
        }

      

        private void ClearAll()
        {
            FirstNameTextBox.Text = "";
            LastNameTextBox.Text = "";

            TelephoneTextBox.Text = "";

            EmailTextBox.Text = "";
            GuestIDTextBox.Text = "";
            textBox1.Text = "";
        }
          
        

  



        private Guest PopulateObject()
        {
            

            guest = new Guest();
            guest.GuestID = guestController.GenerateGuestID();
            guest.FirstName= FirstNameTextBox.Text;
            guest.Surname = LastNameTextBox.Text;

            guest.TelephoneNumber = TelephoneTextBox.Text;
            guest.EmailAddress = EmailTextBox.Text;




          
            return guest;
        }

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

 

        #region Utility Methods

        private void showRequiredFields(FormState aState)
        {
            button3.Visible = false;
            textBox1.Visible = false;
            //add
            if (aState ==FormState.Add)
            {
                NewGuestRadioButton.Visible = false;
                ExistingGuestRadioButton.Visible = false;
                label19.Visible = false;
                GuestIDTextBox.Visible = false;
                
            }
            
            if(aState ==FormState.WhileBooking)
            {
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label17.Visible = false;
                label18.Visible = false;
                label19.Visible = false;
                GuestIDTextBox.Visible = false;
                FirstNameTextBox.Visible = false;
                LastNameTextBox.Visible = false;

                TelephoneTextBox.Visible = false;

                EmailTextBox.Visible = false;
                button2.Visible = false;
               

            }
            if ((aState == FormState.Edit) || (aState ==FormState.Delete))
            {
                NewGuestRadioButton.Visible = false;
                ExistingGuestRadioButton.Visible = false;
                label19.Visible = true;
                GuestIDTextBox.Visible = true;

                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label17.Visible = false;
                label18.Visible = false;

                FirstNameTextBox.Visible = false;
                LastNameTextBox.Visible = false;

                TelephoneTextBox.Visible = false;

                EmailTextBox.Visible = false;
                button2.Visible = false;
                button3.Visible = true;
                ClearAll();

            }  
   
            




        }



        #endregion

        private void NewGuestRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label17.Visible = true;
            label18.Visible = true;
            label19.Visible = false;

            GuestIDTextBox.Visible = false;
            FirstNameTextBox.Visible = true;
            LastNameTextBox.Visible = true;

            TelephoneTextBox.Visible = true;

            EmailTextBox.Visible = true;

            FirstNameTextBox.Enabled = true;
            LastNameTextBox.Enabled = true;

            TelephoneTextBox.Enabled = true;

            EmailTextBox.Enabled = true;

            GuestIDTextBox.Text = "";


            button2.Text = "Add Guest";
            button2.Visible = true;

        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            ClearAll();
            label10.Visible = false;
            label11.Visible = true;
            label12.Visible = true;
            label17.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            GuestIDTextBox.Visible = true;
            FirstNameTextBox.Visible = true;
            LastNameTextBox.Visible = true;

            TelephoneTextBox.Visible = true;

            EmailTextBox.Visible = true;

             FirstNameTextBox.Enabled = false;
             LastNameTextBox.Enabled = false;

             TelephoneTextBox.Enabled = false;
             
             EmailTextBox.Enabled = false;

             button2.Text = "Verify Guest";
             button2.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //check if the field is empty
            if (GuestIDTextBox.Text == "")
            {
                MessageBox.Show("Please input a guestID", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //https://msdn.microsoft.com/en-us/library/system.windows.forms.messageboxicon(v=vs.110).aspx
                FirstNameTextBox.Focus(); //focuses on text box with error

                return;
            }
            //if the guest doesnt exist
            else if(guestController.FindByGuestID(GuestIDTextBox.Text)==null)
            {
                MessageBox.Show("Guest not found", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GuestIDTextBox.Focus();
                return;
            }
            //if the guest exists
            else
            {
                Guest temp = guestController.FindByGuestID(GuestIDTextBox.Text);
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label17.Visible = true;
                label18.Visible = true;
                label19.Visible = false;

                FirstNameTextBox.Visible = true;
                LastNameTextBox.Visible = true;

                TelephoneTextBox.Visible = true;

                EmailTextBox.Visible = true;
               

               
                GuestIDTextBox.Visible=false;
                button3.Visible =false;

                FirstNameTextBox.Text =temp.FirstName;
                LastNameTextBox.Text =temp.Surname;

                TelephoneTextBox.Text =temp.TelephoneNumber;

                EmailTextBox.Text = temp.EmailAddress;

                if (myState ==FormState.Edit)
                {
                    label10.Text = "Edit Guest with ID:";
                    FirstNameTextBox.Enabled = true;
                    LastNameTextBox.Enabled = true;

                    TelephoneTextBox.Enabled = true;
                  
                    EmailTextBox.Enabled = true;

                    button2.Text = "Save Changes";
                    button2.Visible = true;

                    textBox1.Text = temp.GuestID;
                    textBox1.Enabled = false;
                    textBox1.Visible = true;

                }
                if(myState ==FormState.Delete)
                {
                    label10.Text = "Delete Guest with ID:";
                    FirstNameTextBox.Enabled = false;
                    LastNameTextBox.Enabled = false;

                    TelephoneTextBox.Enabled = false;
                   
                    EmailTextBox.Enabled = false;
                    button2.Text = "Delete";
                    button2.Visible = true;
                    textBox1.Text = temp.GuestID;
                    textBox1.Enabled = false;
                    textBox1.Visible = true;
                }


                

                

                

            }
         

       
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        



    }
}
