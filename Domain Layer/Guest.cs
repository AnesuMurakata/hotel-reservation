using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest_Easy_Hotel_Management_System.Domain_Layer
{
    public class Guest
    {
        #region DataMembers

        private string guestID;
        private string firstName;
        private string surname;
        private string addressLine1;
        private string addressLine2;
        private string country;
        private string postalCode;
        private string telephoneNumber;
        private string emailAddress;



        #endregion

        #region Constructors

        public Guest() { }
        public Guest(string guestID, string firstName, string surname, string addressLine1, string addressLine2,
            string country, string postalCode, string telephoneNumber, string emailAddress)
        {
            this.guestID = guestID;
            this.firstName = firstName;
            this.surname = surname;
            this.addressLine1 = addressLine1;
            this.addressLine2 = addressLine2;
            this.country = country;
            this.postalCode = postalCode;
            this.telephoneNumber = telephoneNumber;
            this.emailAddress = emailAddress;
            

        }
        #endregion

        #region Properties
        

        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        public string TelephoneNumber
        {
            get { return telephoneNumber; }
            set { telephoneNumber = value; }
        }

        public string PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; }
        }

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        public string AddressLine2
        {
            get { return addressLine2; }
            set { addressLine2 = value; }
        }
        public string AddressLine1
        {
            get { return addressLine1; }
            set { addressLine1 = value; }
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

      

        public string GuestID
        {
            get { return guestID; }
            set { guestID = value; }
        }

        #endregion
    }
}
