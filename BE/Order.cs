using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Order
    {
        public long HostingUnitKey { set; get; }
        public long GuestRequestKey { set; get; }
        public long OrderKey { set; get; }
        public Enum Status;
        public uint commission { get; set; }
        public DateTime CreateDate { set; get; }
        public DateTime OrderDate { set; get; }
        public override string ToString()
        {
            return OrderKey + " ";
        }

    }

}
