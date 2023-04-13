using AutoMapper;
using ProductListingPage.Entity;
using ProductListingPage.Models;
using ProductListingPage.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductListingPage.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        public ProductsController(IUserService userService , IProductService productService)
        {
            _userService = userService;
            _productService = productService;
            
        }

        // GET: Products
        public ActionResult Products()
        {

            return View();
        }
        //public ActionResult Products(int productID)
        //{

        //    return View(productID);
        //}
        //public ActionResult ProductDetails()
        //{
        //    return View();
        //}
        //public ActionResult ProductDetails(int productID)
        //{
        //    var productDetail = _productService.GetProductDetail(productID);
        //      var productPageDetail = Mapper.Map<List<Product>, List<ProductModels>>(productDetail);

        //    ViewData["productDet"]=productPageDetail;
        //    return View(productPageDetail);
        //}
        public ActionResult ProductDetails()
        {
           

            return View();
        }
        public ActionResult AddToCart()
        {


            return View();
        }

        [HttpPost]
        public JsonResult ProductDetail(string name)
        {
            int id = Int32.Parse(name);

            return Json(id, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetProduct(Product productData)
        {
            var productInfo = _userService.GetAllProduct(productData);
            var productDetail = Mapper.Map<List<Product>, List<ProductModels>>(productInfo);
            return Json(productDetail, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetProductFilter(Product productData)
        { 
            var productFilter= _userService.GetProductsCategory(productData);
            var productFilters = Mapper.Map<List<Product>, List<ProductFilterModels>>(productFilter);
            return Json(productFilters, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
           public JsonResult GetLowHighPrice(string FeatureValue) {
            
            var productPrice = _userService.GetLowToHighProduct(FeatureValue);
            var productDetail = Mapper.Map<List<Product>, List<ProductModels>>(productPrice);

            // var productlowtohighprice= Mapper.Map<List<Product>, List<ProductModels>>(productPrice);
            // return Json(productlowtohighprice, JsonRequestBehavior.AllowGet);

            return Json(productDetail, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ProductDetails(int productID)
        {
            var productDetail = _productService.GetProductDetail(productID);
            var productPageDetail = Mapper.Map<List<Product>, List<ProductModels>>(productDetail);
            return Json(productPageDetail, JsonRequestBehavior.AllowGet);
        }



    }
}