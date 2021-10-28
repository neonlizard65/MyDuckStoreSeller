using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Instances
{
    public class SsdInstanceList
    {
        public List<SsdInstance> ssdinstance { get; set; }
    }

    public class SsdInstance : Instance
    {
        public string SsdInstanceID { get; set; }
        public string SsdId { get; set; }

        public SsdInstance(string SsdInstanceID, string SsdId, string SerialNumber, string SellerId, string InstanceId, string Sold) : base(SellerId, InstanceId, Sold, SerialNumber)
        {
            this.SsdInstanceID = SsdInstanceID;
            this.SsdId = SsdId;
        }
    }

}
