using Rest_Easy_Hotel_Management_System.Data_Access_layer;
using Rest_Easy_Hotel_Management_System.Domain_Layer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visifire.Charts;

namespace Rest_Easy_Hotel_Management_System.Presentation_Layer
{
    public partial class ReportForm : Form
    {
        private BookingController bookingController;
     

        public ReportForm(BookingController bookingController)
        {
            InitializeComponent();
            this.bookingController = bookingController;
           
            
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM yyyy";
            dateTimePicker1.ShowUpDown = true; // to prevent the calendar from being displayed
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (dateTimePicker1.Value.Month < 6 || dateTimePicker1.Value.Year !=2015)
            {
                MessageBox.Show("Reports Unvailable for these Dates", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }





            Axis a = new Axis();
            a.Title = "Days of the Month";
           Axis c = new Axis();
           c.Title = "Number of Rooms Ocuppied";


            Chart roomsChart = new Chart();
            roomsChart.AxesX.Add(a);
            roomsChart.AxesY.Add(c);
            Title d = new Title();
            d.Text = "Occupancy Report for the month: " + dateTimePicker1.Value.ToString("MMMM") +" "+ dateTimePicker1.Value.Year;
            roomsChart.Titles.Add(d);
  

            DataSeries day1 = new DataSeries();
            day1.RenderAs = RenderAs.Column;
        
   

            day1.ShowInLegend = false;
  



           
            double[] occupancyPerDay= new double[31];
            occupancyPerDay[0] = 0;
            occupancyPerDay[1] = 0;
            occupancyPerDay[2] = 0;
            occupancyPerDay[3] = 0;
            occupancyPerDay[4] = 0;
            occupancyPerDay[5] = 0;
            occupancyPerDay[6] = 0;
            occupancyPerDay[7] = 0;
            occupancyPerDay[8] = 0;
            occupancyPerDay[9] = 0;
            occupancyPerDay[10] = 0;
            occupancyPerDay[11] = 0;
            occupancyPerDay[12] = 0;
            occupancyPerDay[13] = 0;
            occupancyPerDay[14] = 0;
            occupancyPerDay[15] = 0;
            occupancyPerDay[16] = 0;
            occupancyPerDay[17] = 0;
            occupancyPerDay[18] = 0;
            occupancyPerDay[19] = 0;
            occupancyPerDay[20] = 0;
            occupancyPerDay[21] = 0;
            occupancyPerDay[22] = 0;
            occupancyPerDay[23] = 0;
            occupancyPerDay[24] = 0;
            occupancyPerDay[25] = 0;
            occupancyPerDay[26] = 0;
            occupancyPerDay[27] = 0;
            occupancyPerDay[28] = 0;
            occupancyPerDay[29] = 0;
            occupancyPerDay[30] = 0;


          //  daysTable = bookingDB.ReadDataRooms();
       //     (DataRow dayRow in daysTable.Rows
            Collection<Booking> temp = bookingController.AllBookings;

            //get the month off the date time picker 
            DateTime thisMonth= dateTimePicker1.Value; 
            

            //updating correct occupancy for each dy
            foreach (Booking b in temp)

            {
                //gotta iterate through each booking update the occupancy
                DateTime startDate = Convert.ToDateTime(b.StartDate);
                DateTime endDate = Convert.ToDateTime(b.EndDate);
                //get the correct Occupancy index to update
/*
 *
                int y = endDate.Day;

                for (int x = startDate.Day; x <= y; x++)
                {

                    occupancyPerDay[x - 1] = occupancyPerDay[x - 1] + 1;
                }

*/
                DateTime y = endDate;
                for (DateTime x =startDate; x.Date<=y.Date; x.AddDays(1))
                {
                    if(x.Month==thisMonth.Month)
                    {
                        int index = (x.Day)-1;
                        occupancyPerDay[index] = occupancyPerDay[index] + 1;
                    }
                    x = x.AddDays(1);
                   
                }




            }


            for (int i = 0; i <= 30; i++)
            {
                //if months 


                DataPoint aPoint = new DataPoint();
                aPoint.LabelText = Convert.ToString(occupancyPerDay[i] + 1);

                //set x & y value for a data point

                aPoint.AxisXLabel = (Convert.ToString(i + 1));
                aPoint.YValue = Convert.ToDouble(occupancyPerDay[i]);

                //only add particular points for certain months
                if(i==30)
                {
                    if(thisMonth.Month ==2 || thisMonth.Month ==4 || thisMonth.Month ==6 || thisMonth.Month ==9|| thisMonth.Month == 11)
                    {
                        continue;
                    }
                }
                if(i==29)
                {
                    if(thisMonth.Month ==2)
                    {
                        continue;
                    }
                }

                day1.DataPoints.Add(aPoint);

            }
        
            roomsChart.Series.Add(day1);
            





           roomsChart.SmartLabelEnabled = true;

            elementHost1.Child = roomsChart;


        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}