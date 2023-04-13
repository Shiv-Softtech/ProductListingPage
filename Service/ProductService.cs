using ProductListingPage.Entity;
using ProductListingPage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductListingPage.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
    
        public List<Product> GetProductDetail(int productId)
        {
            return _productRepository.GetProductDetail(productId);
           
        }
    }
}