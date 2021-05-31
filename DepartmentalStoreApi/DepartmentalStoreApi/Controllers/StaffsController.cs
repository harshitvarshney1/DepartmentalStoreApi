using AutoMapper;
using DepartmentalStoreApi.Entities;
using DepartmentalStoreApi.Infrastructure;
using DepartmentalStoreApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentalStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private  DepartmentStoreContext _context;
        private readonly IMapper _mapper;
        public StaffsController(DepartmentStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public StaffModel[] getStaff()
        {
            IQueryable<Staff> query = _context.Staff.Include(c => c.Address).Include(r => r.Role);
            var result = query.ToArray();
            return _mapper.Map<StaffModel[]>(result);
        }

        [HttpGet("{id}")]
        public StaffModel GetStaffById(long id)
        {
            {
                IQueryable<Staff> query = _context.Staff.Include(c => c.Address).Where(t => t.Id == id);
                var result = query.FirstOrDefault();
                return _mapper.Map<StaffModel>(result);
            }

        }

        [HttpGet("staff-members/{id}")]
        public StaffModel GetBycode(int id, bool isAddress = false, string name = "")
        {
            IQueryable<Staff> query = _context.Staff
            //.Include(c => c.Address)
            .Include(t => t.Role);
            if (isAddress)
            {
                query = query.Include(r => r.Address);
            }
            query.Where(x => x.Id == id);
            var result = query.FirstOrDefault();
            return _mapper.Map<StaffModel>(result);
        }


        [HttpPost]
        public Staff createstaff(StaffPostModel staffitem)
        {
            _context.Staff.Add(_mapper.Map<Staff>(staffitem));
            _context.SaveChanges();
            return null;
        }


        [HttpPut("{id}")]
        public Staff updateStaff(StaffPostModel staffitem, int id)
        {
            var query = _context.Staff.Where(i => i.Id == id).FirstOrDefault();
            _mapper.Map(staffitem, query);
            _context.SaveChanges();
            return null;
        }

        [HttpGet("search")]
        public StaffModel[] getStaffByQuery(string name )
        {
            IQueryable<Staff> query = _context.Staff.Include(c => c.Address).Include(r => r.Role);
            var result = query.ToArray();
            return _mapper.Map<StaffModel[]>(result);
        }



    }
}
