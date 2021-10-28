using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Instances
{
    public class KeyboardInstanceList
    {
        public List<KeyboardInstance> Keyboardinstance { get; set; }
    }

    public class KeyboardInstance : Instance
    {
        public string KeyboardInstanceID { get; set; }
        public string KeyboardId { get; set; }

        public KeyboardInstance(string KeyboardInstanceID, string KeyboardId, string SerialNumber, string SellerId, string InstanceId, string Sold) : base(SellerId, InstanceId, Sold, SerialNumber)
        {
            this.KeyboardInstanceID = KeyboardInstanceID;
            this.KeyboardId = KeyboardId;
        }
    }
}
