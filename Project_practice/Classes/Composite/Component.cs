using Project_practice.Classes.Iterator;
using Project_practice.Classes.Factory;

namespace Project_practice.Classes.Composite
{
    public abstract class Component
    {
        protected string name;
        public Component(string name) { this.name = name; }
        public string Name() { return name; }
        public virtual void Add(Component c) { }
        public virtual void Remove(Component c) { }
        public virtual bool Check(string s) { return false; }
        public virtual Card GetCard() { return null; }
        public virtual Iterator.Iterator CreateIterator() { return null; }
        public abstract int Count { get; protected set; }
        public abstract Component this[int index] { get; }
    }
}
