using Project_practice.Classes.Composite;

namespace Project_practice.Classes.Iterator
{
    public abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
        public abstract int Count { get; protected set; }
        public abstract Component this[int index] { get; set; }
    }
}
