using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentalStoreApi.Entities
{
    public class Staff
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public char Gender { get; set; }
        public decimal Salary { get; set; }
        public long AddressId { get; set; }
        public long RoleId { get; set; }
        public Role Role { get; set; }
        public Address Address { get; set; }
    }
}
