using Project_practice.Classes.Strategy;

namespace Project_practice.Classes.Factory
{
    public class TextCard : Card
    {
        IStrategy strategy;
        public string key;
        public string value;
        public TextCard(IStrategy strategy, string a1, string a2, string a3, string a4, string key) : base(strategy,a1,a2,a3,a4,key)
        {
            this.key = key;
            this.value = a1;
        }
    }
}
