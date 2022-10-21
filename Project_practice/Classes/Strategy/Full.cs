using Project_practice.Classes.Composite;
using Project_practice.Classes.Singleton;
using Project_practice.Classes.Adapter;
using Project_practice.Classes.Factory;
using Project_practice.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Project_practice.Classes.Strategy
{
    public class Full : IStrategy
    {
        public async Task Creating(ApplicationContext context,Card card)
        {
            string json = Adapter.Adapter.Converter(card);
            Cardjson cj = new Cardjson();
            cj.userId = UserInfo.Id;
            cj.jsoncard = json;
            context.Cardjsons.Add(cj);
            await context.SaveChangesAsync();
        }
        public List<Card> Showing(IEnumerable<Cardjson> cardjsons)
        {
            List<TextCard> textlist = new List<TextCard>();
            List<QuestionCard> questionlist = new List<QuestionCard>();
            foreach (Cardjson item in cardjsons) 
            {
                QuestionCard cardq = JsonConvert.DeserializeObject<QuestionCard>(item.jsoncard)!;
                if (cardq.values[1] != null)
                {
                    questionlist.Add(cardq);
                }
                else 
                {
                    TextCard cardt = JsonConvert.DeserializeObject<TextCard>(item.jsoncard)!;
                    textlist.Add(cardt);
                }
            }
        }
    }
}
