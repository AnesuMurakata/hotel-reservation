using Rest_Easy_Hotel_Management_System.Data_Access_layer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest_Easy_Hotel_Management_System.Domain_Layer
{
    public class BookingController
    {
        #region Data Member
        private BookingDB bookingDB;
        private Collection<Booking> bookings;

        #endregion

        public BookingController()
        {
            bookingDB = new BookingDB();
            bookings = bookingDB.AllBookings;
        }

        public Collection<Booking> AllBookings
        {
            get
            {
                return bookings;
            }
        }

        #region CRUD functionality - Maintain Collection and Database

        public void ADD(Booking booking)
        {
            //add to the database and collection
            bookingDB.DatabaseAdd(booking);
            bookings.Add(booking);
        }

        public void Edit(Booking booking)
        {
      
            Booking tempBooking;
            tempBooking = FindByBookingID(booking.BookingID);
            bookings.Remove(tempBooking);
            bookings.Add(booking);
            bookingDB.DatabaseEdit(booking);

           

        }

        public bool Delete(Booking booking)
        {
            bool success = false;
            int position = 0;
            //find the entry in the collection and remove 
            position = FindIndex(booking);
            if (position >= 0)
            {
                bookings.RemoveAt(position);

            }
            //remove the entry from the database
            success = bookingDB.DatabaseDelete(booking);
            return success;
        }

        #endregion

        #region Look Up

        public int FindIndex(Booking booking)
        {
            int index = 0;
            bool found = false;
            while (!found && index < bookings.Count)
            {
                found = (bookings[index].BookingID == booking.BookingID);
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

        public int FindIndex(Collection<Booking> theBookings, Booking booking)
        {
            int index = 0;
            bool found = false;
            while (!found && index < theBookings.Count)
            {
                found = (theBookings[index].BookingID == booking.BookingID);
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

        public Booking FindByBookingID(string idValue)
        {
            int position = 0;
            bool found = (idValue == bookings[position].BookingID);
            while (!found && position < bookings.Count)
            {
                found = (idValue == bookings[position].BookingID);
                if (!found)
                {
                    position += 1;
                }

            }
            if (found)
            {
                return bookings[position];
            }
            else
            {
                return null;
            }

        }

        #endregion

        public Collection<Room> CheckAvailability(DateTime startDate, DateTime endDate, Collection<Room> allRooms)
        {
            //populate a collection of  RoomAvailability onjects from all Rooms
            Collection<Boolean> allRoomAvailabilities = new Collection<Boolean>();


           
            foreach (Room room in allRooms)
            {
                //make a new RoomAvailabilityObject
                Boolean roomAvailability = new Boolean();
                roomAvailability =true;

                //add the room availabilityObject
                allRoomAvailabilities.Add(roomAvailability);

            }

            //iterate through all the bookings
            foreach (Booking booking in bookings)
            {
                //make date time objects forthe booking start and end date
                DateTime dtStart = Convert.ToDateTime(booking.StartDate);
                DateTime dtEnd = Convert.ToDateTime(booking.EndDate);            
                //check the start date against booking dates
                if (((startDate.Date >= dtStart.Date) && (startDate.Date <= dtEnd.Date))
                    || ((endDate.Date >= dtStart.Date) && (endDate.Date <= dtEnd.Date))
                    || ((startDate.Date <= dtStart.Date) && (endDate.Date >= dtEnd.Date)))              
                {

                    //update availability in the collection to false
                    for (int i = 0; i < allRooms.Count; i++ )
                    {
                        if (allRooms[i].RoomNumber == booking.RoomNumber)
                        {
                            allRoomAvailabilities[i] = false;
                            break;
                        }
                    }

                }
            }

            //populate a collection of available rooms to return
            Collection<Room> roomsAvailable = new Collection<Room>();


            for (int i = 0; i < allRooms.Count; i++)
            {
                //check the corrsponding room with the room availability
                if (allRoomAvailabilities[i] == true)
                {
                    roomsAvailable.Add(allRooms[i]);
                }
            }

            //return available rooms
            return roomsAvailable;

        }

        public Collection<Room> CheckAvailability(DateTime startDate, DateTime endDate, Collection<Room> allRooms, Booking b)
        {
            //populate a collection of  RoomAvailability onjects from all Rooms
            Collection<Boolean> allRoomAvailabilities = new Collection<Boolean>();



            foreach (Room room in allRooms)
            {
                //make a new RoomAvailabilityObject
                Boolean roomAvailability = new Boolean();
                roomAvailability = true;

                //add the room availabilityObject
                allRoomAvailabilities.Add(roomAvailability);

            }

            //iterate through all the bookings
            foreach (Booking booking in bookings)
            {
                
                if (booking.BookingID == b.BookingID)
                {
                    continue;
                }

                    //make date time objects forthe booking start and end date
                    DateTime dtStart = Convert.ToDateTime(booking.StartDate);
                    DateTime dtEnd = Convert.ToDateTime(booking.EndDate);

                    //check the start date against booking dates
                    if (((startDate.Date >= dtStart.Date) && (startDate.Date <= dtEnd.Date))
                        || ((endDate.Date >= dtStart.Date) && (endDate.Date <= dtEnd.Date))
                        || ((startDate.Date <= dtStart.Date) && (endDate.Date >= dtEnd.Date)))
                    {

                        //update availability in the collection to false
                        for (int i = 0; i < allRooms.Count; i++)
                        {
                            if (allRooms[i].RoomNumber == booking.RoomNumber)
                            {
                                allRoomAvailabilities[i] = false;
                                break;
                            }
                        }

                    }
              
            }

            //populate a collection of available rooms to return
            Collection<Room> roomsAvailable = new Collection<Room>();


            for (int i = 0; i < allRooms.Count; i++)
            {
                //check the corrsponding room with the room availability
                if (allRoomAvailabilities[i] == true)
                {
                    roomsAvailable.Add(allRooms[i]);
                }
            }

            //return available rooms
            return roomsAvailable;

        }




        public decimal CalculateBookingPrice(DateTime startDate, DateTime endDate, Collection<RoomRate> allRates)
        {
            
            //final price:
            decimal totalCost = 0;

            //populate all interimPrices
            foreach (RoomRate rate in allRates)
            {
                //make a new decimal objects
                Decimal interimPrice = new Decimal();
                interimPrice = rate.PricePerNight;      //equal to the season rate for now  //we must still multiple by the number of days
                
                //make date time objects forthe Season start and end date
                DateTime dtStartSeason = Convert.ToDateTime(rate.StartDate);
                DateTime dtEndSeason = Convert.ToDateTime(rate.EndDate);    


                //calculate the number of days that fall in the particular season
                double noOfDays;
                //if non of the booking is encapsulated in the season
                    //both fall below the season or both fall above the season
                if(((startDate.Date < dtStartSeason.Date) && (endDate.Date < dtStartSeason.Date)) 
                    || ((startDate.Date> dtEndSeason.Date) && (endDate.Date > dtEndSeason.Date)))
                {
                    noOfDays = 0;
                }
                //if booking is fully encapsulated in the season
                else if (((startDate.Date>=dtStartSeason.Date) && (startDate.Date<= dtEndSeason.Date))
                    && ((endDate.Date>=dtStartSeason.Date) && (endDate.Date<=dtEndSeason.Date)))
                {
                    noOfDays = (endDate.Date -startDate.Date).TotalDays+1;  
                }
                //if booking is also fully encapsulated in the season
               else if(((startDate.Date<=dtStartSeason.Date) && (endDate>=dtEndSeason.Date)))
                {
                    noOfDays = (dtEndSeason.Date - dtStartSeason.Date).TotalDays + 1;  
                }



                //if beginning of booking is encapsulated in the sesaon       
                 else if((startDate.Date <= dtEndSeason.Date) && (startDate.Date > dtStartSeason.Date ))
                 {
                        noOfDays = (dtEndSeason.Date -startDate.Date).TotalDays +1;   //think we must plus one
                 }

                 //if end of boooking is encapsulated in the season
                 else
                 {
                       noOfDays = (endDate.Date - dtStartSeason.Date).TotalDays +1;  //think i must plus one
                 }
                //if top of boooking is encapsulated in the season
                
                //update the interim price 
                totalCost += (interimPrice* Convert.ToDecimal(noOfDays));

            }
            return totalCost;
        

            

        }

        public string GenerateBookingID()
        {


            int num;

            string bookingID = ""; // variable to hold final booking id 

            System.Random objRandom = new System.Random();
            bool unique = false;

            while (!unique)
            {
                num = objRandom.Next(10000);

                bookingID = (num.ToString());


                while (bookingID.Length < 7)
                {
                    bookingID = "0" + bookingID;
                }

                if (FindByBookingID(bookingID) == null)
                {
                    unique = true;
                }
            }

            return bookingID;
        }



    }


}
