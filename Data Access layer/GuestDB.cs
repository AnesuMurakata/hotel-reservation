using Rest_Easy_Hotel_Management_System.Domain_Layer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespaces
using System.Data;
using System.Data.SqlClient;
using System.Xml;


namespace Rest_Easy_Hotel_Management_System.Data_Access_layer
{
    class GuestDB : DB
    {
        #region DataMembers

        private static string table = "Guest";
        private string sql_SELECT = "SELECT * FROM " + table;

        private Collection<Guest> guests = new Collection<Guest>();

        #endregion

        #region Constructors

        public GuestDB()
            : base()
        {
            ReadDataFromTable(sql_SELECT, table);   //Get the data from table
        }

        #endregion

        #region Properties
        public Collection<Guest> AllGuests
        {
            get
            {
                return guests;
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
                command = new SqlCommand(selectString, cnMain);                                  ////////////////////////////////////dont know where main is defined
                cnMain.Open();             //open the connection
                command.CommandType = CommandType.Text;
                reader = command.ExecuteReader();                        //Read from table
                if (reader.HasRows)
                {
                    // Call the FillEmployeeByRole method see step 2.4
                    FillGuests(reader, table, guests);       //Fill the collection – 
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

        private void FillGuests(SqlDataReader reader, string dataTable,
                                                              Collection<Guest> guests)
        {
            Guest guest;
            while (reader.Read())                          //While you still have stuff to read
            {
                guest = new Guest(); ////////////////////////////////////////////////////////////////////////////add no arguements constructor

                //get all the relevant collumns from the booking table  
                guest.GuestID = reader.GetString(0).Trim();
                //guest.Title = reader.GetString(1).Trim();
                guest.FirstName = reader.GetString(1).Trim();
                guest.Surname = reader.GetString(2).Trim();
                guest.AddressLine1 = reader.GetString(3).Trim();
                guest.AddressLine2 = reader.GetString(4).Trim();
                guest.Country = reader.GetString(5).Trim();
                guest.PostalCode = reader.GetString(6).Trim();  
                guest.TelephoneNumber = reader.GetString(7).Trim();       
                guest.EmailAddress = reader.GetString(8).Trim();        
               


                guests.Add(guest);             //add to the collection
            }
        }


        #endregion

        #region Database Operations --- Add, Edit & Delete

        public void DatabaseAdd(Guest tempGuest)
        {
            string strSQL = "";

            //Build SQL string for the command
          strSQL = "INSERT into Guest(guestID, firstName, surname, addressLine1, addressLine2, country, postalCode, telephoneNumber, emailAddress)" +
                                        "VALUES ('" + GetValueString(tempGuest) + ")";     ////////////////////////////check sql syntax

            //Create & execute the insert command 
            UpdateDataSource(new SqlCommand(strSQL, cnMain));            ////////////////////////////////////////////////think this will disappear when we get the correct imports
        }

        public void DatabaseEdit(Guest tempGuest)
        {
           string sqlString = "";
            
            //Build SQL string for the Update command                         //////////////////////////////////////////////gotta check this sql command, the command might change if data types change

           sqlString = "Update Booking Set firstName = '" + tempGuest.FirstName.Trim() + "', " +
                                                    "surname = '" + tempGuest.Surname.Trim() + "'," +
                                                "addressLine1 = '" + tempGuest.AddressLine1.Trim() + "'," +
                                                "addressLine2 = '" + tempGuest.AddressLine2.Trim() + "'," +
                                                        "country = '" + tempGuest.Country.Trim() + "'," +
                                                    "postalCode = '" + tempGuest.PostalCode.Trim() + "'," +
                                                "telephoneNumber = '" + tempGuest.TelephoneNumber.Trim() + "'," +
                                                    "emailAddress = '" + tempGuest.EmailAddress.Trim() + "' " +

            "WHERE (guestID = " + Convert.ToString(tempGuest.GuestID).Trim() + ")";


            //Create & execute the update command 
          //  UpdateDataSource(new SqlCommand(sqlString, cnMain));                      
        }

        public bool DatabaseDelete(Guest guest)
        {
            string SQLstring = "";
            bool success = false;
            //Build SQL string for the DELETE command
            SQLstring = "DELETE FROM  Guest WHERE GuestID = '" + Convert.ToString(guest.GuestID).Trim() + "'";


            //Update database by executing new SQL statement
            success = UpdateDataSource(new SqlCommand(SQLstring, cnMain));           
            return true;
        }

 


        private string GetValueString(Guest tempGuest)
        {
            string aStr ="" ;
            aStr = tempGuest.GuestID + "', '" + tempGuest.FirstName + "', '"+ tempGuest.Surname+"', '"+ tempGuest.AddressLine1 + "', '"
                + tempGuest.AddressLine2 +"', '"+ tempGuest.Country + "', '" + 
                tempGuest.PostalCode + "', '"+ tempGuest.TelephoneNumber+ "', '"+ tempGuest.EmailAddress +"'" ;
            return aStr;
        }


        #endregion
    }
}
