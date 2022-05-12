using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserAPIServices.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("Ping")]
        public string Ping()
        {
            return "Hello World";
        }
        // GET: api/<UserController>
        [HttpGet("GetUser")]
        public IEnumerable<Models.User> GetUser()
        {
            using (var context = new Models.UserDBContext())
            {
                return context.User.ToList();
            }

        }

        // GET api/<UserController>/5
        [HttpGet("GetUserById/{id}")]
        public Models.User GetUserById(int id)
        {
            using (var context = new Models.UserDBContext())
            {
                return context.User.Where(x => x.Id == id).FirstOrDefault();
            }
        }
        [HttpGet("Login/{uname}/{pass}")]
        public Models.User Login(string uname, string pass)
        {
            using (var context = new Models.UserDBContext())
            {
                return context.User.Where(x => x.UserName == uname && x.Password == pass).FirstOrDefault();
            }
        }

        [HttpGet("GetFlight")]
        public IEnumerable<UserAPIServices.Models.Flight> GetFlight()
        {
            using (var context = new UserAPIServices.Models.UserDBContext())
            {
                return context.Flight.ToList();
            }
        }
        [HttpGet("GetFlightById/{id}")]
        public UserAPIServices.Models.Flight GetFlightById(int id)
        {
            using (var context = new UserAPIServices.Models.UserDBContext())
            {
                return context.Flight.Where(x => x.Id == id).FirstOrDefault();
            }
        }
        [HttpGet("SearchFlight/{From}/{To}/{FromDate}/{ToDate}")]
        public IEnumerable<UserAPIServices.Models.Flight> SearchFlight(string from, string to,
          string FromDate, string ToDate)
        {
            using (var context = new Models.UserDBContext())
            {
                return context.Flight.
                    Where(x => x.FromPlace == from && x.ToPlace == to &&
                    x.FromDate == FromDate && x.ToDate == ToDate).
                    ToList();
            }
        }
        [HttpGet("GetBookedTicket")]
        public IEnumerable<UserAPIServices.Models.TicketBooking> GetBookedTicket()
        {
            using (var context = new UserAPIServices.Models.UserDBContext())
            {
                return context.TicketBooking.ToList();
            }
        }
        [HttpGet("GetBookedTicketById/{emailid}")]
        public UserAPIServices.Models.TicketBooking GetBookedTicketById(string emailid)
        {
            using (var context = new UserAPIServices.Models.UserDBContext())
            {
                return context.TicketBooking.Where(x => x.EmailId == emailid).FirstOrDefault();
            }
        }
        [HttpGet("GetBookedTicketHistory")]
        public IEnumerable<UserAPIServices.Models.BookingHistory> GetBookedTicketHistory()
        {
            using (var context = new UserAPIServices.Models.UserDBContext())
            {
                return context.BookingHistory.ToList();
            }
        }
        [HttpGet("GetBookedTicketHistoryById/{pnr}")]
        public UserAPIServices.Models.BookingHistory GetBookedTicketHistoryById(string pnr)
        {
            using (var context = new UserAPIServices.Models.UserDBContext())
            {
                return context.BookingHistory.Where(x => x.Pnr == pnr).FirstOrDefault();
            }
        }

        // POST api/<UserController>
        [HttpPost("UserRegister")]
        public void UserRegister([FromBody] Models.User userregister)
        {
            using (var context = new Models.UserDBContext())
            {
                context.User.Add(userregister);
                context.SaveChanges();

            }
        }
        [HttpPost("FlightRegister")]
        public void FlightRegister([FromBody] UserAPIServices.Models.Flight flightregister)
        {
            using (var context = new Models.UserDBContext())
            {
                context.Flight.Add(flightregister);
                context.SaveChanges();

            }
        }
        [HttpPost("BookTicket")]
        public void BookTicket([FromBody] UserAPIServices.Models.TicketBooking ticketBooking)
        {
            using (var context = new Models.UserDBContext())
            {
                context.TicketBooking.Add(ticketBooking);
                context.SaveChanges();

            }
        }
        [HttpPost("BookTicketHistory")]
        public void BookTicketHistory([FromBody] UserAPIServices.Models.BookingHistory bookingHistory)
        {
            using (var context = new Models.UserDBContext())
            {
                context.BookingHistory.Add(bookingHistory);
                context.SaveChanges();

            }
        }
        [HttpPut("UpdateFlight/{id}")]
        public void UpdateFlight(int id, [FromBody] UserAPIServices.Models.Flight flight)
        {
            using (var context = new UserAPIServices.Models.UserDBContext())
            {
                var flight_ = context.Flight.FirstOrDefault(x => x.Id == id);
                flight_.Id = flight.Id;
                flight_.FlightName = flight.FlightName;
                flight_.FromPlace = flight.FromPlace;
                flight_.ToPlace = flight.ToPlace;
                flight_.OnewayPrice = flight.OnewayPrice;
                flight_.RoundTripPrice = flight.RoundTripPrice;
                flight_.FromDate = flight.FromDate;
                flight_.ToDate = flight.ToDate;
                context.SaveChanges();
            }
        }
        [HttpDelete("DeleteFlight/{id}")]
        public void DeleteFlight(int id)
        {
            using (var context = new Models.UserDBContext())
            {
                UserAPIServices.Models.Flight flight = context.Flight.Where(x => x.Id == id).FirstOrDefault();
                context.Flight.Remove(flight);
                context.SaveChanges();

            }
        }
        [HttpDelete("DeleteBookTicketHistory/{pnr}")]
        public void DeleteBookTicketHistory(string pnr)
        {
            using (var context = new Models.UserDBContext())
            {
                UserAPIServices.Models.BookingHistory bookingHistory = context.BookingHistory.Where(x => x.Pnr == pnr).FirstOrDefault();
                context.BookingHistory.Remove(bookingHistory);
                context.SaveChanges();

            }
        }
    }
}
