using Project_practice.Models;
using Project_practice.Classes.Factory;
using Project_practice.Classes.Intermediate;

namespace Project_practice.Classes.Strategy
{
    public interface IStrategy
    {
        public Task Creating(bool type, string key, string a1, string a2, string a3, string a);
        public IEnumerable<Connecter> Showing(IEnumerable<Cardjson> cardjsons);
    }
}
