using System.Collections.Generic;

namespace OnlineShopping
{
    public class Store : IModelObject
    {
        private Dictionary<string, Item> itemsInStock = new Dictionary<string, Item>();
        private string name;
        private bool droneDelivery;

        public Store(string name, bool droneDelivery)
        {
            this.name = name;
            this.droneDelivery = droneDelivery;
        }

        public void AddStockedItems(params Item[] items)
        {
            foreach (Item item in items)
            {
                this.itemsInStock.Add(item.Name, item);
            }
        }

        public void AddStoreEvent(StoreEvent storeEvent)
        {
            this.itemsInStock.Add(storeEvent.Name, storeEvent);
        }

        public void RemoveStockedItems(params Item[] items)
        {
            foreach (Item item in items)
            {
                this.itemsInStock.Remove(item.Name);
            }
        }

        public bool HasItem(Item item)
        {
            return itemsInStock.ContainsKey(item.Name);
        }

        public Item GetItem(string name)
        {
            return itemsInStock[name];
        }

        public bool HasDroneDelivery()
        {
            return droneDelivery;
        }
    }
}