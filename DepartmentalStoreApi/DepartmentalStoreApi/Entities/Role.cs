using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentalStoreApi.Entities
{
    public class Role
    {
        public long Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        
        public ICollection<Staff> Staff { get; set; }
    }
}
