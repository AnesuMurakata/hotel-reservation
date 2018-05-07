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
    class RoomRateDB : DB
    {
        #region DataMembers

        private static string table = "RoomRates";
        private string sql_SELECT = "SELECT * FROM " + table;
        private Collection<RoomRate> roomRates = new Collection<RoomRate>();


        #endregion

        #region Constructors
        public RoomRateDB()
            : base()
        {
            ReadDataFromTable(sql_SELECT, table);   //Get the data from table
        }

        #endregion

        #region Properties

        public Collection<RoomRate> AllRoomRates
        {
            get
            {
                return roomRates;
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
                    FillRoomRates(reader, table, roomRates);       //Fill the collection –   
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

        private void FillRoomRates(SqlDataReader reader, string dataTable,
                                                             Collection<RoomRate> theRoomRates)
        {
            RoomRate roomRate;
            while (reader.Read())                          //While you still have stuff to read
            {
                roomRate = new RoomRate();

                //get all the relevant collumns from the booking table  
                roomRate.Season = (reader.GetString(0).Trim());
                roomRate.StartDate = reader.GetString(1).Trim();
                roomRate.EndDate = reader.GetString(2).Trim();
                roomRate.PricePerNight = reader.GetDecimal(3);

                theRoomRates.Add(roomRate);             //add to the collection
            }
        }


        #endregion


    }
}
