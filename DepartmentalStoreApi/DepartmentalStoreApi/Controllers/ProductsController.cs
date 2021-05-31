using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DepartmentalStoreApi.Entities;
using DepartmentalStoreApi.Infrastructure;
using DepartmentalStoreApi.Model;
using AutoMapper;

namespace DepartmentalStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DepartmentStoreContext _context;
        private readonly IMapper _mapper;
        public ProductsController(DepartmentStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet]
        public ProductModel[] getproduct()
        {
            IQueryable<Product> query = _context.Product;
            var result = query.ToArray();
            return _mapper.Map<ProductModel[]>(result);
        }


        // GET: api/Products/5
        [HttpGet("{id}")]
        public ProductModel[] GetProduct(long id)
        {
            IQueryable<Product> query = _context.Product;
            var result = query.ToArray();
            return _mapper.Map<ProductModel[]>(result);
        }


        // GET: api/Products/tv
        [HttpGet("{productName}")]
        public async Task<ActionResult<Product>> GetProductByName(string  name)
        {
            var product = await _context.Product.FindAsync(name);

            if (product == null)
            {
                return NotFound();
            }
            return product;
        }


        //PUT: api/Products/5
        //To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        


        [HttpPut("{id}")]
        public Product PutProduct(long id, ProductModel product)
        {
            var query = _context.Product.Where(i => i.ProductId == id).FirstOrDefault();
            _mapper.Map(product, query);
            _context.SaveChanges();
            return null;
        }

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        [HttpPost]
        public Product PostProduct(ProductModel product)
        {
            _context.Product.Add(_mapper.Map<Product>(product));
            _context.SaveChanges();
            return null;        
        }


        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(long id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }
        private bool ProductExists(long id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
    }
}
