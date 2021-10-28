using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Instances
{
    public class Instance
    {
        public string SellerId { get; set; }
        public string InstanceId { get; set; }
        public string Sold { get; set; }
        public string SerialNumber { get; set; }
        public string SoldText { get; set; }

        public Instance(string SellerId, string InstanceId, string Sold, string SerialNumber)
        {
            this.SellerId = SellerId;
            this.InstanceId = InstanceId;
            this.Sold = Sold;
            this.SerialNumber = SerialNumber;
            if (Sold != null)
            {
                if (Convert.ToBoolean(Convert.ToInt32(Sold)))
                {
                    this.SoldText = "Товар продан.";
                }
                else
                {
                    this.SoldText = "";
                }
            }
            else
            {
                this.Sold = "0";
            }
        }
    }

}
