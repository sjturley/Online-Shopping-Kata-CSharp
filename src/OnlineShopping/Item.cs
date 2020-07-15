namespace OnlineShopping
{
    public class Item : IModelObject
    {
        protected string name;
        protected string type;
        protected long weight;

        public Item(string name, string type, long weight)
        {
            this.name = name;
            this.type = type;
            this.weight = weight;
        }

        public string Type
        {
            get { return type; }
        }

        public string Name
        {
            get { return name; }
        }

        public long Weight
        {
            get { return weight; }
        }
    }
}