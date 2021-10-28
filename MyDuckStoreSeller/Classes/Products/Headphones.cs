using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Products
{
    public class HeadphonesProducts
    {
        public List<Headphones> headphones { get; set; }
    }

    public class Headphones : Product
    {
        public string HeadphonesID { get; set; }
        public string ConnectionType { get; set; }
        public string FrequencyRange { get; set; }
        public string SensitivitydB { get; set; }
        public string Jack { get; set; }
        public string MicrophoneSensitivity { get; set; }
        public string Weight { get; set; }

        public Headphones(string HeadphonesID, string ArticulId, string ManufacturerId, string ManufacturerName, string ManufacturerSite, string ManufacturerImagePath, string Name,
       string ImagePath, string ManufacturerCode, string ConnectionType, string FrequencyRange, string SensitivitydB,
       string Jack, string MicrophoneSensitivity, string Weight, string GuaranteeMon, string Quantity, string Price)
       : base(ArticulId, ManufacturerId, ManufacturerName, ManufacturerSite, ManufacturerImagePath, Name, ImagePath, ManufacturerCode, GuaranteeMon, Quantity, Price)
        {
            this.HeadphonesID = HeadphonesID;
            this.ConnectionType = ConnectionType;
            this.FrequencyRange = FrequencyRange;
            this.SensitivitydB = SensitivitydB;
            this.Jack = Jack;
            this.MicrophoneSensitivity = MicrophoneSensitivity;
            this.Weight = Weight;
        }
    }

}
