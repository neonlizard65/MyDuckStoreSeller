using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Products
{

    public class MonitorProducts
    {
        public List<Monitor> monitor { get; set; }
    }

    public class Monitor : Product
    {
        public string MonitorID { get; set; }
        public string Diagonal { get; set; }
        public string Matrix { get; set; }
        public string LED { get; set; }
        public string WideFormat { get; set; }
        public string UltrawideFormat { get; set; }
        public string Resolution { get; set; }
        public string Brightness { get; set; }
        public string Contrast { get; set; }
        public string MsDelay { get; set; }
        public string HorizontalFOV { get; set; }
        public string VerticalFOV { get; set; }
        public string MaxColorQty { get; set; }
        public string Hertz { get; set; }
        public string HeightRegulation { get; set; }
        public string WallMount { get; set; }
        public string Rotate90 { get; set; }
        public string Interface { get; set; }
        public string USBHub { get; set; }
        public string PowerSupply { get; set; }
        public string VoltageWorking { get; set; }
        public string VoltageIdle { get; set; }
        public string Color { get; set; }
        public string Dimensions { get; set; }
        public string Weight { get; set; }

        public Monitor(string MonitorID, string ArticulId, string ManufacturerId, string ManufacturerName, string ManufacturerSite, string ManufacturerImagePath, string Name,
string ImagePath, string ManufacturerCode, string Diagonal, string Matrix, string LED,
string WideFormat, string UltrawideFormat, string Resolution, string Brightness, string Contrast, string MsDelay, string HorizontalFOV, string VerticalFOV,
string MaxColorQty, string Hertz, string HeightRegulation, string WallMount, string Rotate90, string Interface, string USBHub, string PowerSupply, string VoltageWorking,
string VoltageIdle, string Color, string Dimensions, string Weight, string GuaranteeMon, string Quantity, string Price)
: base(ArticulId, ManufacturerId, ManufacturerName, ManufacturerSite, ManufacturerImagePath, Name, ImagePath, ManufacturerCode, GuaranteeMon, Quantity, Price)
        {
            this.MonitorID = MonitorID;
            this.Diagonal = Diagonal;
            this.Matrix = Matrix;
            this.LED = LED;
            this.WideFormat = WideFormat;
            this.UltrawideFormat = UltrawideFormat;
            this.Resolution = Resolution;
            this.Brightness = Brightness;
            this.Contrast = Contrast;
            this.MsDelay = MsDelay;
            this.HorizontalFOV = HorizontalFOV;
            this.VerticalFOV = VerticalFOV;
            this.MaxColorQty = MaxColorQty;
            this.Hertz = Hertz;
            this.HeightRegulation = HeightRegulation;
            this.WallMount = WallMount;
            this.Rotate90 = Rotate90;
            this.Interface = Interface;
            this.USBHub = USBHub;
            this.PowerSupply = PowerSupply;
            this.VoltageWorking = VoltageWorking;
            this.VoltageIdle = VoltageIdle;
            this.Color = Color;
            this.Dimensions = Dimensions;
            this.Weight = Weight;
        }
    }
}
