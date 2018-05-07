using Rest_Easy_Hotel_Management_System.Data_Access_layer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest_Easy_Hotel_Management_System.Domain_Layer
{
    public class RoomRateController
    {
        #region Data Member

        private RoomRateDB roomRateDB;
        private Collection<RoomRate> roomRates;


        #endregion

        public RoomRateController()
        {
            roomRateDB = new RoomRateDB();
            roomRates = roomRateDB.AllRoomRates;
        }
        public Collection<RoomRate> AllRoomRates
        {
            get { return roomRates; }
            set { roomRates = value; }

        }

        #region Look Up

        public int FindIndex(RoomRate roomRate)
        {
            int index = 0;
            bool found = false;
            while (!found && index < roomRates.Count)
            {
                found = (roomRates[index].Season == roomRate.Season);
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
        public int FindIndex(Collection<RoomRate> theRoomRates, RoomRate roomRate)
        {
            int index = 0;
            bool found = false;
            while (!found && index < theRoomRates.Count)
            {
                found = (theRoomRates[index].Season == roomRate.Season);
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

        public RoomRate FindBySeason(string season)   
        {
            int position = 0;
            bool found = (season == roomRates[position].Season);
            while (!found && position < roomRates.Count)
            {
                found = (season == roomRates[position].Season);
                if (!found)
                {
                    position += 1;
                }

            }
            if (found)
            {
                return roomRates[position];
            }
            else
            {
                return null;
            }

        }



        #endregion





    }
}
