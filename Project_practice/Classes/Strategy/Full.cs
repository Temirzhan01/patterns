using Project_practice.Classes.Composite;
using Project_practice.Classes.Singleton;
using Project_practice.Classes.Adapter;
using Project_practice.Classes.Factory;
using Project_practice.Classes.Intermediate;
using Project_practice.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Project_practice.Classes.Strategy
{
    public class Full : IStrategy
    {
        public async Task Creating(bool type, string key, string a1, string a2, string a3, string a4)
        {
            Creator creator;
            if (type)
            {
                creator = new TextCCReator();
            }
            else 
            {
                creator = new QuestionCCreator();
            }
            Card card;
            card = creator.FactoryMethod(a1, a2, a3, a4, key);
            card.creator = UserInfo.Login!;
            string json = Adapter.Adapter.Converter(card);
            Cardjson cj = new Cardjson();
            cj.userId = UserInfo.Id;
            cj.jsoncard = json;
            cj.type = type;
            using (ApplicationContext context = new ApplicationContext()) 
            {
                context.Cardjsons.Add(cj);
                await context.SaveChangesAsync();
            }
        }
        public IEnumerable<Connecter> Showing(IEnumerable<Cardjson> cardjsons)
        {
            List<TextCard> textlist = new List<TextCard>();
            List<QuestionCard> questionlist = new List<QuestionCard>();
            foreach (Cardjson item in cardjsons) 
            {
                if (item.type)
                {
                    TextCard cardt = JsonConvert.DeserializeObject<TextCard>(item.jsoncard)!;
                    textlist.Add(cardt);                    
                }
                else
                {
                    QuestionCard cardq = JsonConvert.DeserializeObject<QuestionCard>(item.jsoncard)!;
                    questionlist.Add(cardq);
                }
            }
            List<Connecter> connecters = new List<Connecter>();
            connecters.Add(new Connecter(textlist, questionlist));
            return connecters.AsEnumerable();
        }
    }
}
