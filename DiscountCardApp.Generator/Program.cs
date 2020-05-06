
using DiscountCardApp.Generator.Services;
using System;

namespace DiscountCardApp.Generator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("Generate discounts d");
            Console.WriteLine("Generate products p");
            Console.WriteLine("Set discount to product dp");
            string action = Console.ReadLine();
            switch (action)
            {
                case "d":
                    Console.WriteLine("Set discounts count");
                    string dCountString = Console.ReadLine();
                    if (!int.TryParse(dCountString, out int dCount)) {
                        dCount = 0;
                    }
                    DiscountService.Generate(dCount);

                    break;
                case "p":
                    Console.WriteLine("Set product count");
                    var pCountString = Console.ReadLine();
                    if (!int.TryParse(pCountString, out int pCount))
                    {
                        pCount = 0;
                    }
                    ProductService.Generate(pCount);
                    break;
                case "dp":
                    Console.WriteLine("Enter discount code");
                    var dCode = Console.ReadLine();
                    Console.WriteLine("Enter product code");
                    var pCode = Console.ReadLine();
                    
                    ProductService.SetToDisctount(pCode, dCode);
                    break;
            };

        }


    }
}
