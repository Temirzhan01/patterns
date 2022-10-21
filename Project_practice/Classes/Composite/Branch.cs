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
        public bool Check(Component c)
        {
            for (int i = 0; i < children.Count; i++) 
            {
                if (children[i] == c) 
                {
                    return true;
                }
            }
            return false;
        }
    }
}
