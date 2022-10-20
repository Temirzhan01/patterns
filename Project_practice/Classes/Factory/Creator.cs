using Project_practice.Classes.Strategy;

namespace Project_practice.Classes.Factory
{
    public abstract class Creator
    {
        public abstract Card FactoryMethod(string a1, string a2, string a3, string a4, string key);
    }
}
