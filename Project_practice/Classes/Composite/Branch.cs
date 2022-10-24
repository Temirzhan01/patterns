namespace Project_practice.Classes.Composite
{
    public class Branch : Component
    {
        List<Component> children = new List<Component>();
        public Branch(string name) : base(name) { }
        public override void Add(Component c) 
        {
            if (!Check(c.Name())) 
            {
                children.Add(c);
            }
        }
        public override void Remove(Component c) 
        {
            children.Remove(c);
        }
        public override bool Check(string s)
        {
            foreach(Component item in children) 
            {
                if (item.Name() == s) { return true; }
            }
            return false;
        }
        public override void Update(Component c)
        {
            foreach (Component item in children)
            {
                if (item.Name() == c.Name()) 
                {
                    item.Add(c);
                }
            }
        }
    }
}
