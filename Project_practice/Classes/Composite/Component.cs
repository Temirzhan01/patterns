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
        public virtual void Update(Component c) {}
    }
}
