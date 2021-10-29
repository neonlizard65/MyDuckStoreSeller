using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Products
{
    public class TowerProducts
    {
        public List<Tower> tower { get; set; }
    }

    public class Tower : Product
    {
        public string TowerID { get; set; }
        public string Size { get; set; }
        public string FormFactor { get; set; }
        public string BPIncluded { get; set; }
        public string BPLocation { get; set; }
        public string TowerMaterial { get; set; }
        public string SideWindow { get; set; }
        public string WindowMaterial { get; set; }
        public string Slot2p5Qty { get; set; }
        public string Slot3p5Qty { get; set; }
        public string ExpansionSlots { get; set; }
        public string HDDPlacement { get; set; }
        public string MaxVideocardLength { get; set; }
        public string MaxCoolerHeight { get; set; }
        public string InterfacesFront { get; set; }
        public string Fans { get; set; }
        public string Dimensions { get; set; }
        public string Weight { get; set; }

        public Tower(string TowerID, string ArticulId, string ManufacturerId, string ManufacturerName, string ManufacturerSite, string ManufacturerImagePath, string Name,
    string ImagePath, string ManufacturerCode, string Size, string FormFactor, string BPIncluded,
    string BPLocation, string TowerMaterial, string SideWindow, string WindowMaterial, string Slot2p5Qty, string Slot3p5Qty, string ExpansionSlots, string HDDPlacement,
    string MaxVideocardLength, string MaxCoolerHeight, string InterfacesFront, string Fans, string Dimensions, string Weight, 
    string GuaranteeMon)
    : base(ArticulId, ManufacturerId, ManufacturerName, ManufacturerSite, ManufacturerImagePath, Name, ImagePath, ManufacturerCode, GuaranteeMon)
        {
            this.TowerID = TowerID;
            this.Size = Size;
            this.FormFactor = FormFactor;
            this.BPIncluded = BPIncluded;
            this.BPLocation = BPLocation;
            this.TowerMaterial = TowerMaterial;
            this.SideWindow = SideWindow;
            this.Slot2p5Qty = Slot2p5Qty;
            this.Slot3p5Qty = Slot3p5Qty;
            this.HDDPlacement = HDDPlacement;
            this.WindowMaterial = WindowMaterial;
            this.MaxVideocardLength = MaxVideocardLength;
            this.MaxCoolerHeight = MaxCoolerHeight;
            this.InterfacesFront = InterfacesFront;
            this.Fans = Fans;
            this.Dimensions = Dimensions;
            this.Weight = Weight;
        }
    }
}
