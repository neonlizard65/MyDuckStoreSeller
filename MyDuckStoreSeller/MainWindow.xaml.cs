
using MyDuckStoreSeller.Classes;
using MyDuckStoreSeller.Classes.FormProduct;
using MyDuckStoreSeller.Classes.Instances;
using MyDuckStoreSeller.Classes.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyDuckStoreSeller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Seller seller;
        List<Product> allproducts = new List<Product>();
        List<Instance> allinstances = new List<Instance>();
        Dictionary<Instance, Product> sellerproducts = new Dictionary<Instance, Product>();

        SsdProducts AllSsds;
        AircoolerProducts AllAircoolers;
        CpuProducts AllCpus;
        HddProducts AllHdds;
        HeadphonesProducts AllHeadphones;
        KeyboardProducts AllKeyboards;
        MonitorProducts AllMonitors;
        MotherboardProducts AllMotherboards;
        MouseProducts AllMouses;
        PsuProducts AllPsus;
        RamProducts AllRams;
        TowerProducts AllTowers;
        UsbflashProducts AllUsbs;
        VideocardProducts AllVideocards;
        WatercoolerProducts AllWatercoolers;

        public MainWindow(Seller s)
        {
            InitializeComponent();
            seller = s;
            //Приветствие
            string[] sellerNameArray = seller.SellerName.Split(' ');
            string FirstName = sellerNameArray[1];
            if (DateTime.Now.Hour >= 23 || DateTime.Now.Hour < 5) 
            {
                WelcomeText.Text = $"Доброй ночи, {FirstName}!";
            }
            else if (DateTime.Now.Hour >= 5 && DateTime.Now.Hour < 12)
            {
                WelcomeText.Text = $"Доброе утро, {FirstName}!";
            }
            else if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 18)
            {
                WelcomeText.Text = $"Добрый день, {FirstName}!";
            }
            else if (DateTime.Now.Hour >= 18 && DateTime.Now.Hour < 23)
            {
                WelcomeText.Text = $"Добрый вечер, {FirstName}!";
            }

            //Заполнение товаров продавца
            AllProductsFill();
            AllInstancesFill();

            foreach (var x in allproducts)
            {
                if (x is Ssd)
                {
                    foreach(var ins in allinstances)
                    {
                        if (ins is SsdInstance && (ins as SsdInstance).SsdId == (x as Ssd).SsdID)
                        {
                            sellerproducts.Add(ins, x);
                        }
                    }
                }
                if (x is Aircooler)
                {
                    foreach (var ins in allinstances)
                    {
                        if (ins is AircoolerInstance && (ins as AircoolerInstance).AircoolerId == (x as Aircooler).AircoolerID)
                        {
                            sellerproducts.Add(ins, x);
                        }
                    }
                }
                if (x is Cpu)
                {
                    foreach (var ins in allinstances)
                    {
                        if (ins is CpuInstance && (ins as CpuInstance).CpuId == (x as Cpu).CpuID)
                        {
                            sellerproducts.Add(ins, x);
                        }
                    }
                }
                if (x is Hdd)
                {
                    foreach (var ins in allinstances)
                    {
                        if (ins is HddInstance && (ins as HddInstance).HddId == (x as Hdd).HddID)
                        {
                            sellerproducts.Add(ins, x);
                        }
                    }
                }
                if (x is Headphones)
                {
                    foreach (var ins in allinstances)
                    {
                        if (ins is HeadphonesInstance && (ins as HeadphonesInstance).HeadphonesId == (x as Headphones).HeadphonesID)
                        {
                            sellerproducts.Add(ins, x);
                        }
                    }
                }
                if (x is MyDuckStoreSeller.Classes.Products.Keyboard)
                {
                    foreach (var ins in allinstances)
                    {
                        if (ins is KeyboardInstance && (ins as KeyboardInstance).KeyboardId == (x as MyDuckStoreSeller.Classes.Products.Keyboard).KeyboardID)
                        {
                            sellerproducts.Add(ins, x);
                        }
                    }
                }
                if (x is Monitor)
                {
                    foreach (var ins in allinstances)
                    {
                        if (ins is MonitorInstance && (ins as MonitorInstance).MonitorId == (x as Monitor).MonitorID)
                        {
                            sellerproducts.Add(ins, x);
                        }
                    }
                }
                if (x is Motherboard)
                {
                    foreach (var ins in allinstances)
                    {
                        if (ins is MotherboardInstance && (ins as MotherboardInstance).MotherboardId == (x as Motherboard).MotherboardID)
                        {
                            sellerproducts.Add(ins, x);
                        }
                    }
                }
                if (x is MyDuckStoreSeller.Classes.Products.Mouse)
                {
                    foreach (var ins in allinstances)
                    {
                        if (ins is MouseInstance && (ins as MouseInstance).MouseId == (x as MyDuckStoreSeller.Classes.Products.Mouse).MouseID)
                        {
                            sellerproducts.Add(ins, x);
                        }
                    }
                }
                if (x is Psu)
                {
                    foreach (var ins in allinstances)
                    {
                        if (ins is PsuInstance && (ins as PsuInstance).PsuId == (x as Psu).PsuID)
                        {
                            sellerproducts.Add(ins, x);
                        }
                    }
                }
                if (x is Ram)
                {
                    foreach (var ins in allinstances)
                    {
                        if (ins is RamInstance && (ins as RamInstance).RamId == (x as Ram).RamID)
                        {
                            sellerproducts.Add(ins, x);
                        }
                    }
                }
                if (x is Tower)
                {
                    foreach (var ins in allinstances)
                    {
                        if (ins is TowerInstance && (ins as TowerInstance).TowerId == (x as Tower).TowerID)
                        {
                            sellerproducts.Add(ins, x);
                        }
                    }
                }
                if (x is Usbflash)
                {
                    foreach (var ins in allinstances)
                    {
                        if (ins is UsbFlashInstance && (ins as UsbFlashInstance).UsbFlashId == (x as Usbflash).UsbFlashID)
                        {
                            sellerproducts.Add(ins, x);
                        }
                    }
                }
                if (x is Videocard)
                {
                    foreach (var ins in allinstances)
                    {
                        if (ins is VideocardInstance && (ins as VideocardInstance).VideocardId == (x as Videocard).VideocardID)
                        {
                            sellerproducts.Add(ins, x);
                        }
                    }
                }
                if (x is Watercooler)
                {
                    foreach (var ins in allinstances)
                    {
                        if (ins is WatercoolerInstance && (ins as WatercoolerInstance).WatercoolerId == (x as Watercooler).WatercoolerID)
                        {
                            sellerproducts.Add(ins, x);
                        }
                    }
                }
            }



            ListViewProducts.ItemsSource = sellerproducts;


        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //(tabControl1.SelectedItem as TabItem).Background = new SolidColorBrush(Color.FromRgb(112, 21, 31));

            if(CloseTab.IsSelected == true)
            {
                Application.Current.Shutdown();
            }
        }

        private void AllProductsFill()
        {
            //Заполнение товаров продавца

            AllSsds = JsonSerializer.Deserialize<SsdProducts>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/products/ssd/read.php"));
            AllAircoolers = JsonSerializer.Deserialize<AircoolerProducts>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/products/aircooler/read.php"));
            AllCpus = JsonSerializer.Deserialize<CpuProducts>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/products/cpu/read.php"));
            AllHdds = JsonSerializer.Deserialize<HddProducts>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/products/hdd/read.php"));
            AllHeadphones = JsonSerializer.Deserialize<HeadphonesProducts>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/products/headphones/read.php"));
            AllKeyboards = JsonSerializer.Deserialize<KeyboardProducts>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/products/keyboard/read.php"));
            AllMonitors = JsonSerializer.Deserialize<MonitorProducts>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/products/monitor/read.php"));
            AllMotherboards = JsonSerializer.Deserialize<MotherboardProducts>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/products/motherboard/read.php"));
            AllMouses = JsonSerializer.Deserialize<MouseProducts>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/products/mouse/read.php"));
            AllPsus = JsonSerializer.Deserialize<PsuProducts>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/products/psu/read.php"));
            AllRams = JsonSerializer.Deserialize<RamProducts>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/products/ram/read.php"));
            AllTowers = JsonSerializer.Deserialize<TowerProducts>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/products/tower/read.php"));
            AllUsbs = JsonSerializer.Deserialize<UsbflashProducts>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/products/usbflash/read.php"));
            AllVideocards = JsonSerializer.Deserialize<VideocardProducts>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/products/videocard/read.php"));
            AllWatercoolers = JsonSerializer.Deserialize<WatercoolerProducts>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/products/watercooler/read.php"));

            foreach (var x in AllSsds.ssd)
                allproducts.Add(x);
            foreach (var x in AllAircoolers.aircooler)
                allproducts.Add(x);
            foreach (var x in AllCpus.cpu)
                allproducts.Add(x);
            foreach (var x in AllHdds.hdd)
                allproducts.Add(x);
            foreach (var x in AllHeadphones.headphones)
                allproducts.Add(x);
            foreach (var x in AllKeyboards.keyboard)
                allproducts.Add(x);
            foreach (var x in AllMonitors.monitor)
                allproducts.Add(x);
            foreach (var x in AllMotherboards.motherboard)
                allproducts.Add(x);
            foreach (var x in AllMouses.mouse)
                allproducts.Add(x);
            foreach (var x in AllPsus.psu)
                allproducts.Add(x);
            foreach (var x in AllRams.ram)
                allproducts.Add(x);
            foreach (var x in AllTowers.tower)
                allproducts.Add(x);
            foreach (var x in AllUsbs.usbflash)
                allproducts.Add(x);
            foreach (var x in AllVideocards.videocard)
                allproducts.Add(x);
            foreach (var x in AllWatercoolers.watercooler)
                allproducts.Add(x);
        }
        private void AllInstancesFill()
        {
            try
            {
                var AllSsdInstances = JsonSerializer.Deserialize<SsdInstanceList>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/instances/ssdinstance/read_one.php?SellerId=" + seller.SellerID));
                foreach (var x in AllSsdInstances.ssdinstance)
                    allinstances.Add(x);
            }
            catch
            {

            }
            try
            {
                var AllAircoolerInstances = JsonSerializer.Deserialize<AircoolerInstanceList>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/instances/aircoolerinstance/read_one.php?SellerId=" + seller.SellerID));
                foreach (var x in AllAircoolerInstances.aircoolerinstance)
                    allinstances.Add(x);
            }
            catch
            {

            }
            try
            {
                var AllHddInstances = JsonSerializer.Deserialize<HddInstanceList>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/instances/hddinstance/read_one.php?SellerId=" + seller.SellerID));
                foreach (var x in AllHddInstances.Hddinstance)
                    allinstances.Add(x);
            }
            catch
            {

            }
            try
            {
                var AllHeadphonesInstances = JsonSerializer.Deserialize<HeadphonesInstanceList>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/instances/headphonesinstance/read_one.php?SellerId=" + seller.SellerID));
                foreach (var x in AllHeadphonesInstances.Headphonesinstance)
                    allinstances.Add(x);
            }
            catch
            {

            }
            try
            {
                var AllKeyboardInstances = JsonSerializer.Deserialize<KeyboardInstanceList>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/instances/keyboardinstance/read_one.php?SellerId=" + seller.SellerID));
                foreach (var x in AllKeyboardInstances.Keyboardinstance)
                    allinstances.Add(x);
            }
            catch
            {

            }
            try
            {
                var AllMonitorInstances = JsonSerializer.Deserialize<MonitorInstanceList>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/instances/monitorinstance/read_one.php?SellerId=" + seller.SellerID));
                foreach (var x in AllMonitorInstances.Monitorinstance)
                    allinstances.Add(x);
            }
            catch
            {

            }
            try
            {
                var AllMotherboardInstances = JsonSerializer.Deserialize<MotherboardInstanceList>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/instances/motherboardinstance/read_one.php?SellerId=" + seller.SellerID));
                foreach (var x in AllMotherboardInstances.Motherboardinstance)
                    allinstances.Add(x);
            }
            catch
            {

            }
            try
            {
                var AllMouseInstances = JsonSerializer.Deserialize<MouseInstanceList>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/instances/mouseinstance/read_one.php?SellerId=" + seller.SellerID));
                foreach (var x in AllMouseInstances.Mouseinstance)
                    allinstances.Add(x);
            }
            catch
            {

            }
            try
            {
                var AllPsuInstances = JsonSerializer.Deserialize<PsuInstanceList>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/instances/psuinstance/read_one.php?SellerId=" + seller.SellerID));
                foreach (var x in AllPsuInstances.Psuinstance)
                    allinstances.Add(x);
            }
            catch
            {

            }
            try
            {
                var AllRamInstances = JsonSerializer.Deserialize<RamInstanceList>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/instances/raminstance/read_one.php?SellerId=" + seller.SellerID));
                foreach (var x in AllRamInstances.Raminstance)
                    allinstances.Add(x);
            }
            catch
            {

            }
            try
            {
                var AllTowerInstances = JsonSerializer.Deserialize<TowerInstanceList>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/instances/towerinstance/read_one.php?SellerId=" + seller.SellerID));
                foreach (var x in AllTowerInstances.Towerinstance)
                    allinstances.Add(x);
            }
            catch
            {

            }
            try
            {
                var AllUsbFlashInstances = JsonSerializer.Deserialize<UsbFlashInstanceList>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/instances/usbflashinstance/read_one.php?SellerId=" + seller.SellerID));
                foreach (var x in AllUsbFlashInstances.UsbFlashinstance)
                    allinstances.Add(x);
            }
            catch
            {

            }
            try
            {
                var AllVideocardInstances = JsonSerializer.Deserialize<VideocardInstanceList>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/instances/videocardinstance/read_one.php?SellerId=" + seller.SellerID)); 
                foreach (var x in AllVideocardInstances.Videocardinstance)
                    allinstances.Add(x);
            }
            catch
            {

            }
            try
            {
                var AllWatercoolerInstances = JsonSerializer.Deserialize<WatercoolerInstanceList>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/instances/watercoolerinstance/read_one.php?SellerId=" + seller.SellerID));
                foreach (var x in AllWatercoolerInstances.Watercoolerinstance)
                    allinstances.Add(x);
            }
            catch
            {

            }
        }

        private void ListViewProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var element = (KeyValuePair<Instance, Product>)(sender as ListView).SelectedValue;
            if (element.Value is Ssd)
            {
                AddEditWindow addeditForm = new AddEditWindow("UpdateInstance", element, ref allproducts);
                addeditForm.Show();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow addeditForm = new AddEditWindow("CreateInstance", new KeyValuePair<Instance, Product>(), ref allproducts);
            addeditForm.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddEditWindow addeditForm = new AddEditWindow("CreateProduct", new KeyValuePair<Instance, Product>(), ref allproducts);
            addeditForm.Show();
        }
    }
}
