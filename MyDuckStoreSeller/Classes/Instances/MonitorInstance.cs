using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Instances
{
    public class MonitorInstanceList
    {
        public List<MonitorInstance> Monitorinstance { get; set; }
    }

    public class MonitorInstance : Instance
    {
        public string MonitorInstanceID { get; set; }
        public string MonitorId { get; set; }

        public MonitorInstance(string MonitorInstanceID, string MonitorId, string SerialNumber, string SellerId, string InstanceId, string Sold) : base(SellerId, InstanceId, Sold, SerialNumber)
        {
            this.MonitorInstanceID = MonitorInstanceID;
            this.MonitorId = MonitorId;
        }
    }
}
