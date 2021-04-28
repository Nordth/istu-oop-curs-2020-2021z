using System;
using System.Collections.Generic;
using System.Text;

namespace HotelApp
{
    public class Service
    {
        public string serviceName { get; private set; }
        public int servicePrice { get; private set; }
        public Service(string serviceName, int servicePrice)
        {
            this.serviceName = serviceName;
            this.servicePrice = servicePrice;
        }
    }
}
