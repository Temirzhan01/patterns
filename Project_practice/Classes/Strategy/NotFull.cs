using Project_practice.Classes.Composite;
using Project_practice.Classes.Singleton;
using Project_practice.Classes.Factory;
using Project_practice.Classes.Intermediate;
using Project_practice.Models;
using Microsoft.EntityFrameworkCore;

namespace Project_practice.Classes.Strategy
{
    public class NotFull : IStrategy
    {
        public async Task Creating(Card card, bool type)
        {
            Component comp = new Branch(card.creator);
            Component leaf = new Leaf("card", card);
            comp.Add(leaf);
            MainRoot.main.Add(comp);
        }
        public IEnumerable<Connecter> Showing(IEnumerable<Cardjson> cardjsons) 
        {
            return null;
        }
    }
}
