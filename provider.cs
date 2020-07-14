using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopNet
{
    [Serializable()]
    public class Provider
    {
        public bool isActive;
        public DateTime connectDayTime;
        public byte ethPort;
        public string ipAddress;
        public string name;
        public string customer;
        public string contractNumber;
        public string phoneNumber;
        public byte connectionType;
        public string connectionSettings0;
        public string connectionSettings1;
        public string connectionSettings2;


        public override string ToString()
        {
            return name + " - " + ethPort;
        }
    }
}
