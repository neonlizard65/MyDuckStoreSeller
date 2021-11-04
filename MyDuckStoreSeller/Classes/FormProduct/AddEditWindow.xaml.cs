using MyDuckStoreSeller.Classes.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.Json;
using System.Net;
using MyDuckStoreSeller.Classes.Products;

namespace MyDuckStoreSeller.Classes.FormProduct
{
    /// <summary>
    /// Interaction logic for AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        List<string> CategoriesList = new List<string>() { "Кулер", "ЦПУ", "Жесткий диск", "Наушники", "Клавиатура", "Монитор", "Материнская плата",
            "Мышь", "Блок питания", "ОЗУ", "Накопитель SSD", "Корпус", "Накопитель USB", "Видеокарта", "Водяное охлаждение"};

        string Method;

        public AddEditWindow(string method, KeyValuePair<Instance, Product> product)
        {
            InitializeComponent();

            //Для глоб. переменных
            this.Method = method;

            //Категории
            CategoriesList.Sort();
            CategoriesComboBox.ItemsSource = CategoriesList;

            if (Method == "UpdateInstance")
            {
                CategoriesComboBox.IsEnabled = false;
                if (product.Value is Ssd)
                {
                    CategoriesComboBox.SelectedItem = "Накопитель SSD";
                    SsdInstanceUpdatePage ssdpage = new SsdInstanceUpdatePage(product);
                    ProductFrame.Navigate(ssdpage);
                }
                if (product.Value is Aircooler)
                {
                    CategoriesComboBox.SelectedItem = "Кулер";
                    AircoolerInstanceUpdatePage aircoolerpage = new AircoolerInstanceUpdatePage(product);
                    ProductFrame.Navigate(aircoolerpage);
                }
                if (product.Value is Cpu)
                {
                    CategoriesComboBox.SelectedItem = "ЦПУ";
                    CpuInstanceUpdatePage cpupage = new CpuInstanceUpdatePage(product);
                    ProductFrame.Navigate(cpupage);
                }
                if (product.Value is Hdd)
                {
                    CategoriesComboBox.SelectedItem = "Жесткий диск";
                    HddInstanceUpdatePage hddpage = new HddInstanceUpdatePage(product);
                    ProductFrame.Navigate(hddpage);
                }
                if (product.Value is Headphones)
                {
                    CategoriesComboBox.SelectedItem = "Наушники";
                    HeadphonesInstanceUpdatePage headphonespage = new HeadphonesInstanceUpdatePage(product);
                    ProductFrame.Navigate(headphonespage);
                }
                if (product.Value is MyDuckStoreSeller.Classes.Products.Keyboard)
                {
                    CategoriesComboBox.SelectedItem = "Клавиатура";
                    KeyboardInstanceUpdatePage keyboardpage = new KeyboardInstanceUpdatePage(product);
                    ProductFrame.Navigate(keyboardpage);
                }
                if (product.Value is Monitor)
                {
                    CategoriesComboBox.SelectedItem = "Монитор";
                    MonitorInstanceUpdatePage monitorpage = new MonitorInstanceUpdatePage(product);
                    ProductFrame.Navigate(monitorpage);
                }
                if (product.Value is Motherboard)
                {
                    CategoriesComboBox.SelectedItem = "Материнская плата";
                    MotherboardInstanceUpdatePage motherboardpage = new MotherboardInstanceUpdatePage(product);
                    ProductFrame.Navigate(motherboardpage);
                }
                if (product.Value is MyDuckStoreSeller.Classes.Products.Mouse)
                {
                    CategoriesComboBox.SelectedItem = "Мышь";
                    MouseInstanceUpdatePage mousepage = new MouseInstanceUpdatePage(product);
                    ProductFrame.Navigate(mousepage);
                }
                if (product.Value is Psu)
                {
                    CategoriesComboBox.SelectedItem = "Блок питания";
                    PsuInstanceUpdatePage Psupage = new PsuInstanceUpdatePage(product);
                    ProductFrame.Navigate(Psupage);
                }
                if (product.Value is Ram)
                {
                    CategoriesComboBox.SelectedItem = "ОЗУ";
                    RamInstanceUpdatePage Rampage = new RamInstanceUpdatePage(product);
                    ProductFrame.Navigate(Rampage);
                }
                if (product.Value is Tower)
                {
                    CategoriesComboBox.SelectedItem = "Корпус";
                    TowerInstanceUpdatePage Towerpage = new TowerInstanceUpdatePage(product);
                    ProductFrame.Navigate(Towerpage);
                }
                if (product.Value is Usbflash)
                {
                    CategoriesComboBox.SelectedItem = "Накопитель USB";
                    UsbFlashInstanceUpdatePage usbpage = new UsbFlashInstanceUpdatePage(product);
                    ProductFrame.Navigate(usbpage);
                }
                if (product.Value is Videocard)
                {
                    CategoriesComboBox.SelectedItem = "Видеокарта";
                    VideocardInstanceUpdatePage videopage = new VideocardInstanceUpdatePage(product);
                    ProductFrame.Navigate(videopage);
                }
                if (product.Value is Watercooler)
                {
                    CategoriesComboBox.SelectedItem = "Водяное охлаждение";
                    WatercoolerInstanceUpdatePage Watercoolerpage = new WatercoolerInstanceUpdatePage(product);
                    ProductFrame.Navigate(Watercoolerpage);
                }
            }
        }

        private void CategoriesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CategoriesComboBox.SelectedValue.ToString() == "Накопитель SSD")
            {
                if (Method == "CreateInstance")
                {
                    SsdInstanceCreatePage ssdpage = new SsdInstanceCreatePage();
                    ProductFrame.Navigate(ssdpage);
                }
                if (Method == "CreateProduct")
                {
                    SsdCreatePage ssdpage = new SsdCreatePage();
                    ProductFrame.Navigate(ssdpage);
                }
            }
            if (CategoriesComboBox.SelectedValue.ToString() == "Кулер")
            {
                if (Method == "CreateInstance")
                {
                    AircoolerInstanceCreatePage aircoolerpage = new AircoolerInstanceCreatePage();
                    ProductFrame.Navigate(aircoolerpage);
                }
                if (Method == "CreateProduct")
                {
                    AircoolerCreatePage aircoolerpage = new AircoolerCreatePage();
                    ProductFrame.Navigate(aircoolerpage);
                }
            }
            if (CategoriesComboBox.SelectedValue.ToString() == "ЦПУ")
            {
                if (Method == "CreateInstance")
                {
                    CpuInstanceCreatePage cpupage = new CpuInstanceCreatePage();
                    ProductFrame.Navigate(cpupage);
                }
                if (Method == "CreateProduct")
                {
                    CpuCreatePage cpupage = new CpuCreatePage();
                    ProductFrame.Navigate(cpupage);
                }
            }
            if (CategoriesComboBox.SelectedValue.ToString() == "Жесткий диск")
            {
                if (Method == "CreateInstance")
                {
                    HddInstanceCreatePage hddpage = new HddInstanceCreatePage();
                    ProductFrame.Navigate(hddpage);
                }
                if (Method == "CreateProduct")
                {
                    HddCreatePage hddpage = new HddCreatePage();
                    ProductFrame.Navigate(hddpage);
                }
            }
            if (CategoriesComboBox.SelectedValue.ToString() == "Наушники")
            {
                if (Method == "CreateInstance")
                {
                    HeadphonesInstanceCreatePage headphonespage = new HeadphonesInstanceCreatePage();
                    ProductFrame.Navigate(headphonespage);
                }
                if (Method == "CreateProduct")
                {
                    HeadphonesCreatePage headphonespage = new HeadphonesCreatePage();
                    ProductFrame.Navigate(headphonespage);
                }
            }
            if (CategoriesComboBox.SelectedValue.ToString() == "Клавиатура")
            {
                if (Method == "CreateInstance")
                {
                    KeyboardInstanceCreatePage keyboardpage = new KeyboardInstanceCreatePage();
                    ProductFrame.Navigate(keyboardpage);
                }
                if (Method == "CreateProduct")
                {
                    KeyboardCreatePage keyboardpage = new KeyboardCreatePage();
                    ProductFrame.Navigate(keyboardpage);
                }
            }
            if (CategoriesComboBox.SelectedValue.ToString() == "Монитор")
            {
                if (Method == "CreateInstance")
                {
                    MonitorInstanceCreatePage monitorpage = new MonitorInstanceCreatePage();
                    ProductFrame.Navigate(monitorpage);
                }
                if (Method == "CreateProduct")
                {
                    MonitorCreatePage monitorpage = new MonitorCreatePage();
                    ProductFrame.Navigate(monitorpage);
                }
            }
            if (CategoriesComboBox.SelectedValue.ToString() == "Материнская плата")
            {
                if (Method == "CreateInstance")
                {
                    MotherboardInstanceCreatePage motherboardpage = new MotherboardInstanceCreatePage();
                    ProductFrame.Navigate(motherboardpage);
                }
                if (Method == "CreateProduct")
                {
                    MotherboardCreatePage motherboardpage = new MotherboardCreatePage();
                    ProductFrame.Navigate(motherboardpage);
                }
            }
            if (CategoriesComboBox.SelectedValue.ToString() == "Мышь")
            {
                if (Method == "CreateInstance")
                {
                    MouseInstanceCreatePage mousepage = new MouseInstanceCreatePage();
                    ProductFrame.Navigate(mousepage);
                }
                if (Method == "CreateProduct")
                {
                    MouseCreatePage mousepage = new MouseCreatePage();
                    ProductFrame.Navigate(mousepage);
                }
            }
            if (CategoriesComboBox.SelectedValue.ToString() == "Блок питания")
            {
                if (Method == "CreateInstance")
                {
                    PsuInstanceCreatePage Psupage = new PsuInstanceCreatePage();
                    ProductFrame.Navigate(Psupage);
                }
                if (Method == "CreateProduct")
                {
                    PsuCreatePage Psupage = new PsuCreatePage();
                    ProductFrame.Navigate(Psupage);
                }
            }
            if (CategoriesComboBox.SelectedValue.ToString() == "ОЗУ")
            {
                if (Method == "CreateInstance")
                {
                    RamInstanceCreatePage Rampage = new RamInstanceCreatePage();
                    ProductFrame.Navigate(Rampage);
                }
                if (Method == "CreateProduct")
                {
                    RamCreatePage Rampage = new RamCreatePage();
                    ProductFrame.Navigate(Rampage);
                }
            }
            if (CategoriesComboBox.SelectedValue.ToString() == "Корпус")
            {
                if (Method == "CreateInstance")
                {
                   TowerInstanceCreatePage Towerpage = new TowerInstanceCreatePage();
                    ProductFrame.Navigate(Towerpage);
                }
                if (Method == "CreateProduct")
                {
                    TowerCreatePage Towerpage = new TowerCreatePage();
                    ProductFrame.Navigate(Towerpage);
                }
            }
            if (CategoriesComboBox.SelectedValue.ToString() == "Накопитель USB")
            {
                if (Method == "CreateInstance")
                {
                    UsbFlashInstanceCreatePage UsbFlashpage = new UsbFlashInstanceCreatePage();
                    ProductFrame.Navigate(UsbFlashpage);
                }
                if (Method == "CreateProduct")
                {
                    UsbFlashCreatePage UsbFlashpage = new UsbFlashCreatePage();
                    ProductFrame.Navigate(UsbFlashpage);
                }
            }
            if (CategoriesComboBox.SelectedValue.ToString() == "Видеокарта")
            {
                if (Method == "CreateInstance")
                {
                    VideocardInstanceCreatePage Videocardpage = new VideocardInstanceCreatePage();
                    ProductFrame.Navigate(Videocardpage);
                }
                if (Method == "CreateProduct")
                {
                    VideocardCreatePage Videocardpage = new VideocardCreatePage();
                    ProductFrame.Navigate(Videocardpage);
                }
            }
            if (CategoriesComboBox.SelectedValue.ToString() == "Водяное охлаждение")
            {
                if (Method == "CreateInstance")
                {
                    WatercoolerInstanceCreatePage Watercoolerpage = new WatercoolerInstanceCreatePage();
                    ProductFrame.Navigate(Watercoolerpage);
                }
                if (Method == "CreateProduct")
                {
                    WatercoolerCreatePage Watercoolerpage = new WatercoolerCreatePage();
                    ProductFrame.Navigate(Watercoolerpage);
                }
            }
        }
    }
}