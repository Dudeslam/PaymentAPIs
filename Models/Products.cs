using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoCNetsEasy.Models
{
    public class Products : IEnumerable<Product>
    {
        private List<Product> products = new List<Product>();

        public IEnumerator<Product> GetEnumerator()
        {
            return products.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Product product)
        {
            products.Add(product);
        }
    }
    
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }   
    }

    public class RandomString
    {
        public string ThisString { get; set; }
    }

    public class order
    {
        public string id { get; set; }
        public string amount { get; set; }
        public string currency { get; set; }
    }

}