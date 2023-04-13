using ProductListingPage.Entity;
using ProductListingPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductListingPage.Repository
{
    public interface IUserRepository
    {
      
       
        List<Product> GetAllProduct(Product productData);
        List<Product> GetProductsCategory(Product productData);
        List<Product> GetLowToHighProduct(string productData);

        void InsertUser(User userData);
        List<User> GetUsers();

    }
}
