using Project_practice.Classes.Composite;

namespace Project_practice.Classes.Iterator
{
    public interface Iterator
    {
        public abstract bool HasNext();
        public abstract Component Next();
        public abstract Component CurrentItem();
        public abstract Component First();
    }
}
