using System;
using System.Collections.Generic;

namespace UserAPIServices.Models
{
    public partial class Discount
    {
        public int Id { get; set; }
        public string CouponCode { get; set; }
        public int? DiscountValue { get; set; }
    }
}
