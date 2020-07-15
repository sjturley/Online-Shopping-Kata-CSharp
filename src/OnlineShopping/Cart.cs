using System.Collections.Generic;
using System.Text;

namespace OnlineShopping
{
    public class Cart : IModelObject
    {
        private readonly List<Item> items = new List<Item>();
        private readonly List<Item> unavailableItems = new List<Item>();

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void AddItems(IEnumerable<Item> newItems)
        {
            this.items.AddRange(newItems);
        }

        public void MarkAsUnavailable(Item item)
        {
            unavailableItems.Add(item);
        }
        
        public IEnumerable<Item> GetUnavailableItems()
        {
            return unavailableItems;
        }
    }
}