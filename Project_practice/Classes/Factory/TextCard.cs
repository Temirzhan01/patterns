using Project_practice.Classes.Strategy;

namespace Project_practice.Classes.Factory
{
    public class TextCard : Card
    {
        public string key;
        public string value;
        public TextCard(string a1, string a2, string a3, string a4, string key) : base(a1,a2,a3,a4,key)
        {
            this.key = key;
            this.value = a1;
        }
    }
}
