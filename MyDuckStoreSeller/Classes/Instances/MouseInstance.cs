using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Instances
{
    public class MouseInstanceList
    {
        public List<MouseInstance> Mouseinstance { get; set; }
    }

    public class MouseInstance : Instance
    {
        public string MouseInstanceID { get; set; }
        public string MouseId { get; set; }

        public MouseInstance(string MouseInstanceID, string MouseId, string SerialNumber, string SellerId, string InstanceId, string Sold, string Price) : base(SellerId, InstanceId, Sold, SerialNumber, Price)
        {
            this.MouseInstanceID = MouseInstanceID;
            this.MouseId = MouseId;
        }
    }
}
