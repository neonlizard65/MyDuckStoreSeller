using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Products
{
    
    public class HddProducts
    {
        public List<Hdd> hdd { get; set; }
    }

    public class Hdd : Product
    {
        public string HddID { get; set; }
        public string UsageType { get; set; }
        public string FormFactor { get; set; }
        public string Interface { get; set; }
        public string VolumeGB { get; set; }
        public string BufferMB { get; set; }
        public string Speed { get; set; }
    
        public Hdd(string HddID, string ArticulId, string ManufacturerId, string ManufacturerName, string ManufacturerSite, string ManufacturerImagePath, string Name,
               string ImagePath, string ManufacturerCode, string UsageType, string FormFactor, string Interface,
               string VolumeGB, string BufferMB, string Speed, string GuaranteeMon)
               : base(ArticulId, ManufacturerId, ManufacturerName, ManufacturerSite, ManufacturerImagePath, Name, ImagePath, ManufacturerCode, GuaranteeMon)
        {
            this.HddID = HddID;
            this.UsageType = UsageType;
            this.FormFactor = FormFactor.Replace("&quot;", "\"");
            this.Interface = Interface;
            this.VolumeGB = VolumeGB;
            this.BufferMB = BufferMB;
            this.Speed = Speed;
        }
    }

}
