using System;
using System.Collections.Generic;

namespace OnlineShopping
{
    public class Session
    {
        private Dictionary<string, IModelObject> session;

        public Session()
        {
            session = new Dictionary<string, IModelObject>
            {
                {"CART", new Cart()}, {"LOCATION_SERVICE", new LocationService()}
            };
        }

        public IModelObject Get(string key)
        {
            return !this.session.ContainsKey(key) ? null : this.session[key];
        }

        public void Put(string key, IModelObject value)
        {
            this.session.Add(key, value);
        }
    }
}