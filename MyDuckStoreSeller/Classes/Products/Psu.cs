using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Products
{
    public class PsuProducts
    {
        public List<Psu> psu { get; set; }
    }

    public class Psu : Product
    {
        public string PsuID { get; set; }
        public string Power { get; set; }
        public string Standart { get; set; }
        public string PFC { get; set; }
        public string FanSize { get; set; }
        public string MotherboardPins { get; set; }
        public string CpuPinQuantity { get; set; }
        public string PCIEPinQuantity { get; set; }
        public string IDEPinQuantity { get; set; }
        public string SataPinQuantity { get; set; }
        public string OverpressureProtection { get; set; }
        public string OverflowProtection { get; set; }
        public string ShortCircuitProtection { get; set; }
        public string Certificate80Plus { get; set; }
        public string Weight { get; set; }

        public Psu(string PsuID, string ArticulId, string ManufacturerId, string ManufacturerName, string ManufacturerSite, string ManufacturerImagePath, string Name,
    string ImagePath, string ManufacturerCode, string Power, string Standart, string PFC,
    string FanSize, string MotherboardPins, string CpuPinQuantity, string PCIEPinQuantity, string IDEPinQuantity, string SataPinQuantity, 
    string OverpressureProtection, string OverflowProtection, string ShortCircuitProtection, string Certificate80Plus, string Weight, string GuaranteeMon, string Quantity, string Price)
    : base(ArticulId, ManufacturerId, ManufacturerName, ManufacturerSite, ManufacturerImagePath, Name, ImagePath, ManufacturerCode, GuaranteeMon, Quantity, Price)
        {
            this.PsuID = PsuID;
            this.Power = Power;
            this.Standart = Standart;
            this.PFC = PFC;
            this.FanSize = FanSize;
            this.MotherboardPins = MotherboardPins;
            this.CpuPinQuantity = CpuPinQuantity;
            this.PCIEPinQuantity = PCIEPinQuantity;
            this.IDEPinQuantity = IDEPinQuantity;
            this.SataPinQuantity = SataPinQuantity;
            this.OverpressureProtection = OverpressureProtection;
            this.OverflowProtection = OverflowProtection;
            this.ShortCircuitProtection = ShortCircuitProtection;
            this.Certificate80Plus = Certificate80Plus;
            this.Weight = Weight;
        }
    }
}
