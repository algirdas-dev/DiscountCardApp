using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountCardApp.DB.Models
{
    public class Card
    {
        //public Card()
        //{
        //    this.Products = new HashSet<Product>();
        //}
        public int CardId { get; set; }
        public string Code { get; set; }
        public ICollection<CardProduct> CardProducts { get; set; }
    }
}
