using Project_practice.Models;
using Project_practice.Classes.Factory;
using Project_practice.Classes.Intermediate;

namespace Project_practice.Classes.Strategy
{
    public interface IStrategy
    {
        public Task Creating(Card card, bool type);
        public IEnumerable<Connecter> Showing(IEnumerable<Cardjson> cardjsons);
    }
}
