using Project_practice.Classes.Strategy;

namespace Project_practice.Classes.Factory
{
    public class TextCCReator : Creator
    {
        public override Card FactoryMethod(IStrategy strategy)
        {
            return new TextCard(strategy);
        }
    }
}
