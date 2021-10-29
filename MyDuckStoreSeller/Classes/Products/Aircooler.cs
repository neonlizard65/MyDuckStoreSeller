using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Products
{
    public class AircoolerProducts
    {
        public List<Aircooler> aircooler { get; set; }
    }

    public class Aircooler : Product
    {
        public string AircoolerID { get; set; }
        public string Socket { get; set; }
        public string ThermalTubes { get; set; }
        public string RadiatorMaterial { get; set; }
        public string BaseMaterial { get; set; }
        public string FansQty { get; set; }
        public string Dimensions { get; set; }
        public string Speed { get; set; }
        public string VolumedB { get; set; }
        public string CFM { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }

        public Aircooler(string AircoolerID, string ArticulId, string ManufacturerId, string ManufacturerName, string ManufacturerSite, string ManufacturerImagePath, string Name,
             string ImagePath, string ManufacturerCode, string Socket, string ThermalTubes, string RadiatorMaterial,
             string BaseMaterial, string FansQty, string Dimensions, string Speed, string VolumedB, string CFM, string Weight, string Height, string GuaranteeMon)
             : base(ArticulId, ManufacturerId, ManufacturerName, ManufacturerSite, ManufacturerImagePath, Name, ImagePath, ManufacturerCode, GuaranteeMon)
        {
            this.AircoolerID = AircoolerID;
            this.Socket = Socket;
            this.ThermalTubes = ThermalTubes;
            this.RadiatorMaterial = RadiatorMaterial;
            this.BaseMaterial = BaseMaterial;
            this.FansQty = FansQty;
            this.Dimensions = Dimensions;
            this.Speed = Speed;
            this.VolumedB = VolumedB;
            this.CFM = CFM;
            this.Weight = Weight;
            this.Height = Height;
        }
    }
}
