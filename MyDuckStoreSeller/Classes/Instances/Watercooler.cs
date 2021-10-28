﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Instances
{
    public class WatercoolerInstanceList
    {
        public List<WatercoolerInstance> Watercoolerinstance { get; set; }
    }

    public class WatercoolerInstance : Instance
    {
        public string WatercoolerInstanceID { get; set; }
        public string WatercoolerId { get; set; }

        public WatercoolerInstance(string WatercoolerInstanceID, string WatercoolerId, string SerialNumber, string SellerId, string InstanceId, string Sold) : base(SellerId, InstanceId, Sold, SerialNumber)
        {
            this.WatercoolerInstanceID = WatercoolerInstanceID;
            this.WatercoolerId = WatercoolerId;
        }
    }
}
