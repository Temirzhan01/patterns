namespace Project_practice.Classes.Composite
{
    public abstract class Component
    {
        protected string name;
        public Component(string name) { this.name = name; }
        public virtual void Add(Component c) { }
        public virtual void Remove(Component c) { }
    }
}
