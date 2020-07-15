namespace OnlineShopping
{
    public class StoreEvent : Item
    {
        private Store location;

        public StoreEvent(string name, Store location) : base(name, "EVENT", 0) {
            SetLocation(location);
        }

        public void SetLocation(Store locationStore) {
            this.location = locationStore;
            location.AddStoreEvent(this);
        }
    }
}