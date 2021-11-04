using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Text.Json;
using MyDuckStoreSeller.Classes.Products;

namespace MyDuckStoreSeller.Classes.FormProduct
{
    /// <summary>
    /// Interaction logic for PsuCreatePage.xaml
    /// </summary>
    public partial class PsuCreatePage : Page
    {
        MyDuckStoreSeller.Classes.Products.Psu newPsu;
        public static string imageurl { get; set; }
        List<string> manufacturers = new List<string>();
        string imagebase64;
        public PsuCreatePage()
        {
            InitializeComponent();
            manufacturers = MainWindow.manufacturers.manufacturer.Select(m => m.ManufacturerName).ToList();
            manufacturers.Sort();
            manufacturers.Insert(0, "Добавить нового производителя...");
            ManufacturerBox.ItemsSource = manufacturers;
            PFCBox.ItemsSource = new List<string>() { "Активный", "Пассивный", "Нет" };
            CertificateBox.ItemsSource = new List<string>() { "Нет", "Certified", "Standart", "Bronze", "Silver", "Gold", "Platinum", "Titanium"};
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.allproducts.Clear();
            MainWindow.AllProductsFill();
            if (!String.IsNullOrWhiteSpace(ManufacturerCodeBox.Text))
            {
                if (!MainWindow.allproducts.Select(p => p.ManufacturerCode).Contains(ManufacturerCodeBox.Text)) 
                {
                    try
                    {
                        //диалоговое окно для импорта
                        OpenFileDialog open = new OpenFileDialog();
                        open.Filter = "Изображения (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";

                        var result = open.ShowDialog();

                        if (result == true)
                        {
                            MainWindow.AllProductsFill();

                            Byte[] imagebytes = File.ReadAllBytes(open.FileName);
                            ProductImage.Source = new BitmapImage(new Uri(open.FileName));
                            imagebase64 = Convert.ToBase64String(imagebytes);

                            MessageBox.Show("Изображение загружено.");

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Ошибка");
                    }
                }
                else
                {
                    MessageBox.Show("Данный код производителя уже существует. Возможно этот товар уже добавлен.", "Внимание");
                }
            }
            else
            {
                MessageBox.Show("Введите код производителя до добавления фото", "Внимание");
            }
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {

            if (!String.IsNullOrWhiteSpace(NameBox.Text) && !String.IsNullOrWhiteSpace(ManufacturerBox.SelectedValue.ToString()) &&
                !String.IsNullOrWhiteSpace(ManufacturerCodeBox.Text) && !String.IsNullOrWhiteSpace(PowerBox.Text) &&
                !String.IsNullOrWhiteSpace(StandartBox.Text) && !String.IsNullOrWhiteSpace(PFCBox.SelectedValue.ToString()) && !String.IsNullOrWhiteSpace(FanSizeBox.Text) &&
                !String.IsNullOrWhiteSpace(MotherboardPinsBox.Text) && !String.IsNullOrWhiteSpace(CpuPinQtyBox.Text) && 
                !String.IsNullOrWhiteSpace(PciPinQtyBox.Text) && !String.IsNullOrWhiteSpace(SataPinQtyBox.Text) && !String.IsNullOrWhiteSpace(IDEPinQtyBox.Text) &&
                !String.IsNullOrWhiteSpace(Convert.ToInt32(OverpressureBox.IsChecked).ToString()) && !String.IsNullOrWhiteSpace(Convert.ToInt32(OverFlowBox.IsChecked).ToString()) && !String.IsNullOrWhiteSpace(Convert.ToInt32(ShortCircuitBox.IsChecked).ToString()) &&
                !String.IsNullOrWhiteSpace(CertificateBox.SelectedValue.ToString()) && !String.IsNullOrWhiteSpace(WeightBox.Text)
                && !String.IsNullOrWhiteSpace(GuaranteeBox.Text))
            {
                MainWindow.allproducts.Clear();
                MainWindow.AllProductsFill();
                if (!MainWindow.allproducts.Select(p => p.ManufacturerCode).Contains(ManufacturerCodeBox.Text))
                {
                    if (ManufacturerBox.SelectedValue.ToString() != "Добавить нового производителя...")
                    {
                        imageurl = "https://myduckstudios.fvds.ru/photos/" + ManufacturerCodeBox.Text + "_1.png";
                        string Name = NameBox.Text;
                        string ManufacturerId = MainWindow.manufacturers.manufacturer.First(m => m.ManufacturerName == ManufacturerBox.SelectedValue.ToString()).ManufacturerID;
                        string ImagePath = imageurl;
                        string ManufacturerCode = ManufacturerCodeBox.Text;
                        string Power = PowerBox.Text;
                        string Standart = StandartBox.Text;
                        string PFC = PFCBox.SelectedValue.ToString();
                        string FanSize = FanSizeBox.Text;
                        string MotherboardPins = MotherboardPinsBox.Text;
                        string CpiPinQty = CpuPinQtyBox.Text;
                        string PCIEPinQty = PciPinQtyBox.Text;
                        string IDEPinQuantity = IDEPinQtyBox.Text;
                        string SataPinQuantity = SataPinQtyBox.Text;
                        string Overpressure = Convert.ToInt32(OverpressureBox.IsChecked).ToString();
                        string Overflow = Convert.ToInt32(OverFlowBox.IsChecked).ToString();
                        string ShortCircuit = Convert.ToInt32(ShortCircuitBox.IsChecked).ToString();
                        string Certificate80Plus = CertificateBox.SelectedValue.ToString();
                        string Weight = WeightBox.Text;
                        string GuaranteeMon = GuaranteeBox.Text;
                        if (!String.IsNullOrWhiteSpace(Name) && !String.IsNullOrWhiteSpace(ManufacturerId) && !String.IsNullOrWhiteSpace(ImagePath) &&
                            !String.IsNullOrWhiteSpace(ManufacturerCode) && !String.IsNullOrWhiteSpace(Power) && !String.IsNullOrWhiteSpace(Standart) &&
                            !String.IsNullOrWhiteSpace(PFC) && !String.IsNullOrWhiteSpace(FanSize) && !String.IsNullOrWhiteSpace(MotherboardPins) &&
                            !String.IsNullOrWhiteSpace(CpiPinQty) && !String.IsNullOrWhiteSpace(PCIEPinQty) && !String.IsNullOrWhiteSpace(IDEPinQuantity) &&
                            !String.IsNullOrWhiteSpace(SataPinQuantity) && !String.IsNullOrWhiteSpace(Overpressure) && !String.IsNullOrWhiteSpace(Overflow) &&
                            !String.IsNullOrWhiteSpace(ShortCircuit) && !String.IsNullOrWhiteSpace(Certificate80Plus) && !String.IsNullOrWhiteSpace(Weight) && !String.IsNullOrWhiteSpace(CpiPinQty) && !String.IsNullOrWhiteSpace(GuaranteeMon))
                        {
                            newPsu = new Psu(null, null, ManufacturerId, null, null, null, Name, ImagePath, ManufacturerCode, Power, Standart, PFC, FanSize, MotherboardPins, CpiPinQty, PCIEPinQty, IDEPinQuantity, SataPinQuantity, Overpressure, Overflow, ShortCircuit, Certificate80Plus, Weight, GuaranteeMon);

                            using (WebClient client = new WebClient())
                            {
                                var s = JsonSerializer.Serialize<MyDuckStoreSeller.Classes.Products.Psu>(newPsu);
                                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                                client.UploadString(new Uri("https://myduckstudios.fvds.ru/api/controllers/products/psu/create.php"), "POST", s);

                                WebClient client2 = new WebClient();

                                NameValueCollection query = new NameValueCollection();
                                query.Add("Image", imagebase64);
                                query.Add("ManufacturerCode", ManufacturerCodeBox.Text);

                                var responce = client2.UploadValues("https://myduckstudios.fvds.ru/api/controllers/image.php", "POST", query);
                                MainWindow.allproducts.Clear();
                                MainWindow.AllProductsFill();
                                MessageBox.Show("Товар добавлен");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Заполните все поля и загрузите фотографию товара перед добавлением.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Укажите производителя.");
                    }
                }
                else
                {
                    MessageBox.Show("Товар с таким кодом производителя уже существует.");
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля перед добавлением товара.");
            }
        }
        private void ManufacturerBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ManufacturerBox.SelectedValue.ToString() == "Добавить нового производителя...")
            {
                AddManufacturer addmanuform = new AddManufacturer();
                addmanuform.ShowDialog();
            }
        }

        private void Text_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void Decimal_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            bool approvedDecimalPoint = false;

            if (e.Text == ".")
            {
                if (!((TextBox)sender).Text.Contains("."))
                    approvedDecimalPoint = true;
            }

            if (!(char.IsDigit(e.Text, e.Text.Length - 1) || approvedDecimalPoint))
                e.Handled = true;
        }
        private void ManufacturerBox_DropDownOpened(object sender, EventArgs e)
        {
            MainWindow.manufacturers.manufacturer.Clear();
            MainWindow.ManufacturersFill();
            manufacturers = MainWindow.manufacturers.manufacturer.Select(m => m.ManufacturerName).ToList();
            manufacturers.Sort();
            manufacturers.Insert(0, "Добавить нового производителя...");
            ManufacturerBox.ItemsSource = manufacturers;
        }

        private void ManufacturerCodeBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^a-zA-Z0-9\s]");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
