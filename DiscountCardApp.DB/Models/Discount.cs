using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountCardApp.DB.Models
{
    public class Discount
    {
        public int DiscountId { get; set; }
        public string Code { get; set; }
        public ICollection<DiscountProduct> DiscountProducts { get; set; }
    }
}
