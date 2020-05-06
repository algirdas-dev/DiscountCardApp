using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountCardApp.DB.Models
{
    public class Product
    {
        //public Product() {
        //    this.Cards = new HashSet<Card>();
        //}
        public int ProductId { get; set; }
        public string Code { get; set; }
        public ICollection<CardProduct> CardProducts { get; set; }
        public ICollection<DiscountProduct> DiscountProducts { get; set; }
    }
}
