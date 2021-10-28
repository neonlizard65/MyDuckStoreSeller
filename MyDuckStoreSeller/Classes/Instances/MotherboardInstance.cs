using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Instances
{
    public class MotherboardInstanceList
    {
        public List<MotherboardInstance> Motherboardinstance { get; set; }
    }

    public class MotherboardInstance : Instance
    {
        public string MotherboardInstanceID { get; set; }
        public string MotherboardId { get; set; }

        public MotherboardInstance(string MotherboardInstanceID, string MotherboardId, string SerialNumber, string SellerId, string InstanceId, string Sold) : base(SellerId, InstanceId, Sold, SerialNumber)
        {
            this.MotherboardInstanceID = MotherboardInstanceID;
            this.MotherboardId = MotherboardId;
        }
    }
}
