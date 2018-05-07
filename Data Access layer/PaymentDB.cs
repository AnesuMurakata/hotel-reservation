using Rest_Easy_Hotel_Management_System.Domain_Layer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest_Easy_Hotel_Management_System.Data_Access_layer
{
    class PaymentDB :DB
    {
        #region DataMembers

        private static string table = "Payment";
        private string sql_SELECT = "SELECT * FROM " + table;
        private Collection<Payment> payments = new Collection<Payment>();

        #endregion

        #region Constructors

        public PaymentDB()
            : base()
        {
            ReadDataFromTable(sql_SELECT, table);   //Get the data from table
        }

        #endregion

        #region Properties

        public Collection<Payment> AllPayments
        {
            get
            {
                return payments;
            }
        }

        #endregion

        public void DatabaseAdd(Payment tempPayment)
        {
            string strSQL = "";

            //Build SQL string for the command
            strSQL = "INSERT into Payment (paymentID, date, paymentType, paymentAmount, bookingID, creditCardNumber, creditCardExpiry, creditCardCVV)" +
                                          "VALUES ('" + GetValueString(tempPayment) + ")";     ////////////////////////////check sql syntax

            //Create & execute the insert command 
            UpdateDataSource(new SqlCommand(strSQL, cnMain));            
        }

        private string GetValueString(Payment tempPayment) //check
        {
            string aStr = "";
            aStr = tempPayment.PaymentID + "', '" +
                tempPayment.Date + "', '" + 
                tempPayment.PaymentType + "', " +
              
                tempPayment.PaymentAmount+ ", '" +
                tempPayment.BookingID + "', '" + 
                tempPayment.CreditCardNumber + "', '" + 
                
                
                tempPayment.CreditCardExpiryDate + "', '" +
                tempPayment.CreditCardCVV + "'";
            return aStr;
        }

        #region DataReader

        private string ReadDataFromTable(string selectString, string table)
        {
            SqlDataReader reader;
            SqlCommand command;
            try
            {
                command = new SqlCommand(selectString, cnMain);
                cnMain.Open();             //open the connection
                command.CommandType = CommandType.Text;
                reader = command.ExecuteReader();                        //Read from table
                if (reader.HasRows)
                {
                    // Call the FillEmployeeByRole method see step 2.4
                    FillPayments(reader, table, payments);       //Fill the collection –   
                }
                reader.Close();   //close the reader 
                cnMain.Close();  //close the connection
                return "success";
            }
            catch (Exception ex)
            {
                cnMain.Close();
                return (ex.ToString());

            }
        }

        private void FillPayments(SqlDataReader reader, string dataTable,
                                                              Collection<Payment> payments)
        {
            Payment payment;
            while (reader.Read())                          //While you still have stuff to read
            {
                payment = new Payment();

                //get all the relevant collumns from the booking table  
                payment.PaymentID = (reader.GetString(0).Trim());
                payment.Date = reader.GetString(1).Trim();
                payment.PaymentType = reader.GetString(2).Trim();
                payment.PaymentAmount = reader.GetDecimal(3);
                payment.BookingID = reader.GetString(4).Trim();
               // payment.CreditCardType = reader.GetString(5).Trim();
                payment.CreditCardNumber = reader.GetString(5).Trim();
                payment.CreditCardExpiryDate  = reader.GetString(6).Trim();
                payment.CreditCardCVV = reader.GetString(7).Trim();
       

                payments.Add(payment);             //add to the collection
            }
        }


        #endregion

    }

}
