using Rest_Easy_Hotel_Management_System.Data_Access_layer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest_Easy_Hotel_Management_System.Domain_Layer
{
    public class ReceptionistController
    {

        #region Data Member
        private ReceptionistDB receptionistDB;       
        private Collection <Receptionist> receptionists;

        #endregion

        public ReceptionistController()
        {
            receptionistDB = new ReceptionistDB();
            receptionists = receptionistDB.AllReceptionists;  
        }


        public Collection<Receptionist> AllReceptionists
        {
            get
            {
                return receptionists;
            }
        }

        #region Look Up

        public int FindIndex(Receptionist receptionist)
        {
            int index = 0;
            bool found = false;
            while (!found && index < receptionists.Count)
            {
                found = (receptionists[index].ReceptionistID == receptionist.ReceptionistID);
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
        ///////////////////////////////////////////////////////////////////////////////////////////////////not yet sure where we gonna use this method
        public int FindIndex(Collection<Receptionist> theReceptionists, Receptionist receptionist)
        {
            int index = 0;
            bool found = false;
            while (!found && index < theReceptionists.Count)
            {
                found = (theReceptionists[index].ReceptionistID == receptionist.ReceptionistID);
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

        public Receptionist FindByReceptionistID(string idValue)   // could be useful for deleting and editing
        {
            int position = 0;
            bool found = (idValue == receptionists[position].ReceptionistID);
            while (!found && position < receptionists.Count)
            {
                found = (idValue == receptionists[position].ReceptionistID);
                if (!found)
                {
                    position += 1;
                }

            }
            if (found)
            {
                return receptionists[position];
            }
            else
            {
                return null;
            }

        }

        #endregion



    }
}
