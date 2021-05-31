using AutoMapper;
using DepartmentalStoreApi.Entities;
using DepartmentalStoreApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentalStoreApi.Data
{
    public class StaffProfile : Profile
    {
        public StaffProfile()
        {
           
           
            this.CreateMap<Staff, StaffModel>();
            this.CreateMap<Staff, StaffPostModel>().ReverseMap();
            this.CreateMap<Address, AddressModel>();
            this.CreateMap<Role, RoleModel>();
            this.CreateMap<Product, ProductModel>();
            this.CreateMap<Product, ProductModel>().ReverseMap();
            //this.CreateMap<Product, ProductPostModel>().ReverseMap();
            this.CreateMap<Category, CategoryModel>();
            this.CreateMap<ProductCategory, ProductCategoryModel>();
        }
    }
}
