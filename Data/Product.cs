using System;
using System.Collections.Generic;
using System.Text;
using TDDUnitTestImplementation.Model;

namespace TDDUnitTestImplementation.Data
{
    public class Products
    {
        public List<Product> data = new List<Product>()
        {
            new Product(){ Id = 1, Name = "Coke", Value = 25},
            new Product(){ Id = 2, Name = "Pepsi", Value = 35},
            new Product(){ Id = 3, Name = "Soda", Value = 45},
            new Product(){ Id = 4, Name = "Chocolate bar", Value = 20.25},
            new Product(){ Id = 5, Name = "Chewing Gum", Value = 10.50},
            new Product(){ Id = 6, Name = "Bottled Water", Value = 15}
        };

        public List<double> Money => new List<double>() { 100, 50, 20, 10, 5, 1, 0.25 };
    }
}
