using Rest_Easy_Hotel_Management_System.Data_Access_layer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest_Easy_Hotel_Management_System
{
    class RoomDB : DB
    {

        #region DataMembers

        private static string table = "Room";
        private string sql_SELECT = "SELECT * FROM " + table;
        private Collection<Room> rooms = new Collection<Room>();

        #endregion

        #region Constructors

        public RoomDB()
            : base()
        {
            ReadDataFromTable(sql_SELECT, table);   //Get the data from table
        }

        #endregion

        #region Properties
        public Collection<Room> AllRooms
        {
            get
            {
                return rooms;
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
                   
                    FillRooms(reader, table, rooms);       //Fill the collection – 
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

        private void FillRooms(SqlDataReader reader, string dataTable, Collection<Room> rooms)
        {
            Room room;
            while (reader.Read())                          //While you still have stuff to read
            {
                room = new Room(); 

                //get all the relevant collumns from the booking table  
                room.RoomNumber = reader.GetString(0).Trim();        
                room.Floor = reader.GetString(1).Trim();


                rooms.Add(room);             //add to the collection
            }
        }


        #endregion

    

     

   





       


        





    }
}
