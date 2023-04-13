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
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Account
       public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult LoginAuth(UserModels LoginData)
        {
            var userDetail = Mapper.Map<UserModels, User>(LoginData);
            var users = _userService.LoginAuth(userDetail);
            return Json(users,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public JsonResult InsertUser(UserModels UserData)
        {
            var userDetail = Mapper.Map<UserModels, User>(UserData);
            var users=_userService.InsertUser(userDetail);
            return Json(users, JsonRequestBehavior.AllowGet);
        }

      

    }
}