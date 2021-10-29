using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Instances
{
    public class UsbFlashInstanceList
    {
        public List<UsbFlashInstance> UsbFlashinstance { get; set; }
    }

    public class UsbFlashInstance : Instance
    {
        public string UsbFlashInstanceID { get; set; }
        public string UsbFlashId { get; set; }

        public UsbFlashInstance(string UsbFlashInstanceID, string UsbFlashId, string SerialNumber, string SellerId, string InstanceId, string Sold, string Price) : base(SellerId, InstanceId, Sold, SerialNumber, Price)
        {
            this.UsbFlashInstanceID = UsbFlashInstanceID;
            this.UsbFlashId = UsbFlashId;
        }
    }
}
