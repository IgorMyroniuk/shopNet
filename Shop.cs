using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopNet
{
    [Serializable()]
    public class Shop
    {
        public bool saveChangeFlag = false;
        public string name;
        public string address;
        public DateTime openDate;
        public Provider provider1;
        public Provider provider2;


        public Shop(string shopName)
        {
            this.name = shopName;
            this.address = "Адреса не заповнена";
            this.provider1 = new Provider();
            this.provider2 = new Provider();
        }
        public Shop(string shopName, string shopAddress) : this(shopName)
        {
            this.address = shopAddress;
        }
        public Shop(string shopName, string shopAddress, Provider provider1) : this(shopName, shopAddress)
        {
            this.provider1 = provider1;
        }
        public Shop(string shopName, string shopAddress, Provider provider1, Provider provider2) : this(shopName, shopAddress, provider1)
        {
            this.provider2 = provider2;
        }

        public override string ToString()
        {
            return name + ", " + address;
        }
    }
}
