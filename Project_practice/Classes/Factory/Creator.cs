using Project_practice.Classes.Strategy;

namespace Project_practice.Classes.Factory
{
    public abstract class Creator
    {
        public abstract Card FactoryMethod(IStrategy strategy);
    }
}
