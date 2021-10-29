using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Instances
{
    public class AircoolerInstanceList
    {
        public List<AircoolerInstance> aircoolerinstance { get; set; }
    }

    public class AircoolerInstance : Instance
    {
        public string AircoolerInstanceID { get; set; }
        public string AircoolerId { get; set; }

        public AircoolerInstance(string AircoolerInstanceID, string AircoolerId, string SerialNumber, string SellerId, string InstanceId, string Sold, string Price) : base(SellerId, InstanceId, Sold, SerialNumber, Price)
        {
            this.AircoolerInstanceID = AircoolerInstanceID;
            this.AircoolerId = AircoolerId;
        }
    }
}
