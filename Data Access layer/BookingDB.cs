using Rest_Easy_Hotel_Management_System.Domain_Layer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest_Easy_Hotel_Management_System.Data_Access_layer
{
    class BookingDB : DB
    {
        #region DataMembers

        private static string table = "Booking";
        private string sql_SELECT = "SELECT * FROM " + table;
        private Collection<Booking> bookings = new Collection<Booking>();

        #endregion

        #region Constructors

        public BookingDB()
            : base()
        {
            ReadDataFromTable(sql_SELECT, table);   //Get the data from table
        }

        #endregion

        #region Properties

        public Collection<Booking> AllBookings
        {
            get
            {
                return bookings;
            }
        }

        #endregion

        #region DataReader

        private string ReadDataFromTable(string selectString, string table)
        {
            SqlDataReader reader;
            SqlCommand command;
            try
            {
                command = new SqlCommand(selectString, cnMain);
                cnMain.Open();             //open the connection
                command.CommandType = CommandType.Text;
                reader = command.ExecuteReader();                        //Read from table
                if (reader.HasRows)
                {
                    // Call the FillEmployeeByRole method see step 2.4
                    FillBookings(reader, table, bookings);       //Fill the collection –   
                }
                reader.Close();   //close the reader 
                cnMain.Close();  //close the connection
                return "success";
            }
            catch (Exception ex)
            {
                cnMain.Close();
                return (ex.ToString());

            }
        }

        private void FillBookings(SqlDataReader reader, string dataTable,
                                                              Collection<Booking> bookings)
        {
            Booking booking;
            while (reader.Read())                          //While you still have stuff to read
            {
                booking = new Booking();

                //get all the relevant collumns from the booking table  
                booking.BookingID = (reader.GetString(0).Trim());
                booking.GuestID = reader.GetString(1).Trim();
                booking.RoomNumber = reader.GetString(2).Trim();
                booking.ReservationDate = reader.GetString(3).Trim();
                booking.StartDate = reader.GetString(4).Trim();
                booking.EndDate = reader.GetString(5).Trim();
                booking.NoOfGuests = reader.GetString(6).Trim();
                booking.Price = reader.GetDecimal(7);
                booking.DepositAmount = reader.GetDecimal(8);
                booking.DepositPaid = reader.GetString(9).Trim();
             
                bookings.Add(booking);             //add to the collection
            }
        }


        #endregion


        #region Database Operations --- Add, Edit & Delete

        public void DatabaseAdd(Booking TempBooking)
        {
            string strSQL = "";

            //Build SQL string for the command
            strSQL = "INSERT into Booking(bookingID, guestID, roomNo, reservationDate, startDate, endDate, noOfGuests, price, depositAmount, depositPaid)" +
                                          "VALUES ('" + GetValueString(TempBooking) + ")";

            //Create & execute the insert command 
            UpdateDataSource(new SqlCommand(strSQL, cnMain));
        }

        public void DatabaseEdit(Booking tempBooking)
        {
            string sqlString = "";
            Booking booking;
            //Build SQL string for the Update command                         

            sqlString = "Update Booking Set guestID = '" + tempBooking.GuestID.Trim() + "'," +
                                            "roomNo = '" + tempBooking.RoomNumber.Trim() + "'," +
                                            "reservationDate = '" + tempBooking.ReservationDate.Trim() + "'," +
                                            "startDate = '" + tempBooking.StartDate.Trim() + "'," +
                                            "endDate = '" + tempBooking.EndDate.Trim() + "'," +
                                            "noOfGuests ='" + tempBooking.NoOfGuests.ToString() + "'," +
                                
                                             "price = " + tempBooking.Price.ToString() + " ," +
                                             "depositAmount = " + tempBooking.DepositAmount.ToString() + " ," +
                                             "depositPaid ='" + tempBooking.DepositPaid.ToString() + "' " +
                                     

                             "WHERE (bookingID = '" + tempBooking.BookingID.Trim() + "')";


            //Create & execute the update command 
            UpdateDataSource(new SqlCommand(sqlString, cnMain));
        }

        public bool DatabaseDelete(Booking booking)
        {
            string SQLstring = "";
            bool success = false;
            //Build SQL string for the DELETE command
            SQLstring = "DELETE FROM  Booking WHERE bookingID = '" + booking.BookingID.Trim() + "'";


            //Update database by executing new SQL statement
            success = UpdateDataSource(new SqlCommand(SQLstring, cnMain));
            return true;
        }

        private string GetValueString(Booking tempBooking)
        {
            string aStr;

            aStr = tempBooking.BookingID.Trim() + "' , '" +
                     tempBooking.GuestID.Trim() + "' , '" +
                  tempBooking.RoomNumber.Trim() + "' , '" +
             tempBooking.ReservationDate.Trim() + "' , '" +
                   tempBooking.StartDate.Trim() + "' , '" +
                     tempBooking.EndDate.Trim() + "' , '" +
                  tempBooking.NoOfGuests.Trim() + "' , " +

                   tempBooking.Price.ToString() + " , " +
           tempBooking.DepositAmount.ToString() + " , '" +
                 tempBooking.DepositPaid.Trim() + "' ";


            return aStr;
        }







        #endregion




    }
}
