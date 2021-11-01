using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Instances
{
    public class HeadphonesInstanceList
    {
        public List<HeadphonesInstance> headphonesinstance { get; set; }
    }

    public class HeadphonesInstance : Instance
    {
        public string HeadphonesInstanceID { get; set; }
        public string HeadphonesId { get; set; }

        public HeadphonesInstance(string HeadphonesInstanceID, string HeadphonesId, string SerialNumber, string SellerId, string InstanceId, string Sold, string Price) : base(SellerId, InstanceId, Sold, SerialNumber, Price)
        {
            this.HeadphonesInstanceID = HeadphonesInstanceID;
            this.HeadphonesId = HeadphonesId;
        }
    }
}
