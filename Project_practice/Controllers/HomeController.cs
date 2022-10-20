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
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            context = new ApplicationContext();
        }
        [HttpGet]
        public async Task<IActionResult> IndexReal()
        {
            return View(await context.Cardjsons.Where(x => x.userId == UserInfo.Id).ToListAsync());
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
            }
            else
            {
                card = creatort.FactoryMethod(a1, a2, a3, a4, key);
            }
            string json = Adapter.Converter(card);
            Cardjson cj = new Cardjson();
            cj.userId = UserInfo.Id;
            cj.jsoncard = json;
            context.Cardjsons.Add(cj);
            await context.SaveChangesAsync();
            return RedirectToAction("IndexReal");
        }
        public void CreateQuestionCard(string question, string a1, string a2, string a3, string a4)
        {
            Card card;
            if (UserInfo.Login != null & UserInfo.Password != null)
            {
                card = creatorq.FactoryMethod(a1, a2, a3, a4, question);
                card.creator = UserInfo.Login!;
            }
            else
            {
                card = creatorq.FactoryMethod(a1, a2, a3, a4, question);
            }
            string json = Adapter.Converter(card);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}