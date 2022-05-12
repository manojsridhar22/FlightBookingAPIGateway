using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdminAPIServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        // GET: api/<AdminController>
        [HttpGet]
        [Route("GetAdmin")]
        public IEnumerable<AdminAPIServices.Models.Admin> GetAdmin()
        {
            using (var context = new AdminAPIServices.Models.UserDBContext())
            {
                return context.Admin.ToList();
            }
        }

        // GET api/<AdminController>/5
        [HttpGet("GetAdminById/{id}")]
        public AdminAPIServices.Models.Admin GetAdminById(int id)
        {
            using (var context = new AdminAPIServices.Models.UserDBContext())
            {
                return context.Admin.Where(x => x.Id == id).FirstOrDefault();
            }
        }
        [HttpGet("AdminLogin/{uname}/{pass}")]
        public Models.Admin AdminLogin(string uname, string pass)
        {
            using (var context = new Models.UserDBContext())
            {
                return context.Admin.Where(x => x.UserName == uname && x.Password == pass).FirstOrDefault();
            }
        }
        // GET: api/<AdminController>
        [HttpGet("GetAirline")]
        public IEnumerable<AdminAPIServices.Models.Airline> GetAirline()
        {
            using (var context = new AdminAPIServices.Models.UserDBContext())
            {
                return context.Airline.ToList();
            }
        }

        // GET api/<AdminController>/5
        [HttpGet("GetAirlineById/{airlineid}")]
        public AdminAPIServices.Models.Airline GetAirlineById(int airlineid)
        {
            using (var context = new AdminAPIServices.Models.UserDBContext())
            {
                return context.Airline.Where(x => x.Id == airlineid).FirstOrDefault();
            }
        }
        [HttpGet("GetDiscount")]
        public IEnumerable<AdminAPIServices.Models.Discount> GetDiscount()
        {
            using (var context = new AdminAPIServices.Models.UserDBContext())
            {
                return context.Discount.ToList();
            }
        }
        [HttpGet("GetDiscountById/{id}")]
        public AdminAPIServices.Models.Discount GetDiscountById(int id)
        {
            using (var context = new AdminAPIServices.Models.UserDBContext())
            {
                return context.Discount.Where(x => x.Id == id).FirstOrDefault();
            }
        }
        // POST api/<AdminController>
        [HttpPost("AdminRegister")]
        public void AdminRegister([FromBody] Models.Admin adminregister)
        {
            using (var context = new AdminAPIServices.Models.UserDBContext())
            {
                context.Admin.Add(adminregister);
                context.SaveChanges();
            }
        }


        [HttpPost("AddAirline")]
        public void AddAirline([FromBody] AdminAPIServices.Models.Airline airline)
        {
            using (var context = new AdminAPIServices.Models.UserDBContext())
            {
                context.Airline.Add(airline);
                context.SaveChanges();
            }
        }
        [HttpPost("AddDiscount")]
        public void AddDiscount([FromBody] AdminAPIServices.Models.Discount discount)
        {
            using (var context = new AdminAPIServices.Models.UserDBContext())
            {
                context.Discount.Add(discount);
                context.SaveChanges();
            }
        }
        [HttpPut("ScheduleAirline/{id}")]
        public void ScheduleAirline(int id, [FromBody] AdminAPIServices.Models.Airline airline)
        {
            using (var context = new AdminAPIServices.Models.UserDBContext())
            {
                var airline_ = context.Airline.FirstOrDefault(x => x.Id == id);
                airline_.Id = airline.Id;
                airline_.FlightNumber = airline.FlightNumber;
                airline_.AirlineName = airline.AirlineName;
                airline_.FromPlace = airline.FromPlace;
                airline_.ToPlace = airline.ToPlace;
                airline_.StartDate = airline.StartDate;
                airline_.EndDate = airline.EndDate;
                airline_.ScheduledDays = airline.ScheduledDays;
                airline_.SpecificDays = airline.SpecificDays;
                airline_.InstrumentUsed = airline.InstrumentUsed;
                airline_.BusinessClassSeats = airline.BusinessClassSeats;
                airline_.NonBusinessClassSeats = airline.NonBusinessClassSeats;
                airline_.Price = airline.Price;
                airline_.Rows = airline.Rows;
                airline_.MealType = airline.MealType;
                airline_.Blocked = airline.Blocked;
                context.SaveChanges();
            }
        }
        [HttpPut("UpdateDiscount/{id}")]
        public void UpdateDiscount(int id, [FromBody] AdminAPIServices.Models.Discount discount)
        {
            using (var context = new AdminAPIServices.Models.UserDBContext())
            {
                var discount_ = context.Discount.FirstOrDefault(x => x.Id == id);
                discount_.Id = discount.Id;
                discount_.CouponCode = discount.CouponCode;
                discount_.DiscountValue = discount.DiscountValue;
                context.SaveChanges();
            }
        }
        [HttpDelete("DeleteAirline/{id}")]
        public void DeleteAirline(int id)
        {
            using (var context = new Models.UserDBContext())
            {
                AdminAPIServices.Models.Airline airline = context.Airline.Where(x => x.Id == id).FirstOrDefault();
                context.Airline.Remove(airline);
                context.SaveChanges();
            }
        }
        [HttpDelete("DeleteDiscount/{id}")]
        public void DeleteDiscount(int id)
        {
            using (var context = new Models.UserDBContext())
            {
                AdminAPIServices.Models.Discount discount = context.Discount.Where(x => x.Id == id).FirstOrDefault();
                context.Discount.Remove(discount);
                context.SaveChanges();
            }
        }
    }
}
