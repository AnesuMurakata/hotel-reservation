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
    public partial class LogInForm : Form
    {

        private ReceptionistController receptionistController;
        private Home home;

        public LogInForm() 
        
        {
            InitializeComponent();
            receptionistController = new ReceptionistController();
            home = new Home();
        
        }

 



        private void LogInForm_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            this.ControlBox = false;
        }

        private void button1_Click(object sender, EventArgs e)//login button
        {
            Receptionist aEmp = new Receptionist();

            aEmp = receptionistController.FindByReceptionistID(textBox1.Text.Trim());
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0)
            {
                MessageBox.Show("You forgot to enter your ID or Password! Please try again!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            else if (aEmp == null || !(aEmp.Password.Equals(textBox2.Text)))
            {
                MessageBox.Show("Incorrect Login Credentials!", "Input Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            else
            {

                
                if (aEmp.Password.Equals(textBox2.Text))
                {
                    this.Hide();
             
                    Home obj= new Home();
                    obj.Show();

                }
              
            }
            
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                button1_Click(sender, e);

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            //populate the text boxes
            if (result == DialogResult.Yes)
            {

                Application.Exit();


            }


        }
    }
}
