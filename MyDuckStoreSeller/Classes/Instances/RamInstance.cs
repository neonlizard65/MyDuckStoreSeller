using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Instances
{
    public class RamInstanceList
    {
        public List<RamInstance> raminstance { get; set; }
    }

    public class RamInstance : Instance
    {
        public string RamInstanceID { get; set; }
        public string RamId { get; set; }

        public RamInstance(string RamInstanceID, string RamId, string SerialNumber, string SellerId, string InstanceId, string Sold, string Price) : base(SellerId, InstanceId, Sold, SerialNumber, Price)
        {
            this.RamInstanceID = RamInstanceID;
            this.RamId = RamId;
        }
    }
}
