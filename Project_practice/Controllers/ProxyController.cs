﻿using Microsoft.AspNetCore.Mvc;
using Project_practice.Classes.Proxy;
using Project_practice.Classes.Factory;
using Project_practice.Classes.Strategy;
using Project_practice.Classes.Singleton;
using Project_practice.Models;
namespace Project_practice.Controllers
{
    public class ProxyController : Controller
    {
        public IActionResult Auth()
        {
            return View();
        }
        public IActionResult Check(string login, string password)
        {
            Page page = new Proxy();
            UserInfo.Login = login;
            UserInfo.Password = password;
            bool fl = page.Ischeck(login, password);
            if (fl)
            {
                return Redirect("~/Home/Indexreal");
            }
            else return Redirect("~/Home/Indexunreal");
        }
    }
}
