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
        public async Task Creating(bool type, string key, string a1, string a2, string a3, string a4)
        {
            Creator creator;
            Component branch;
            if (type)
            {
                creator = new TextCCReator();
                branch = new Branch("texts");
            }
            else
            {
                creator = new QuestionCCreator();
                branch = new Branch("questions");
            }
            Card card;
            card = creator.FactoryMethod(a1, a2, a3, a4, key);
            MainRoot.main.Add(branch);
            Component leaf = new Leaf(MainRoot.i.ToString(),card);
            MainRoot.main.Update(leaf);
        }
        public IEnumerable<Connecter> Showing(IEnumerable<Cardjson> cardjsons)
        {
            return null;
        }
    }
}
