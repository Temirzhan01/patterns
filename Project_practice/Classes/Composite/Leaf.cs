using Project_practice.Classes.Factory;
using Project_practice.Classes.Iterator;

namespace Project_practice.Classes.Composite
{
    public class Leaf : Component
    {
        List<Component> children = new List<Component>();
        public Card card;
        public Leaf(string name, Card card) : base(name)
        {
            this.card = card;
        }
        public override Card GetCard()
        {
            return this.card;
        }
        public override int Count
        {
            get { return 0; }
            protected set { }
        }
        public override Component this[int index]
        {
            get { return children[index]; }
        }
    }
}
