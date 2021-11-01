using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Instances
{
    public class PsuInstanceList
    {
        public List<PsuInstance> psuinstance { get; set; }
    }

    public class PsuInstance : Instance
    {
        public string PsuInstanceID { get; set; }
        public string PsuId { get; set; }

        public PsuInstance(string PsuInstanceID, string PsuId, string SerialNumber, string SellerId, string InstanceId, string Sold, string Price) : base(SellerId, InstanceId, Sold, SerialNumber, Price)
        {
            this.PsuInstanceID = PsuInstanceID;
            this.PsuId = PsuId;
        }
    }
}
