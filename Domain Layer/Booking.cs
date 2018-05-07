using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest_Easy_Hotel_Management_System.Domain_Layer
{
    public class Booking
    {
        #region DataMembers

        private string bookingID;
        private string guestID;
        private string roomNumber;
        private string reservationDate;                     //////////////////////////this should be a date time
        private string startDate;                           //////////////////////////this should be a date time 
        private string endDate;
        private string noOfGuests;
        private decimal price;
        private decimal depositAmount;
        private string depositPaid;                    ///////////////////////////this should be a boolean




        #endregion

        #region Constructor

        public Booking() { }



        #endregion

        #region Properties

        public string BookingID
        {
            get { return bookingID; }
            set { bookingID = value; }
        }

        public string GuestID
        {
            get { return guestID; }
            set { guestID = value; }
        }

        public string RoomNumber
        {
            get { return roomNumber; }
            set { roomNumber = value; }
        }

        public string ReservationDate
        {
            get { return reservationDate; }
            set { reservationDate = value; }
        }

        public string StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public string EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public string NoOfGuests
        {
            get { return noOfGuests; }
            set { noOfGuests = value; }
        }



        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public decimal DepositAmount
        {
            get { return depositAmount; }
            set { depositAmount = value; }
        }

        public string DepositPaid
        {
            get { return depositPaid; }
            set { depositPaid = value; }
        }


        #endregion
    }
}

