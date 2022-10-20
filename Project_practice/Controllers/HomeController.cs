using Microsoft.AspNetCore.Mvc;
using Project_practice.Models;
using Project_practice.Classes.Factory;
using Project_practice.Classes.Singleton;
using Project_practice.Classes.Strategy;
using Project_practice.Classes.Adapter;
using Project_practice.Classes.Composite;
using System.Diagnostics;

namespace Project_practice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Creator creatort = new TextCCReator();
        Creator creatorq = new QuestionCCreator();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult IndexReal()
        {
            return View();
        }
        public IActionResult IndexUnreal()
        {
            return View();
        }
        [HttpPost]
        public void CreateTextCard(string key, string a1, string a2, string a3, string a4)
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