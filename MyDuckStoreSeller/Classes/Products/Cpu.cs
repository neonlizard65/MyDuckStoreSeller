using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes
{
    public class CpuProducts
    {
        public List<Cpu> cpu { get; set; }
    }

    public class Cpu : Product
    {
        public string CpuID { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }
        public string Socket { get; set; }
        public string CoreType { get; set; }
        public string ThreadCount { get; set; }
        public string ClockRate { get; set; }
        public string CacheL1KB { get; set; }
        public string CacheL2KB { get; set; }
        public string CacheL3KB { get; set; }
        public string IntegratedGraphicsCore { get; set; }
        public string Videoprocessor { get; set; }
        public string Nanometers { get; set; }
        public string MaxWorkTempCels { get; set; }
        public string Watt { get; set; }
        public string SupplyType { get; set; }

        public Cpu(string CpuID, string ArticulId, string ManufacturerId, string ManufacturerName, string ManufacturerSite, string ManufacturerImagePath, string Name,
       string ImagePath, string ManufacturerCode, string Series, string Model, string Socket,
       string CoreType, string ThreadCount, string ClockRate, string CacheL1KB, string CacheL2KB, string CacheL3KB, string IntegratedGraphicsCore, string Videoprocessor, string Nanometers, string MaxWorkTempCels, string Watt, string SupplyType, string GuaranteeMon, string Quantity, string Price)
       : base(ArticulId, ManufacturerId, ManufacturerName, ManufacturerSite, ManufacturerImagePath, Name, ImagePath, ManufacturerCode, GuaranteeMon, Quantity, Price)
        {
            this.CpuID = CpuID;
            this.Series = Series;
            this.Model = Model;
            this.Socket = Socket;
            this.CoreType = CoreType;
            this.ThreadCount = ThreadCount;
            this.ClockRate = ClockRate;
            this.CacheL1KB = CacheL1KB;
            this.CacheL2KB = CacheL2KB;
            this.CacheL3KB = CacheL3KB;
            this.IntegratedGraphicsCore = IntegratedGraphicsCore;
            this.Videoprocessor = Videoprocessor;
            this.Nanometers = Nanometers;
            this.MaxWorkTempCels = MaxWorkTempCels;
            this.Watt = Watt;
            this.SupplyType = SupplyType;

        }
    }
}
