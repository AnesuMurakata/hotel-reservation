using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest_Easy_Hotel_Management_System.Domain_Layer
{
    public class Receptionist
    {
        #region DataMembers

        private string receptionistID;
        private string firstName;
        private string surname;
        private string password;

        #endregion

        #region Properties

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string ReceptionistID
        {
            get { return receptionistID; }
            set { receptionistID = value; }
        }

        #endregion

        #region Constructors

        public Receptionist() { }

        public Receptionist(string receptionistID, string firstName, string surname, string password)
        {
            this.receptionistID = receptionistID;
            this.firstName = firstName;
            this.surname = surname;
            this.password = password;

        }
        #endregion



    }
}
