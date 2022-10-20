namespace Project_practice.Classes.Composite
{
    public class Branch : Component
    {
        List<Component> children = new List<Component>();
        public Branch(string name) : base(name) { }
        public override void Add(Component c) 
        {
            children.Add(c);
        }
        public override void Remove(Component c) 
        {
            children.Remove(c);
        }
    }
}
