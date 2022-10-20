using Project_practice.Classes.Strategy;

namespace Project_practice.Classes.Factory
{
    public class TextCCReator : Creator
    {
        public override Card FactoryMethod(string a1, string a2, string a3, string a4, string key)
        {
            return new TextCard(a1, a2, a3, a4, key);
        }
    }
}
