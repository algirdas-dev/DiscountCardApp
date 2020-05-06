using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountCardApp.DB.Models
{
    public class CardProduct
    {
        public int CardId { get; set; }
        public Card Card { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
