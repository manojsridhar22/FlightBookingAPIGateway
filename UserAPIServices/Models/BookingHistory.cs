using System;
using System.Collections.Generic;

namespace UserAPIServices.Models
{
    public partial class BookingHistory
    {
        public int Id { get; set; }
        public DateTime? BookingDate { get; set; }
        public string AirlineName { get; set; }
        public string SeatsBooked { get; set; }
        public string OnewayPrice { get; set; }
        public string RoundTripPrice { get; set; }
        public string Pnr { get; set; }
        public string Status { get; set; }
    }
}
