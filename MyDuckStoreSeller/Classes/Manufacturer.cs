using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes
{

    public class ManufacturerList
    {
        public List<Manufacturer> manufacturer { get; set; }
    }

    public class Manufacturer
    {
        public string ManufacturerID { get; set; }
        public string ManufacturerName { get; set; }
        public string ManufacturerSite { get; set; }
        public string ManufacturerImagePath { get; set; }

        public Manufacturer(string ManufacturerID, string ManufacturerName, string ManufacturerSite, string ManufacturerImagePath)
        {
            this.ManufacturerID = ManufacturerID;
            this.ManufacturerName = ManufacturerName;
            this.ManufacturerSite = ManufacturerSite;
            this.ManufacturerImagePath = ManufacturerImagePath;
        }
    }

}
