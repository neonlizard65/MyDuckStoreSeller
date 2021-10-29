using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Products
{
    public class KeyboardProducts
    {
        public List<Keyboard> keyboard { get; set; }
    }

    public class Keyboard : Product
    {
        public string KeyboardID { get; set; }
        public string ConnectType { get; set; }
        public string Construction { get; set; }
        public string Type { get; set; }
        public string Numpad { get; set; }
        public string Weight { get; set; }

        public Keyboard(string KeyboardID, string ArticulId, string ManufacturerId, string ManufacturerName, string ManufacturerSite, string ManufacturerImagePath, string Name,
string ImagePath, string ManufacturerCode, string ConnectType, string Construction, string Type,
string Numpad, string Weight, string GuaranteeMon)
: base(ArticulId, ManufacturerId, ManufacturerName, ManufacturerSite, ManufacturerImagePath, Name, ImagePath, ManufacturerCode, GuaranteeMon)
        {
            this.KeyboardID = KeyboardID;
            this.ConnectType = ConnectType;
            this.Construction = Construction;
            this.Type = Type;
            this.Numpad = Numpad;
            this.Weight = Weight;
        }
    }
    
}
