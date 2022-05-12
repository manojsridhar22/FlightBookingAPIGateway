using System;
using System.Collections.Generic;

namespace UserAPIServices.Models
{
    public partial class Airline
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public string AirlineName { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ScheduledDays { get; set; }
        public string SpecificDays { get; set; }
        public string InstrumentUsed { get; set; }
        public string BusinessClassSeats { get; set; }
        public string NonBusinessClassSeats { get; set; }
        public string Price { get; set; }
        public string Rows { get; set; }
        public string MealType { get; set; }
        public string Blocked { get; set; }
    }
}
