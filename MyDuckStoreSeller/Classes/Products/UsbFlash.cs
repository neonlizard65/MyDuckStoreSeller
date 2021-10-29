using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes.Products
{

    public class UsbflashProducts
    {
        public List<Usbflash> usbflash { get; set; }
    }

    public class Usbflash : Product
    {
        public string UsbFlashID { get; set; }
        public string VolumeGB { get; set; }
        public string Interface { get; set; }

        public Usbflash(string UsbFlashID, string ArticulId, string ManufacturerId, string ManufacturerName, string ManufacturerSite, string ManufacturerImagePath, string Name,
            string ImagePath, string ManufacturerCode, string VolumeGB, string Interface, string GuaranteeMon) : base(ArticulId, ManufacturerId, ManufacturerName, ManufacturerSite, ManufacturerImagePath, Name, ImagePath, ManufacturerCode, GuaranteeMon)
        {
            this.UsbFlashID = UsbFlashID;
            this.VolumeGB = VolumeGB;
            this.Interface = Interface;
        }
    }

}
