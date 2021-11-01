using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Instances
{
    public class KeyboardInstanceList
    {
        public List<KeyboardInstance> keyboardinstance { get; set; }
    }

    public class KeyboardInstance : Instance
    {
        public string KeyboardInstanceID { get; set; }
        public string KeyboardId { get; set; }

        public KeyboardInstance(string KeyboardInstanceID, string KeyboardId, string SerialNumber, string SellerId, string InstanceId, string Sold, string Price) : base(SellerId, InstanceId, Sold, SerialNumber, Price)
        {
            this.KeyboardInstanceID = KeyboardInstanceID;
            this.KeyboardId = KeyboardId;
        }
    }
}
