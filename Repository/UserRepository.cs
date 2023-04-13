using ProductListingPage.Data;
using ProductListingPage.Entity;
using ProductListingPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductListingPage.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserDataFactory _userDataFactory;
        private UserDataContext _userDataContext;
        public UserRepository(IUserDataFactory userDataFactory)
        {
            _userDataFactory = userDataFactory;
            _userDataContext = userDataFactory.GetUserDataContext();
        }

        public List<Product> GetAllProduct(Product productData)
        {
            var productRep = _userDataContext.GetAllProduct_20220905().ToList();
            var productResp = (from o in productRep
                        select new Product
                        {    Id =o.Id,
                            Title = o.Title,
                            Price= (decimal)o.Price,
                            Rating= (int)o.Rating,
                            Image=o.image,
                            Hover_Image=o.Hover_Image,
                            Category=o.Categories,
                            Size=o.Size,
                            Color=o.Color,
                            Brand=o.Brand
                        }).ToList();
            return productResp;
        }

        public List<Product> GetLowToHighProduct(string product)
        {
            var productLowtoHigh=_userDataContext.GetLowToHighProduct_20220906(product).ToList();
            var lowToHighResp = (from o in productLowtoHigh
                                 select new Product
                                 {
                                     Id = o.Id,
                                     Title = o.Title,
                                     Price = (decimal)o.Price,
                                     Rating = (int)o.Rating,
                                     Image = o.image,
                                     Hover_Image = o.Hover_Image,
                                     Category = o.Categories,
                                     Size = o.Size,
                                     Color = o.Color,
                                     Brand = o.Brand
                                 }).ToList();
            return lowToHighResp;   
        }

        public List<Product> GetProductsCategory(Product productData)
        { 
         var productCategory=_userDataContext.GetProductCategory_20220906().ToList();
            var productsCategoryResp = (from o in productCategory
                                        select new Product
                                        {
                                            Category = o.Categories
                                        }).ToList();
            return productsCategoryResp;    
        }



        public void InsertUser(User userData)
        {
            _userDataContext.InsertUser_20220907(userData.Name,userData.Email,userData.Mobile,userData.Gender,userData.Hobbies,userData.Department,userData.Password);
        }

        public List<User> GetUsers()
        {
            var userRep = _userDataContext.GetUser_20220910().ToList();
            var resp = (from o in userRep
                        select new User
                        {
                            Id = o.Id,
                            Name=o.UserName,
                            Email=o.Email,  
                            Password=o.Password
                          
                        }).ToList();
            return resp;
        }

    }
}