using Rest_Easy_Hotel_Management_System.Domain_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rest_Easy_Hotel_Management_System.Presentation_Layer
{
    public partial class PaymentDetailsForm : Form
    {

        public Payment payment;
        public PaymentController paymentController;
        private Booking aBooking;
        Regex testForNonNumeric = new Regex(@"\D");
        private Guest aGuest;
        private BookingController bookingController;

        private Home mdiForm;
        public PaymentDetailsForm(PaymentController p, Booking b, Guest g, BookingController h)
        {
            InitializeComponent();
            paymentController = p;
            aBooking = b;
            aGuest = g;
            bookingController = h;


        }

  

        private void PaymentDetailsForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            mdiForm = (Home)this.MdiParent;

            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");
            comboBox1.Items.Add("4");
            comboBox1.Items.Add("5");
            comboBox1.Items.Add("6");
            comboBox1.Items.Add("7");
            comboBox1.Items.Add("8");
            comboBox1.Items.Add("9");
            comboBox1.Items.Add("10");
            comboBox1.Items.Add("11");
            comboBox1.Items.Add("12");


            comboBox2.Items.Add("17");
            comboBox2.Items.Add("18");
            comboBox2.Items.Add("19");
            comboBox2.Items.Add("20");
            comboBox2.Items.Add("21");
            comboBox2.Items.Add("22");
            comboBox2.Items.Add("23");
            comboBox2.Items.Add("24");
            comboBox2.Items.Add("25");
            comboBox2.Items.Add("26");
            comboBox2.Items.Add("27");
            comboBox2.Items.Add("28");
            comboBox2.Items.Add("29");
            comboBox2.Items.Add("30");
            comboBox2.Items.Add("31");
            comboBox2.Items.Add("32");
            comboBox2.Items.Add("33");
            comboBox2.Items.Add("34");
            comboBox2.Items.Add("35");
           




        }

        private Payment PopulateObject(Booking b)
        {


            payment = new Payment();

            payment.PaymentID = paymentController.GeneratePaymentID();
            payment.Date = DateTime.Today.ToShortDateString();
            payment.PaymentType= "Deposit";
            payment.PaymentAmount= Convert.ToDecimal(b.BookingID);
            payment.BookingID = b.BookingID;
            payment.CreditCardNumber = textBox1.Text;
            payment.CreditCardExpiryDate = comboBox1.SelectedItem.ToString() + comboBox2.SelectedItem.ToString();
            payment.CreditCardCVV = textBox3.Text;

         
            return payment;
        }

        private void button1_Click(object sender, EventArgs e)
        {



                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please Enter Your Credit Card Number", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                    return;
                }

                else if (textBox1.TextLength < 16)
                {
                    MessageBox.Show("Credit card number must contain 16 digits", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                    return;
                }

                else if (textBox1.TextLength > 16)
                {
                    MessageBox.Show("Credit card number must contain 16 digits", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                    return;
                }

                else if (testForNonNumeric.IsMatch(textBox1.Text))
                {
                    MessageBox.Show("Credit card number must contain digits only", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                    return;
                }




         

                if (comboBox1.SelectedIndex == -1)//Nothing selected
                {
                    MessageBox.Show("Please enter credit card expiry date", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBox1.Focus();
                    return;
                }

                if (comboBox2.SelectedIndex == -1)//Nothing selected
                {
                    MessageBox.Show("Please enter credit card expiry date", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBox2.Focus();
                    return;
                }

                if ( Convert.ToInt32(comboBox1.SelectedItem) < 10 && Convert.ToInt32(comboBox2.SelectedItem) ==15 )
                {
                    MessageBox.Show("Credit Card is expired", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBox1.Focus();
                    return;
                }


                else if (textBox3.Text == "")
                {
                    MessageBox.Show("Please Enter Your CVV Number", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.Focus();
                    return;
                }

                else if (textBox3.TextLength < 3)
                {
                    MessageBox.Show("CVV number must contain 3 digits", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.Focus();
                    return;
                }

                else if (textBox3.TextLength > 3)
                {
                    MessageBox.Show("CVV number must contain 3 digits", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.Focus();
                    return;
                }

                else if (testForNonNumeric.IsMatch(textBox3.Text))
                {
                    MessageBox.Show("CVV number must contain digits only", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.Focus();
                    return;
                }

                else
                {
                    payment = PopulateObject(aBooking);
                    aBooking.DepositPaid = "true";
                    bookingController.Edit(aBooking);
          
                    paymentController.ADD(payment);
                    MessageBox.Show("Your payment has been verified", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);


                   ConfirmationForm cf= new ConfirmationForm(aGuest, aBooking);
              
                   cf.StartPosition = FormStartPosition.CenterParent;
                   cf.Show();
                   this.Hide();


                }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConfirmationForm cf = new ConfirmationForm(aGuest, aBooking);

            cf.StartPosition = FormStartPosition.CenterParent;
            cf.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
