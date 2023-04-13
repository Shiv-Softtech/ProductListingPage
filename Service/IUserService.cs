using ProductListingPage.Entity;
using ProductListingPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductListingPage.Service
{
    public interface IUserService
    {
      
        List<Product> GetAllProduct(Product productData);
        List<Product> GetProductsCategory(Product productData);
        List<Product> GetLowToHighProduct(string productData);

       bool InsertUser(User userData);
        List<User> LoginAuth(User userData);

    }
}
