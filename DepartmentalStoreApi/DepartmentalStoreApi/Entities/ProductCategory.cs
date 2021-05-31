using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentalStoreApi.Entities
{
    public class ProductCategory
    {
        public long ProductId { get; set; }
        public long CategoryId { get; set; }
        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}
