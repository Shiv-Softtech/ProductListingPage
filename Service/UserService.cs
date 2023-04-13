using ProductListingPage.Entity;
using ProductListingPage.Models;
using ProductListingPage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductListingPage.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<Product> GetAllProduct(Product productData)
        {
            List<Product> product = _userRepository.GetAllProduct(productData);
            return product;
        }

        public List<Product> GetLowToHighProduct(string productData)
        {
            List<Product> productlowtohighPrice = _userRepository.GetLowToHighProduct(productData);
            return productlowtohighPrice;
        }

        public List<Product> GetProductsCategory(Product productData)
        {
            List<Product> productcategory = _userRepository.GetProductsCategory(productData);
            return productcategory;
        }

        //public List<User> GetUsers(User userData)
        //{

        //    List<User> users = _userRepository.GetUsers(userData);
        //    return users;
        //}

      public bool InsertUser(User userData)
        {

            var regisdata = _userRepository.GetUsers();
            bool isVailid= regisdata.Any(x=>x.Email== userData.Email);
            if(!isVailid)
                _userRepository.InsertUser(userData);
           
            return isVailid;   
        }
        public List<User> LoginAuth(User loginData)
        {
            var regisdata= _userRepository.GetUsers();

            List<User> getloginrecord = new List<User>();
            foreach (var user in regisdata)
            {
                if(user.Email == loginData.Email && user.Password == loginData.Password)
                {
                    getloginrecord.Add(user);
                    break;
                }
            }
          //bool isVailid= regisdata.Any(x=>x.Email==loginData.Email && x.Password==loginData.Password);

            return getloginrecord;
        }

    }
}