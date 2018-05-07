using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest_Easy_Hotel_Management_System.Domain_Layer
{
    public class Payment
    {
        #region Data Members
        private string paymentID;
        private string date;
        private string paymentType;
        private decimal paymentAmount;
        private string bookingID;
        private string creditCardNumber;
        private string creditCardExpiryDate;
        private string creditCardCVV;


        #endregion

        #region Properties

        public string PaymentID
        {
            get { return paymentID; }
            set { paymentID = value; }
        }
        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public string PaymentType
        {
            get { return paymentType; }
            set { paymentType = value; }
        }
        public decimal PaymentAmount
        {
            get { return paymentAmount; }
            set { paymentAmount = value; }
        }


        public string BookingID
        {
            get { return bookingID; }
            set { bookingID = value; }
        }


        public string CreditCardNumber
        {
            get { return creditCardNumber; }
            set { creditCardNumber = value; }
        }

        public string CreditCardExpiryDate
        {
            get { return creditCardExpiryDate; }
            set { creditCardExpiryDate = value; }
        }


        public string CreditCardCVV
        {
            get { return creditCardCVV; }
            set { creditCardCVV = value; }
        }

        #endregion
    }
}
