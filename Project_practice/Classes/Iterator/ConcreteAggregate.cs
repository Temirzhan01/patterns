using System.Collections;
using Project_practice.Classes.Composite;
namespace Project_practice.Classes.Iterator
{
    public class ConcreteAggregate : Aggregate
    {
        private readonly List<Component> _items = new List<Component>();

        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        public override int Count
        {
            get { return _items.Count; }
            protected set { }
        }

        public override Component this[int index]
        {
            get { return _items[index]; }
            set { _items.Insert(index, value); }
        }
    }
}
