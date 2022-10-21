using Microsoft.AspNetCore.Mvc;
using Project_practice.Models;
using Project_practice.Classes.Factory;
using Project_practice.Classes.Singleton;
using Project_practice.Classes.Strategy;
using Project_practice.Classes.Adapter;
using Project_practice.Classes.Composite;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Project_practice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ApplicationContext context;
        Creator creatort = new TextCCReator();
        Creator creatorq = new QuestionCCreator();
        IStrategy strategy;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            context = new ApplicationContext();
        }
        [HttpGet]
        public async Task<IActionResult> IndexReal()
        {
            return View(strategy.Showing(await context.Cardjsons.Where(x => x.userId == UserInfo.Id).ToListAsync()).ToList());
        }
        [HttpGet]
        public IActionResult IndexUnreal()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Show(IEnumerable<Cardjson> cardjsons) 
        {
            return PartialView(cardjsons);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTextCard(string key, string a1, string a2, string a3, string a4)
        {
            Card card;
            if (UserInfo.Login != null & UserInfo.Password != null)
            {
                card = creatort.FactoryMethod(a1, a2, a3, a4, key);
                card.creator = UserInfo.Login!;
                strategy = new Full();
                await strategy.Creating(context,card);
                return RedirectToAction("IndexReal");
            }
            else
            {
                card = creatort.FactoryMethod(a1, a2, a3, a4, key);
                strategy = new NotFull();
                await strategy.Creating(context,card);
                return RedirectToAction("IndexUnreal");
            }
        }
        public async Task<IActionResult> CreateQuestionCard(string question, string a1, string a2, string a3, string a4)
        {
            Card card;
            if (UserInfo.Login != null & UserInfo.Password != null)
            {
                card = creatorq.FactoryMethod(a1, a2, a3, a4, question);
                card.creator = UserInfo.Login!;
                strategy = new Full();
                await strategy.Creating(context,card);
                return RedirectToAction("IndexReal");
            }
            else
            {
                card = creatorq.FactoryMethod(a1, a2, a3, a4, question);
                strategy = new NotFull();
                await strategy.Creating(context, card);
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