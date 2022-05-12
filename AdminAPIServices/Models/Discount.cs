using System;
using System.Collections.Generic;

namespace AdminAPIServices.Models
{
    public partial class Discount
    {
        public int Id { get; set; }
        public string CouponCode { get; set; }
        public int? DiscountValue { get; set; }
    }
}
