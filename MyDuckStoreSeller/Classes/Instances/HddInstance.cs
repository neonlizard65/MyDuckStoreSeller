using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Instances
{
    public class HddInstanceList
    {
        public List<HddInstance> hddinstance { get; set; }
    }

    public class HddInstance : Instance
    {
        public string HddInstanceID { get; set; }
        public string HddId { get; set; }

        public HddInstance(string HddInstanceID, string HddId, string SerialNumber, string SellerId, string InstanceId, string Sold, string Price) : base(SellerId, InstanceId, Sold, SerialNumber, Price)
        {
            this.HddInstanceID = HddInstanceID;
            this.HddId = HddId;
        }
    }
}
