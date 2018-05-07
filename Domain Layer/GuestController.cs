using Rest_Easy_Hotel_Management_System.Data_Access_layer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest_Easy_Hotel_Management_System.Domain_Layer
{
    public class GuestController
    {
        #region Data Member
        private GuestDB guestDB;       
        private Collection<Guest> guests;

        #endregion

        public GuestController()
        {
            guestDB = new GuestDB();     
            guests = guestDB.AllGuests;  
        }

        public Collection<Guest> AllGuests
        {
            get
            {
                return guests;
            }
        }


        #region CRUD functionality - Maintain Collection and Database

        public void ADD(Guest guest)
        {
            //add to the database and collection
            guestDB.DatabaseAdd(guest);  
            guests.Add(guest);
        }

        public void Edit (Guest guest)
        {
           
            Guest tempGuest;
            tempGuest = FindByGuestID(guest.GuestID);
            guests.Remove(tempGuest);
            guests.Add(guest);
   



            //edit a guest in the database
            guestDB.DatabaseEdit(guest);

        }

        public bool Delete (Guest guest)
        {
            bool success = false;
            int position = 0;
            //find the entry in the collection and remove 
            position = FindIndex(guest);
            if(position >=0)
            {
                guests.RemoveAt(position);

            }
            //remove the entry from the database
            success = guestDB.DatabaseDelete(guest);
            return success;
        }

        #endregion

        #region Look Up
        
        public int FindIndex(Guest guest)
        {
            int index = 0;
            bool found = false;
            while (!found && index < guests.Count)
            {
                found = (guests[index].GuestID == guest.GuestID);
                if(!found)
                {
                    index++;
                }
            }
            if(found)
            {
                return index;
            }
            else
            {
                return -1;
            }

        }

        public int FindIndex(Collection<Guest> theGuests, Guest guest)
        {
            int index =0;
            bool found = false;
            while (!found && index < theGuests.Count)
            {
                found = (theGuests[index].GuestID ==guest.GuestID);
                if(!found)
                {
                    index++;
                }

            }
            if(found)
            {
                return index;

            }
            else
            {
                return -1;
            }

        }

        public Guest FindByGuestID(string idValue)   // could be useful for deleting and editing
        {
            int position = 0;
            bool found = (idValue == guests[position].GuestID);
            while (!found && position < guests.Count)
            {
                found = (idValue == guests[position].GuestID);
                if(!found)
                {
                    position += 1;
                }

            }
            if (found)
            {
                return guests[position];
            }
            else
            {
                return null;
            }

        }

        #endregion


        public string GenerateGuestID()
        {


            int num;

            string guestID = "G"; // variable to hold final booking id 

            System.Random objRandom = new System.Random();
            bool unique = false;

            while (!unique)
            {
                num = objRandom.Next(10000);

                guestID += (num.ToString());


                while (guestID.Length < 8)
                {
                    guestID = guestID + "0";
                }

                if (FindByGuestID(guestID) == null)
                {
                    unique = true;
                }
            }

            return guestID;

        }


    }
}
