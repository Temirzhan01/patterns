using Project_practice.Models;
using Project_practice.Classes.Factory;

namespace Project_practice.Classes.Strategy
{
    public interface IStrategy
    {
        public Task Creating(ApplicationContext context, Card card);
        public List<Card> Showing(IEnumerable<Cardjson> cardjsons);
    }
}
