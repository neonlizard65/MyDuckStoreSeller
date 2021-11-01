using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Instances
{
    public class VideocardInstanceList
    {
        public List<VideocardInstance> videocardinstance { get; set; }
    }

    public class VideocardInstance : Instance
    {
        public string VideocardInstanceID { get; set; }
        public string VideocardId { get; set; }

        public VideocardInstance(string VideocardInstanceID, string VideocardId, string SerialNumber, string SellerId, string InstanceId, string Sold, string Price) : base(SellerId, InstanceId, Sold, SerialNumber, Price)
        {
            this.VideocardInstanceID = VideocardInstanceID;
            this.VideocardId = VideocardId;
        }
    }
}
