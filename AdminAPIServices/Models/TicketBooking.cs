using System;
using System.Collections.Generic;

namespace AdminAPIServices.Models
{
    public partial class TicketBooking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string NumberOfSeats { get; set; }
        public string Passengers { get; set; }
        public string MealType { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string AirlineName { get; set; }
        public string OnewayPrice { get; set; }
        public string RoundTripPrice { get; set; }
    }
}
