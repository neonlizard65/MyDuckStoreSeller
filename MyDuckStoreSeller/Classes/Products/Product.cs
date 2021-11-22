using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes
{
    public class Product
    {
        public string ArticulId { get; set; }
        public string ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public string ManufacturerSite { get; set; }
        public string ManufacturerImagePath { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string ManufacturerCode { get; set; }
        public string GuaranteeMon { get; set; }
        public Product(string ArticulId, string ManufacturerId, string ManufacturerName, string ManufacturerSite, string ManufacturerImagePath, string Name,
            string ImagePath, string ManufacturerCode, string GuaranteeMon)
        {
            this.ArticulId = ArticulId;
            this.ManufacturerId = ManufacturerId;
            this.ManufacturerName = ManufacturerName;
            this.ManufacturerSite = ManufacturerSite;
            this.ManufacturerImagePath = ManufacturerImagePath;
            this.Name = Name.Replace("&quot;", "\"");
            this.ImagePath = ImagePath;
            this.ManufacturerCode = ManufacturerCode;
            this.GuaranteeMon = GuaranteeMon;
        }
    }
}
