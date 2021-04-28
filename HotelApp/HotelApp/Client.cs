using System;
using System.Collections.Generic;
using System.Text;

namespace HotelApp
{
    public class Client
    {
        public string firstName { get; private set; }
        public string lastName { get; private set; }

        public Client() { }

        public Client(string firstName = null, string lastName = null)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}
