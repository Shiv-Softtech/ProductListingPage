using ProductListingPage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductListingPage.Service
{
    public interface IProductService
    {
       List<Product> GetProductDetail(int productId);
    }
}
