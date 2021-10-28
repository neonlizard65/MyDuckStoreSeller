using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Products
{
    public class RamProducts
    {
        public List<Ram> ram { get; set; }

  
    }
    public class Ram : Product
    {
        public string RamID { get; set; }
        public string FormFactor { get; set; }
        public string MemoryType { get; set; }
        public string MemoryVolumeGB { get; set; }
        public string ClockSpeed { get; set; }
        public string SpeedMB { get; set; }
        public string CAS { get; set; }
        public string RAStoCAS { get; set; }
        public string RowPrecharge { get; set; }

        public Ram(string RamID, string ArticulId, string ManufacturerId, string ManufacturerName, string ManufacturerSite, string ManufacturerImagePath, string Name,
        string ImagePath, string ManufacturerCode, string FormFactor, string MemoryType, string MemoryVolumeGB,
        string ClockSpeed, string SpeedMB, string CAS, string RAStoCAS, string RowPrecharge, string GuaranteeMon, string Quantity, string Price)
        : base(ArticulId, ManufacturerId, ManufacturerName, ManufacturerSite, ManufacturerImagePath, Name, ImagePath, ManufacturerCode, GuaranteeMon, Quantity, Price)
        {
            this.RamID = RamID;
            this.FormFactor = FormFactor;
            this.MemoryType = MemoryType;
            this.MemoryVolumeGB = MemoryVolumeGB;
            this.ClockSpeed = ClockSpeed;
            this.SpeedMB = SpeedMB;
            this.CAS = CAS;
            this.RAStoCAS = RAStoCAS;
            this.RowPrecharge = RowPrecharge;
        }
    }
}
