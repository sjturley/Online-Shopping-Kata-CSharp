using System.Collections.Generic;

namespace OnlineShopping
{
    public class OnlineShopping
    {
        private Session session;

        public OnlineShopping(Session session)
        {
            this.session = session;
        }

        public void SwitchStore(Store storeToSwitchTo)
        {
            Cart cart = (Cart) session.Get("CART");
            DeliveryInformation deliveryInformation = (DeliveryInformation) session.Get("DELIVERY_INFO");
            if (storeToSwitchTo == null)
            {
                if (cart != null)
                {
                    foreach (Item item in cart.GetItems())
                    {
                        if ("EVENT" == (item.Type))
                        {
                            cart.MarkAsUnavailable(item);
                        }
                    }
                }

                if (deliveryInformation != null)
                {
                    deliveryInformation.Type = "SHIPPING";
                    deliveryInformation.PickupLocation = null;
                }
            }
            else
            {
                if (cart != null)
                {
                    List<Item> newItems = new List<Item>();
                    long weight = 0;
                    foreach (Item item in cart.GetItems())
                    {
                        if ("EVENT" == (item.Type))
                        {
                            if (storeToSwitchTo.HasItem(item))
                            {
                                cart.MarkAsUnavailable(item);
                                newItems.Add(storeToSwitchTo.GetItem(item.Name));
                            }
                            else
                            {
                                cart.MarkAsUnavailable(item);
                            }
                        }
                        else if (!storeToSwitchTo.HasItem(item))
                        {
                            cart.MarkAsUnavailable(item);
                        }

                        weight += item.Weight;
                    }

                    foreach (Item item in cart.GetUnavailableItems())
                    {
                        weight -= item.Weight;
                    }

                    Store currentStore = (Store) session.Get("STORE");
                    if (deliveryInformation != null
                        && deliveryInformation.Type != null
                        && "HOME_DELIVERY" == (deliveryInformation.Type)
                        && deliveryInformation.DeliveryAddress != null)
                    {
                        if (!((LocationService) session.Get("LOCATION_SERVICE")).IsWithinDeliveryRange(storeToSwitchTo,
                            deliveryInformation.DeliveryAddress))
                        {
                            deliveryInformation.Type = "PICKUP";
                            deliveryInformation.PickupLocation = currentStore;
                        }
                        else
                        {
                            deliveryInformation.TotalWeight = weight;
                            deliveryInformation.PickupLocation = storeToSwitchTo;
                        }
                    }
                    else
                    {
                        if (deliveryInformation != null
                            && deliveryInformation.DeliveryAddress != null)
                        {
                            if (((LocationService) session.Get("LOCATION_SERVICE")).IsWithinDeliveryRange(
                                storeToSwitchTo, deliveryInformation.DeliveryAddress))
                            {
                                deliveryInformation.Type = "HOME_DELIVERY";
                                deliveryInformation.TotalWeight = weight;
                                deliveryInformation.PickupLocation = storeToSwitchTo;
                            }
                        }
                    }

                    foreach (Item item in newItems)
                    {
                        cart.AddItem(item);
                    }
                }
            }

            session.Put("STORE", storeToSwitchTo);
        }
    }
}