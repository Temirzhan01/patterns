namespace Project_practice.Classes.Composite
{
    public class Branch : Component
    {
        List<Component> children = new List<Component>();
        public Branch(string name) : base(name) { }
        public bool Check(Component c)
        {
           foreach (var item in children) {
                    if (item == c)
                    {
                        return true;
                    }
           }
            return false;
        }
        public override void Add(Component c) 
        {
            bool b = Check(c);
            if (b == false)
            {
                children.Add(c);
            }
        }
        public override void Remove(Component c) 
        {
            children.Remove(c);
        }
      
    }
}
