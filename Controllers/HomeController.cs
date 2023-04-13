using Microsoft.Ajax.Utilities;
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
    public class HomeController : Controller
    {
        // GET: Home
        private readonly IUserService _userService;
        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index(User userData)
        {
          // List<User> userInfo = _userService.GetUsers(userData);
            return View();
        }

        [HttpPost]
        public ActionResult AjaxMethod(UserModels name)
        {
           

            return View();
        }

        //public List<User> GetUser(User userData)
        //{
        //    List<User> userInfo = _userService.GetUsers(userData);
        //    return userInfo;


        //}
      

    }
} 