using DiscountCardApp.DB;
using DiscountCardApp.DB.Models;
using DiscountCardApp.Generator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscountCardApp.Generator.Services
{
    public class DiscountService
    {
        public static void Generate(int count) {
            using (DiscountCardContext context = new DiscountCardContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    int insertedCount = 0;
                    var badCodeCount = 0;
                    while (insertedCount < count)
                    {
                        var code = CodeGenereatorHelper.Generate();

                        if (context.Discounts.Any(d => d.Code == code))
                        {
                            Console.WriteLine("Bad discount code {0}", code);
                            if (badCodeCount >= 30)
                            {
                                Console.WriteLine(string.Format("You have {0} bad dicount codes, press enter", badCodeCount));
                                var test2 = Console.ReadLine();
                                break;
                            }
                            badCodeCount++;
                            continue;
                        }
                        Console.WriteLine("Discount code {0}", code);
                        context.Discounts.Add(new Discount { Code = code });
                        insertedCount++;
                    }


                    context.SaveChanges();
                    transaction.Commit();
                    string[] args = { };
                    Program.Main(args);
                }
            }
        }

        
    }
}
