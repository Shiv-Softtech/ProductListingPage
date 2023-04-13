using ProductListingPage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductListingPage.Repository
{
    public interface IProductRepository
    {
        List<Product> GetProductDetail(int productId);
    }
}