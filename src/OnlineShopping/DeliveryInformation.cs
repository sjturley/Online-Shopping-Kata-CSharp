namespace OnlineShopping
{
    public class DeliveryInformation : IModelObject
    {
        private string deliveryAddress;
        private Store pickupLocation;
        private string type;
        private long weight;

        public DeliveryInformation(string type, Store pickupLocation, long weight)
        {
            this.type = type;
            this.pickupLocation = pickupLocation;
            this.weight = weight;
        }

        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public string DeliveryAddress
        {
            set { this.deliveryAddress = value; }
            get { return deliveryAddress; }
        }

        public Store PickupLocation
        {
            get { return pickupLocation; }
            set { pickupLocation = value; }
        }

        public long TotalWeight
        {
            set { this.weight = value; }
        }
    }
}