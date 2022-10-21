using Project_practice.Classes.Factory; 

namespace Project_practice.Classes.Composite
{
    public class Leaf : Component
    {
        public Card card;
        public Leaf(string name, Card card) : base(name)
        {
            this.card = card;
        }
    }
}
