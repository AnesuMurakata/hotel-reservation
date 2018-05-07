using Rest_Easy_Hotel_Management_System.Data_Access_layer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest_Easy_Hotel_Management_System.Domain_Layer
{
    public class PaymentController
    {
        #region Data Member

        private PaymentDB paymentDB;
        private Collection<Payment> payments;

        #endregion

        public PaymentController()
        {
            paymentDB = new PaymentDB();
            payments = paymentDB.AllPayments;
        }

        public Collection<Payment> AllPayments
        {
            get { return payments; }
            set { payments = value; }
        }



        public void ADD(Payment payment)
        {
            //add to the database and collection
            paymentDB.DatabaseAdd(payment);
            payments.Add(payment);
        }


        #region Look Up

        public int FindIndex(Payment payment)
        {
            int index = 0;
            bool found = false;
            while (!found && index < payments.Count)
            {
                found = (payments[index].PaymentID == payment.PaymentID);
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

        public int FindIndex(Collection<Payment> thePayments, Payment payment)
        {
            int index = 0;
            bool found = false;
            while (!found && index < thePayments.Count)
            {
                found = (thePayments[index].PaymentID == payment.PaymentID);
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

        public Payment FindByPaymentID(string idValue)
        {
            int position = 0;
            bool found = (idValue == payments[position].PaymentID);
            while (!found && position < payments.Count)
            {
                found = (idValue == payments[position].PaymentID);
                if (!found)
                {
                    position += 1;
                }

            }
            if (found)
            {
                return payments[position];
            }
            else
            {
                return null;
            }

        }

        #endregion

        public string GeneratePaymentID()
        {


            int num;

            string paymentID = "P"; // variable to hold final booking id 

            System.Random objRandom = new System.Random();
            bool unique = false;

            while (!unique)
            {
                num = objRandom.Next(10000);

                paymentID = paymentID + (num.ToString());


                while (paymentID.Length < 7)
                {
                    paymentID = paymentID + "0";
                }

                if (FindByPaymentID(paymentID) == null)
                {
                    unique = true;
                }
            }

            return paymentID;
        }

    }
}
