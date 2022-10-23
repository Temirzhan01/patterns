namespace Project_practice.Classes.Iterator
{
    public interface Iterator
    {
        public abstract object First();
        public abstract bool HasNext();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }
}
