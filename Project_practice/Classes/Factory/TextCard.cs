using Project_practice.Classes.Strategy;

namespace Project_practice.Classes.Factory
{
    public class TextCard : Card
    {
        IStrategy strategy;
        public TextCard(IStrategy strategy) : base(strategy)
        {
        }
    }
}
