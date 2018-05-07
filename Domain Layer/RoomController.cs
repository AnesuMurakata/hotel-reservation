using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest_Easy_Hotel_Management_System
{

    public class RoomController
    {

        #region Data Member
        private RoomDB roomDB;
        private Collection <Room> rooms;

           public RoomController()
        {
            roomDB = new RoomDB();     
            rooms = roomDB.AllRooms;  
        }

        public Collection<Room> AllRooms
        {
            get
            {
                return rooms;
            }
        }


        #endregion

        #region Look Up

        public int FindIndex(Room room)
        {
            int index = 0;
            bool found = false;
            while (!found && index < rooms.Count)
            {
                found = (rooms[index].RoomNumber == room.RoomNumber);
                if (!found)
                {
                    index++;
                }
            }
            if (found)
            {
                return index;
            }
            else
            {
                return -1;
            }

        }
       
        public int FindIndex(Collection<Room> theRooms, Room room)
        {
            int index = 0;
            bool found = false;
            while (!found && index < theRooms.Count)
            {
                found = (theRooms[index].RoomNumber == room.RoomNumber);
                if (!found)
                {
                    index++;
                }

            }
            if (found)
            {
                return index;

            }
            else
            {
                return -1;
            }

        }

        public Room FindByRoomNumber(string idValue)   // could be useful for deleting and editing
        {
            int position = 0;
            bool found = (idValue == rooms[position].RoomNumber);
            while (!found && position < rooms.Count)
            {
                found = (idValue == rooms[position].RoomNumber);
                if (!found)
                {
                    position += 1;
                }

            }
            if (found)
            {
                return rooms[position];
            }
            else
            {
                return null;
            }

        }

        #endregion




    }
}
