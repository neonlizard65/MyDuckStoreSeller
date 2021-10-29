using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Products
{
    public class MotherboardProducts
    {
        public List<Motherboard> motherboard { get; set; }
    }

    public class Motherboard : Product
    {
        public string MotherboardID { get; set; }
        public string Socket { get; set; }
        public string Chipset { get; set; }
        public string RamSlots { get; set; }
        public string SataControllers { get; set; }
        public string RaidSupport { get; set; }
        public string ExpansionSlots { get; set; }
        public string IntegratedVideo { get; set; }
        public string Sound { get; set; }
        public string AudioController { get; set; }
        public string NetInterface { get; set; }
        public string NetController { get; set; }
        public string Interfaces { get; set; }
        public string FormFactor { get; set; }
        public Motherboard(string MotherboardID, string ArticulId, string ManufacturerId, string ManufacturerName, string ManufacturerSite, string ManufacturerImagePath, string Name,
       string ImagePath, string ManufacturerCode, string Socket, string Chipset, string RamSlots,
       string SataControllers, string RaidSupport, string ExpansionSlots, string IntegratedVideo, string Sound, string AudioController, string NetInterface,
       string NetController, string Interfaces, string FormFactor, string GuaranteeMon)
       : base(ArticulId, ManufacturerId, ManufacturerName, ManufacturerSite, ManufacturerImagePath, Name, ImagePath, ManufacturerCode, GuaranteeMon)
        {
            this.MotherboardID = MotherboardID;
            this.Socket = Socket;
            this.Chipset = Chipset;
            this.RamSlots = RamSlots;
            this.SataControllers = SataControllers;
            this.RaidSupport = RaidSupport;
            this.ExpansionSlots = ExpansionSlots;
            this.IntegratedVideo = IntegratedVideo;
            this.Sound = Sound;
            this.AudioController = AudioController;
            this.NetInterface = NetInterface;
            this.NetController = NetController;
            this.Interfaces = Interfaces;
            this.FormFactor = FormFactor;
        }
    }
}
