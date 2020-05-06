using DiscountCardApp.DB.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DiscountCardApp.DB
{
    public class DiscountCardContext : DbContext
    {
        //public DiscountCardContext(DbContextOptionsBuilder options) {
        //    base(options);
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlServer("Server=localhost;Database=DiscountCardApp;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder builder)
        {
          
            builder
                .Entity<Card>(eb =>
                {
                    eb.HasKey(c => c.CardId);
                    eb.Property(v => v.Code).HasMaxLength(8).IsRequired();
                });

            builder
                .Entity<Product>(eb =>
                {
                    eb.HasKey(c => c.ProductId);
                    eb.Property(v => v.Code).HasMaxLength(8).IsRequired();
                });

            builder
               .Entity<CardProduct>(eb =>
               {
                   eb.HasKey(c => new { c.CardId, c.ProductId });
                   eb.HasOne(cp => cp.Card).WithMany(cp => cp.CardProducts).HasForeignKey(cp => cp.CardId);
                   eb.HasOne(cp => cp.Product).WithMany(cp => cp.CardProducts).HasForeignKey(cp => cp.ProductId);
               });

            builder
                .Entity<Discount>(eb =>
                {
                    eb.HasKey(c => c.DiscountId);
                    eb.Property(v => v.Code).HasMaxLength(8).IsRequired();
                });

            builder
               .Entity<DiscountProduct>(eb =>
               {
                   eb.HasKey(c => new { c.DiscountId, c.ProductId });
                   eb.HasOne(cp => cp.Discount).WithMany(cp => cp.DiscountProducts).HasForeignKey(cp => cp.DiscountId);
                   eb.HasOne(cp => cp.Product).WithMany(cp => cp.DiscountProducts).HasForeignKey(cp => cp.ProductId);
               });
        }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CardProduct> CardProducts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<DiscountProduct> DiscountProducts { get; set; }
    }
}
