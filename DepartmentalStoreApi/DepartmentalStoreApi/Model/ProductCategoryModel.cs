using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentalStoreApi.Model
{
    public class ProductCategoryModel
    {
        public long ProductId { get; set; }
        public long CategoryId { get; set; }
        public CategoryModel Category { get; set; }
    }
}
