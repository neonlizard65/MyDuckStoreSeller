using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Products
{
    public class VideocardProducts
    {
        public List<Videocard> videocard { get; set; }
    }

    public class Videocard : Product
    {
        public string VideocardID { get; set; }
        public string Interface { get; set; }
        public string ProcessorManufacturer { get; set; }
        public string Series { get; set; }
        public string Nanometers { get; set; }
        public string ClockSpeed { get; set; }
        public string CountUniversalProcessor { get; set; }
        public string SLICrossfire { get; set; }
        public string DirectXSupport { get; set; }
        public string OpenGLSupport { get; set; }
        public string MemoryMB { get; set; }
        public string MemoryType { get; set; }
        public string Ports { get; set; }
        public string CountMonitorsSupport { get; set; }
        public string MaxResolution { get; set; }
        public string Pins { get; set; }
        public string Watt { get; set; }
        public string Dimensions { get; set; }
        public Videocard(string VideocardID, string ArticulId, string ManufacturerId, string ManufacturerName, string ManufacturerSite, string ManufacturerImagePath, string Name,
     string ImagePath, string ManufacturerCode, string Interface,
     string ProcessorManufacturer, string Series, string Nanometers, string ClockSpeed, string CountUniversalProcessor, string SLICrossfire, 
     string DirectXSupport, string OpenGLSupport, string MemoryMB, string MemoryType, string Ports, string CountMonitorsSupport, string MaxResolution, 
     string Pins, string Watt, string Dimensions, string GuaranteeMon)
     : base(ArticulId, ManufacturerId, ManufacturerName, ManufacturerSite, ManufacturerImagePath, Name, ImagePath, ManufacturerCode, GuaranteeMon)
        {
            this.VideocardID = VideocardID;
            this.Interface = Interface;
            this.ProcessorManufacturer = ProcessorManufacturer;
            this.Series = Series;
            this.Nanometers = Nanometers;
            this.ClockSpeed = ClockSpeed;
            this.CountUniversalProcessor = CountUniversalProcessor;
            this.SLICrossfire = SLICrossfire;
            this.DirectXSupport = DirectXSupport;
            this.OpenGLSupport = OpenGLSupport;
            this.MemoryMB = MemoryMB;
            this.MemoryType = MemoryType;
            this.Ports = Ports;
            this.CountMonitorsSupport = CountMonitorsSupport;
            this.MaxResolution = MaxResolution;
            this.Pins = Pins;
            this.Watt = Watt;
            this.Dimensions = Dimensions;

        }
    }
}