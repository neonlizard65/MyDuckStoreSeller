using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Instances
{
    public class PsuInstanceList
    {
        public List<PsuInstance> Psuinstance { get; set; }
    }

    public class PsuInstance : Instance
    {
        public string PsuInstanceID { get; set; }
        public string PsuId { get; set; }

        public PsuInstance(string PsuInstanceID, string PsuId, string SerialNumber, string SellerId, string InstanceId, string Sold) : base(SellerId, InstanceId, Sold, SerialNumber)
        {
            this.PsuInstanceID = PsuInstanceID;
            this.PsuId = PsuId;
        }
    }
}
