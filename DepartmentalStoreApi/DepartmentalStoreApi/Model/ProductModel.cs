using DepartmentalStoreApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentalStoreApi.Model
{
    public class ProductModel
    {
        public string ProductName { get; set; }
        public string Manufacturer { get; set; }
        public string ShortCode { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        //public string CategoryName { get; set; }
       // public ProductCategoryModel ProductCategory { get; set; }
       
    }
}
