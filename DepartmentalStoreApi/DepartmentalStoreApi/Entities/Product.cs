using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentalStoreApi.Entities
{
    public class Product
    {
        public Product()
        {
            ProductCategories = new List<ProductCategory>();         
        }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string Manufacturer { get; set; }
        public string ShortCode { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
