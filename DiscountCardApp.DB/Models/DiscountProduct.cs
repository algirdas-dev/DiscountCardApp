using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountCardApp.DB.Models
{
    public class DiscountProduct
    {
        public int DiscountId { get; set; }
        public Discount Discount { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
