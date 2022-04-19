using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PoCNetsEasy.Models;

namespace PoCNetsEasy.BusinessLayer
{
    public class RandomData
    {
        public static string GetRandomString(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GetRandomNumber(int length)
        {
            var random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GetRandomEmail()
        {
            return GetRandomString(10) + "@" + GetRandomString(5) + ".com";
        }

        public static string GetRandomPhoneNumber()
        {
            return "0" + GetRandomNumber(9);
        }

        public static string GetRandomDate()
        {
            var random = new Random();
            var year = random.Next(1950, 2000);
            var month = random.Next(1, 12);
            var day = random.Next(1, 28);
            return year + "-" + month + "-" + day;
        }

        public static string GetRandomAddress()
        {
            return GetRandomString(10) + " " + GetRandomString(10) + " " + GetRandomString(10);
        }

        public static string GetRandomCity()
        {
            return GetRandomString(10);
        }

        public static decimal GetRandomPrice()
        {
            var random = new Random();
            return random.Next(100, 1000);
        }

        //create list of random Products
        public static List<Product> GetRandomProducts()
        {
            var products = new List<Product>();
            for (int i = 0; i < 10; i++)
            {
                products.Add(new Product
                {
                    Id = i,
                    Name = GetRandomString(10),
                    Description = GetRandomString(10),
                    Price = GetRandomPrice(),
                    Category = GetRandomString(10),
                });
            }
            return products;
        }
    }
}