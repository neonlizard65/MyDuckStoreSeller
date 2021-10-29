using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Products
{
    public class MouseProducts
    {
        public List<Mouse> mouse { get; set; }
    }

    public class Mouse : Product
    {
        public string MouseID { get; set; }
        public string ConnectionMedium { get; set; }
        public string ConnectionInterface { get; set; }
        public string Sensor { get; set; }
        public string HandDesign { get; set; }
        public string DPI { get; set; }
        public string ButtonQty { get; set; }
        public Mouse(string MouseID, string ArticulId, string ManufacturerId, string ManufacturerName, string ManufacturerSite, string ManufacturerImagePath, string Name,
    string ImagePath, string ManufacturerCode, string ConnectionMedium, string ConnectionInterface, string Sensor,
    string HandDesign, string DPI, string ButtonQty, string GuaranteeMon)
    : base(ArticulId, ManufacturerId, ManufacturerName, ManufacturerSite, ManufacturerImagePath, Name, ImagePath, ManufacturerCode, GuaranteeMon)
        {
            this.MouseID = MouseID;
            this.ConnectionMedium = ConnectionMedium;
            this.ConnectionInterface = ConnectionInterface;
            this.Sensor = Sensor;
            this.HandDesign = HandDesign;
            this.DPI = DPI;
            this.ButtonQty = ButtonQty;
        }
    }
}
