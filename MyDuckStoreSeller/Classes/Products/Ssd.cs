using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes
{

    public class SsdProducts
    {
        public List<Ssd> ssd { get; set; }
    }

    public class Ssd : Product
    {
        public string SsdID { get; set; }
        public string UsageType { get; set; }
        public string FormFactor { get; set; }
        public string Interface { get; set; }
        public string VolumeGB { get; set; }
        public string ReadSpeed { get; set; }
        public string WriteSpeed { get; set; }
        public string UsageHours { get; set; }

        public Ssd(string SsdID, string ArticulId, string ManufacturerId, string ManufacturerName, string ManufacturerSite, string ManufacturerImagePath, string Name,
            string ImagePath, string ManufacturerCode, string UsageType, string FormFactor, string Interface, 
            string VolumeGB, string ReadSpeed, string WriteSpeed, string UsageHours, string GuaranteeMon)
            : base(ArticulId, ManufacturerId, ManufacturerName, ManufacturerSite, ManufacturerImagePath, Name, ImagePath, ManufacturerCode, GuaranteeMon)
        {
            this.SsdID = SsdID;
            this.UsageType = UsageType;
            this.FormFactor = FormFactor;
            this.Interface = Interface;
            this.VolumeGB = VolumeGB;
            this.ReadSpeed = ReadSpeed;
            this.WriteSpeed = WriteSpeed;
            this.UsageHours = UsageHours;
        }
    }

    
}
