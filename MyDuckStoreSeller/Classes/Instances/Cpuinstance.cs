using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Instances
{
    public class CpuInstanceList
    {
        public List<CpuInstance> Cpuinstance { get; set; }
    }

    public class CpuInstance : Instance
    {
        public string CpuInstanceID { get; set; }
        public string CpuId { get; set; }

        public CpuInstance(string CpuInstanceID, string CpuId, string SerialNumber, string SellerId, string InstanceId, string Sold, string Price) : base(SellerId, InstanceId, Sold, SerialNumber, Price)
        {
            this.CpuInstanceID = CpuInstanceID;
            this.CpuId = CpuId;
        }
    }
}
