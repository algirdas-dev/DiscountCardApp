using DiscountCardApp.DB;
using DiscountCardApp.DB.Models;
using DiscountCardApp.Generator.Helpers;
using System;
using System.Linq;

namespace DiscountCardApp.Generator.Services
{
    public class ProductService
    {
        public static void Generate(int count)
        {
            using (DiscountCardContext context = new DiscountCardContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    int insertedCount = 0;
                    var badCodeCount = 0;
                    while (insertedCount < count)
                    {
                        var code = CodeGenereatorHelper.Generate();

                        if (context.Products.Any(d => d.Code == code))
                        {
                            Console.WriteLine("Bad product code {0}", code);
                            if (badCodeCount >= 30)
                            {
                                Console.WriteLine(string.Format("You have {0} bad product codes, press enter", badCodeCount));
                                var test2 = Console.ReadLine();
                                break;
                            }
                            badCodeCount++;
                            continue;
                        }
                        Console.WriteLine("Products code {0}", code);
                        context.Products.Add(new Product { Code = code });
                        insertedCount++;
                    }


                    context.SaveChanges();
                    transaction.Commit();
                    string[] args = { };
                    Program.Main(args);
                }
            }
        }

        public static void SetToDisctount(string productCode, string discountCode)
        {
            using (DiscountCardContext context = new DiscountCardContext())
            {

                var discount = context.Discounts.FirstOrDefault(d => d.Code == discountCode);
                var product = context.Products.FirstOrDefault(d => d.Code == productCode);
                if (discount == null)
                {
                    Console.WriteLine("Discount code {0} not exists", discountCode);
                }
                else if (product == null)
                {
                    Console.WriteLine("Product code {0} not exists", productCode);
                }
                else
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        var discountProduct = new DiscountProduct
                        {
                            Discount = discount,
                            Product = product
                        };
                        context.DiscountProducts.Add(discountProduct);
                        try {
                            context.SaveChanges();
                        } catch(Exception ex) {
                            Console.WriteLine("Relation exist");
                        }
                        transaction.Commit();
                        string[] args = { };
                        Program.Main(args);
                    }
                }
            }
        }
    }
}
