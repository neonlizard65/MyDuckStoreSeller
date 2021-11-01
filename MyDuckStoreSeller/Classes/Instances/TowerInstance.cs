using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Instances
{
    public class TowerInstanceList
    {
        public List<TowerInstance> towerinstance { get; set; }
    }

    public class TowerInstance : Instance
    {
        public string TowerInstanceID { get; set; }
        public string TowerId { get; set; }

        public TowerInstance(string TowerInstanceID, string TowerId, string SerialNumber, string SellerId, string InstanceId, string Sold, string Price) : base(SellerId, InstanceId, Sold, SerialNumber, Price)
        {
            this.TowerInstanceID = TowerInstanceID;
            this.TowerId = TowerId;
        }
    }
}
