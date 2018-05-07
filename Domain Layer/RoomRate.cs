using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest_Easy_Hotel_Management_System.Domain_Layer
{
    public class RoomRate
    {
        #region Data Members

        private string season;
        private string startDate;
        private string endDate;
        private decimal pricePerNight;

        #endregion

        #region Properties
        public decimal PricePerNight
        {
            get { return pricePerNight; }
            set { pricePerNight = value; }
        }
        public string EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public string StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public string Season
        {
            get { return season; }
            set { season = value; }
        }

        #endregion

        #region Constructors

        public RoomRate() { }
        public RoomRate(string season,  string startDate,string endDate, decimal pricePerNight)
        {
            this.season = season;
            this.startDate = startDate;
            this.endDate = endDate;
            this.pricePerNight = pricePerNight;
        }

        #endregion
    }
}
