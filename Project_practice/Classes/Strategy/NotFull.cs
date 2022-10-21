using Project_practice.Classes.Composite;
using Project_practice.Classes.Singleton;
using Project_practice.Classes.Factory;
using Project_practice.Models;
using Microsoft.EntityFrameworkCore;

namespace Project_practice.Classes.Strategy
{
    public class NotFull : IStrategy
    {
        public async Task Creating(ApplicationContext context, Card card) 
        {
            Component comp = new Branch(card.creator);
            Component leaf = new Leaf("card", card);
            comp.Add(leaf);
            MainRoot.main.Add(comp);
        }
        public List<Card> Showing(IEnumerable<Cardjson> cardjsons) 
        {

        }
    }
}
