using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest_Easy_Hotel_Management_System
{
    public class Room
    {
        #region DataMembers

        private string roomNumber;
        private string floor;

        #endregion

        #region Properties

        public string Floor
        {
            get { return floor; }
            set { floor = value; }
        }


        public string RoomNumber
        {
            get { return roomNumber; }
            set { roomNumber = value; }
        }


        #endregion

        #region Constructors

        public Room() { }

        public Room(string roomNumber, string floor)
        {
            this.roomNumber = roomNumber;
            this.floor = floor;
        }
        #endregion



    }
}
