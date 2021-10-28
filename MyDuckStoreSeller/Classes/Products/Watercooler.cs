using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Products
{
    public class WatercoolerProducts
    {
        public List<Watercooler> watercooler { get; set; }
    }

    public class Watercooler : Product
    {
        public string WatercoolerID { get; set; }
        public string Socket { get; set; }
        public string RadiatorMaterial { get; set; }
        public string FanQty { get; set; }
        public string Dimensions { get; set; }
        public string Speed { get; set; }
        public string VolumedB { get; set; }
        public string CFM { get; set; }
        public string WaterblockMaterial { get; set; }
        public string Weight { get; set; }

        public Watercooler(string WatercoolerID, string ArticulId, string ManufacturerId, string ManufacturerName, string ManufacturerSite, string ManufacturerImagePath, string Name,
    string ImagePath, string ManufacturerCode, string Socket, string RadiatorMaterial, string FanQty,
    string Dimensions, string Speed, string VolumedB, string CFM, string WaterblockMaterial, string Weight, string GuaranteeMon, string Quantity, string Price)
    : base(ArticulId, ManufacturerId, ManufacturerName, ManufacturerSite, ManufacturerImagePath, Name, ImagePath, ManufacturerCode, GuaranteeMon, Quantity, Price)
        {
            this.WatercoolerID = WatercoolerID;
            this.Socket = Socket;
            this.RadiatorMaterial = RadiatorMaterial;
            this.FanQty = FanQty;
            this.Dimensions = Dimensions;
            this.Speed = Speed;
            this.VolumedB = VolumedB;
            this.CFM = CFM;
            this.WaterblockMaterial = WaterblockMaterial;
            this.Weight = Weight;
        }
    }
}
