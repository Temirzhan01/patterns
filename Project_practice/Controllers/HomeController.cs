using Microsoft.AspNetCore.Mvc;
using Project_practice.Models;
using Project_practice.Classes.Factory;
using Project_practice.Classes.Singleton;
using Project_practice.Classes.Strategy;
using Project_practice.Classes.Adapter;
using Project_practice.Classes.Iterator;
using Project_practice.Classes.Composite;
using Project_practice.Classes.Intermediate;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
namespace Project_practice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ApplicationContext context;
        Creator creatort = new TextCCReator();
        Creator creatorq = new QuestionCCreator();
        IStrategy strategy;
        static Component texts = new Branch("Text");
        static Component questions = new Branch("Question");
        static int ct = 0;
        static Aggregate a = new ConcreteAggregate();
        

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
        public IActionResult IndexUnreal()
        {
            strategy = new NotFull();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ShowReal(IEnumerable<Connecter> cards)
        {
            return PartialView(cards);
        }
        [HttpGet]
        public async Task<IActionResult> ShowUnreal()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTextCard(string key, string a1, string a2, string a3, string a4)
        {
            Card card;
            Iterator i = a.CreateIterator();
            if (UserInfo.Login != null & UserInfo.Password != null)
            {
                card = creatort.FactoryMethod(a1, a2, a3, a4, key);
                card.creator = UserInfo.Login!;
                strategy = new Full();
                await strategy.Creating(card, true);
                Leaf lf = new Leaf(key, card);
                texts.Add(lf);
                MainRoot.main.Add(texts);
                a[ct] = lf;
                ct++;
                object item = i.First();
                while (!i.IsDone())
                {
                    item = i.Next();
                }
                return RedirectToAction("IndexReal");
            }
            else
            {
                card = creatort.FactoryMethod(a1, a2, a3, a4, key);
                strategy = new NotFull();
                await strategy.Creating(card, true);
                Leaf lf = new Leaf(key, card);
                texts.Add(lf);
                MainRoot.main.Add(texts);
                a[ct] = lf;
                ct++;
                object item = i.First();
                while (!i.IsDone())
                {
                    item = i.Next();
                }
                return RedirectToAction("IndexUnreal");
            }
        }
        public async Task<IActionResult> CreateQuestionCard(string question, string a1, string a2, string a3, string a4)
        {
            Card card;
            Iterator i = a.CreateIterator();
            if (UserInfo.Login != null & UserInfo.Password != null)
            {
                card = creatorq.FactoryMethod(a1, a2, a3, a4, question);
                card.creator = UserInfo.Login!;
                strategy = new Full();
                await strategy.Creating(card, false);
                Leaf lf = new Leaf(question, card);
                questions.Add(lf);
                MainRoot.main.Add(questions);
                a[ct] = lf;
                ct++;
                object item = i.First();
                while (!i.IsDone())
                {
                    item = i.Next();
                }
                return RedirectToAction("IndexReal");
            }
            else
            {
                card = creatorq.FactoryMethod(a1, a2, a3, a4, question);
                strategy = new NotFull();
                await strategy.Creating(card, false);
                Leaf lf = new Leaf(question, card);
                questions.Add(lf);
                MainRoot.main.Add(questions);
                a[ct] = lf;
                ct++;
                object item = i.First();
                while (!i.IsDone())
                {
                    item = i.Next();
                }
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