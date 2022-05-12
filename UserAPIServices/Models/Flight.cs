using System;
using System.Collections.Generic;

namespace UserAPIServices.Models
{
    public partial class Flight
    {
        public int Id { get; set; }
        public string FlightName { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public string OnewayPrice { get; set; }
        public string RoundTripPrice { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}
