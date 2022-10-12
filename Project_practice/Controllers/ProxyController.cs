using Microsoft.AspNetCore.Mvc;
using Project_practice.Classes;
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
            bool fl = page.Ischeck(login, password);
            if (fl)
            {
                return Redirect("~/Home/Indexreal");
            }
            else return Redirect("~/Home/Indexunreal");
        }
    }
}
