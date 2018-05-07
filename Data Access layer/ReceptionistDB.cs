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
    class ReceptionistDB :DB
    {
        #region DataMembers

        private static string table = "Receptionist";
        private string sql_SELECT = "SELECT * FROM " + table;
        private Collection<Receptionist> receptionists = new Collection<Receptionist>();

        #endregion

        #region Constructors

        public ReceptionistDB()
            : base()
        {
            ReadDataFromTable(sql_SELECT, table);  
        }
        #endregion

        #region Properties
        public Collection<Receptionist> AllReceptionists
        {
            get
            {
                return receptionists;
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
                    FillReceptionists(reader, table, receptionists);       //Fill the collection – 
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

        private void FillReceptionists(SqlDataReader reader, string dataTable, Collection<Receptionist> receptionists)
        {
            Receptionist receptionist;
            while (reader.Read())                          //While you still have stuff to read
            {
                receptionist = new Receptionist(); ////////////////////////////////////////////////////////////////////////////add no arguements constructor

                //get all the relevant collumns from the booking table  
                receptionist.ReceptionistID = (reader.GetString(0).Trim());           ////converting an int to a string////////////////////////////////////////
                receptionist.FirstName = (reader.GetString(1).Trim());
                receptionist.Surname = (reader.GetString(2).Trim());
                receptionist.Password = (reader.GetString(3).Trim());


                receptionists.Add(receptionist);             //add to the collection
            }
        }
        #endregion














    }
}
