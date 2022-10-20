using Project_practice.Classes.Strategy;

namespace Project_practice.Classes.Factory
{
    public abstract class Card
    {
        IStrategy strategy;
        public string creator { get; set; }
        public Card(IStrategy strategy, string a1, string a2, string a3, string a4, string key)
        {
            this.strategy = strategy;
        }
    }
}
