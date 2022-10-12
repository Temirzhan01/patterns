using Project_practice.Classes.Strategy;

namespace Project_practice.Classes.Factory
{
    public abstract class Card
    {
        IStrategy strategy;
        public Card(IStrategy strategy)
        {
            this.strategy = strategy;
        }
    }
}
