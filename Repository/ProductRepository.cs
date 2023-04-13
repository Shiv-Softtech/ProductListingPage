using ProductListingPage.Data;
using ProductListingPage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductListingPage.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IUserDataFactory _userDataFactory;
        private UserDataContext _userDataContext;

        public ProductRepository(IUserDataFactory userDataFactory)
        {
            _userDataFactory = userDataFactory;
            _userDataContext = userDataFactory.GetUserDataContext();
        }
    
        public List<Product> GetProductDetail(int productId)
        {
            var productDetailRepo = _userDataContext.productDetail_20220909(productId).ToList();
            var productDetail = (from o in productDetailRepo
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
                                   Color = o.Color
                               }).ToList();
            return productDetail;

           
        }
    }
}