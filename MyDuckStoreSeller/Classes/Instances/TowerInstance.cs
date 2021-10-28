using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Instances
{
    public class TowerInstanceList
    {
        public List<TowerInstance> Towerinstance { get; set; }
    }

    public class TowerInstance : Instance
    {
        public string TowerInstanceID { get; set; }
        public string TowerId { get; set; }

        public TowerInstance(string TowerInstanceID, string TowerId, string SerialNumber, string SellerId, string InstanceId, string Sold) : base(SellerId, InstanceId, Sold, SerialNumber)
        {
            this.TowerInstanceID = TowerInstanceID;
            this.TowerId = TowerId;
        }
    }
}
