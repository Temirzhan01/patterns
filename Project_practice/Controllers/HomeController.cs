using Microsoft.AspNetCore.Mvc;
using Project_practice.Models;
using Project_practice.Classes.Factory;
using Project_practice.Classes.Singleton;
using Project_practice.Classes.Strategy;
using Project_practice.Classes.Adapter;
using Project_practice.Classes.Composite;
using Project_practice.Classes.Intermediate;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
namespace Project_practice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ApplicationContext context;
        IStrategy strategy;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            context = new ApplicationContext();
        }
        [HttpGet]
        public async Task<IActionResult> IndexReal()
        {
            strategy = new Full();
            return View(strategy.Showing(await context.Cardjsons.Where(x => x.userId == UserInfo.Id).ToListAsync()));
        }
        [HttpGet]
        public async Task<IActionResult> IndexUnreal()
        {
            strategy = new NotFull();
            return View(strategy.Showing(await context.Cardjsons.Where(x => x.userId == UserInfo.Id).ToListAsync()));
        }
        [HttpGet]
        public async Task<IActionResult> Show(IEnumerable<Connecter> cards)
        {
            return PartialView(cards);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTextCard(string key, string a1, string a2, string a3, string a4)
        {
            if (UserInfo.Login != null & UserInfo.Password != null)
            {
                strategy = new Full();
                await strategy.Creating(true, key, a1, a2, a3, a4);
                return RedirectToAction("IndexReal");
            }
            else
            {
                strategy = new NotFull();
                await strategy.Creating(true, key, a1, a2, a3, a4);
                return RedirectToAction("IndexUnreal");
            }
        }
        public async Task<IActionResult> CreateQuestionCard(string key, string a1, string a2, string a3, string a4)
        {
            if (UserInfo.Login != null & UserInfo.Password != null)
            {
                strategy = new Full();
                await strategy.Creating(false, key, a1, a2, a3, a4);
                return RedirectToAction("IndexReal");
            }
            else
            {
                strategy = new NotFull();
                await strategy.Creating(false,key, a1, a2, a3, a4);
                return RedirectToAction("IndexUnreal");
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}