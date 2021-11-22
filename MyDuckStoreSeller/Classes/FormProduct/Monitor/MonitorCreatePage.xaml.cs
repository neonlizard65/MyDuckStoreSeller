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
    /// Interaction logic for MonitorCreatePage.xaml
    /// </summary>
    public partial class MonitorCreatePage : Page
    {
        MyDuckStoreSeller.Classes.Products.Monitor newMonitor;
        public static string imageurl { get; set; }
        List<string> manufacturers = new List<string>();
        string imagebase64;
        public MonitorCreatePage()
        {
            InitializeComponent();
            manufacturers = MainWindow.manufacturers.manufacturer.Select(m => m.ManufacturerName).ToList();
            manufacturers.Sort();
            manufacturers.Insert(0, "Добавить нового производителя...");
            ManufacturerBox.ItemsSource = manufacturers;
            MatrixBox.ItemsSource = new List<string>() { "A-MVA", "AH-IPS", "AHVA", "AMVA3", "IPS", "IPS-ADS", "MVA", "Nano IPS", "OLED", "PLS", "TN+film", "VA" };
            PowerSupplyBox.ItemsSource = new List<string>() { "Внешний", "Встроенный" };
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

            if (!String.IsNullOrWhiteSpace(imagebase64) && !String.IsNullOrWhiteSpace(NameBox.Text) && !String.IsNullOrWhiteSpace(ManufacturerBox.SelectedValue.ToString()) &&
                !String.IsNullOrWhiteSpace(ManufacturerCodeBox.Text) && !String.IsNullOrWhiteSpace(DiagonalBox.Text)
                && !String.IsNullOrWhiteSpace(MatrixBox.SelectedValue.ToString()) &&
                !String.IsNullOrWhiteSpace(ResolutionBox.Text) && !String.IsNullOrWhiteSpace(BrightnessBox.Text)
                && !String.IsNullOrWhiteSpace(ContrastBox.Text) && !String.IsNullOrWhiteSpace(DelayBox.Text) && !String.IsNullOrWhiteSpace(HorizontalFOVBox.Text)
                && !String.IsNullOrWhiteSpace(VerticalFOVBox.Text) && !String.IsNullOrWhiteSpace(VerticalFOVBox.Text) && !String.IsNullOrWhiteSpace(MaxColorQtyBox.Text)
                && !String.IsNullOrWhiteSpace(HertzBox.Text) && !String.IsNullOrWhiteSpace(WallMountBox.Text) && !String.IsNullOrWhiteSpace(VoltageWorkingBox.Text)
                && !String.IsNullOrWhiteSpace(PowerSupplyBox.SelectedValue.ToString()) && !String.IsNullOrWhiteSpace(USBHubBox.Text) && !String.IsNullOrWhiteSpace(VoltageIdleBox.Text)
                && !String.IsNullOrWhiteSpace(InterfaceBox.Text) && !String.IsNullOrWhiteSpace(ColorBox.Text) && !String.IsNullOrWhiteSpace(DimensionsBox.Text)
                && !String.IsNullOrWhiteSpace(WeightBox.Text) && !String.IsNullOrWhiteSpace(GuaranteeBox.Text))
            {
                MainWindow.allproducts.Clear();
                MainWindow.AllProductsFill();
                if (!MainWindow.allproducts.Select(p => p.ManufacturerCode).Contains(ManufacturerCodeBox.Text))
                {
                    if (ManufacturerBox.SelectedValue.ToString() != "Добавить нового производителя...")
                    {
                        imageurl = "https://myduckstudios.fvds.ru/photos/" + ManufacturerCodeBox.Text.Replace(" ", "_") + "_1.png";
                        string Name = NameBox.Text;
                        string ManufacturerId = MainWindow.manufacturers.manufacturer.First(m => m.ManufacturerName == ManufacturerBox.SelectedValue.ToString()).ManufacturerID;
                        string ImagePath = imageurl;
                        string ManufacturerCode = ManufacturerCodeBox.Text;
                        string Diagonal = DiagonalBox.Text;
                        string Matrix = MatrixBox.SelectedValue.ToString();
                        string LED = (Convert.ToInt32(LEDBox.IsChecked)).ToString();
                        string WideFormat = (Convert.ToInt32(WideBox.IsChecked)).ToString();
                        string UltrawideFormat = (Convert.ToInt32(UltrawideBox.IsChecked)).ToString();
                        string Resolution = ResolutionBox.Text;
                        string Brightness = BrightnessBox.Text;
                        string Contrast = ContrastBox.Text;
                        string DelayMs = DelayBox.Text;
                        string HorizontalFOV = HorizontalFOVBox.Text;
                        string VerticalFOV = VerticalFOVBox.Text;
                        string MaxColorQty = MaxColorQtyBox.Text;
                        string Hertz = HertzBox.Text;
                        string HeightRegulation = (Convert.ToInt32(HeightRegulationBox.IsChecked)).ToString();
                        string WallMount = WallMountBox.Text;
                        string Rotate90 = (Convert.ToInt32(Rotate90Box.IsChecked)).ToString();
                        string Interface = InterfaceBox.Text;
                        string USBHub = USBHubBox.Text;
                        string PowerSupply = PowerSupplyBox.SelectedValue.ToString();
                        string VoltageWorking = VoltageWorkingBox.Text;
                        string VoltageIdle = VoltageIdleBox.Text;
                        string Color = ColorBox.Text;
                        string Dimensions = DimensionsBox.Text;
                        string Weight = WeightBox.Text;
                        string GuaranteeMon = GuaranteeBox.Text;
                        if (!String.IsNullOrWhiteSpace(Name) && !String.IsNullOrWhiteSpace(ManufacturerId) && !String.IsNullOrWhiteSpace(ImagePath) &&
                            !String.IsNullOrWhiteSpace(ManufacturerCode) && !String.IsNullOrWhiteSpace(Diagonal) && !String.IsNullOrWhiteSpace(Matrix) &&
                            !String.IsNullOrWhiteSpace(LED) && !String.IsNullOrWhiteSpace(WideFormat) && !String.IsNullOrWhiteSpace(UltrawideFormat)
                            && !String.IsNullOrWhiteSpace(Resolution) && !String.IsNullOrWhiteSpace(Brightness) && !String.IsNullOrWhiteSpace(Contrast)
                            && !String.IsNullOrWhiteSpace(DelayMs) && !String.IsNullOrWhiteSpace(HorizontalFOV) && !String.IsNullOrWhiteSpace(VerticalFOV)
                            && !String.IsNullOrWhiteSpace(MaxColorQty) && !String.IsNullOrWhiteSpace(Hertz) && !String.IsNullOrWhiteSpace(HeightRegulation)
                            && !String.IsNullOrWhiteSpace(WallMount) && !String.IsNullOrWhiteSpace(Rotate90) && !String.IsNullOrWhiteSpace(Interface)
                            && !String.IsNullOrWhiteSpace(USBHub) && !String.IsNullOrWhiteSpace(PowerSupply) && !String.IsNullOrWhiteSpace(VoltageWorking)
                            && !String.IsNullOrWhiteSpace(Color) && !String.IsNullOrWhiteSpace(Dimensions)
                            && !String.IsNullOrWhiteSpace(Weight) && !String.IsNullOrWhiteSpace(GuaranteeMon))
                        {
                            newMonitor = new Monitor(null, null, ManufacturerId, null, null, null, Name, ImagePath, ManufacturerCode,
                                Diagonal, Matrix, LED, WideFormat, UltrawideFormat, Resolution, Brightness, Contrast, DelayMs, HorizontalFOV, VerticalFOV, MaxColorQty, Hertz,
                                HeightRegulation, WallMount, Rotate90, Interface, USBHub, PowerSupply, VoltageWorking, VoltageIdle, Color, Dimensions, Weight, GuaranteeMon);

                            using (WebClient client = new WebClient())
                            {
                                var s = JsonSerializer.Serialize<MyDuckStoreSeller.Classes.Products.Monitor>(newMonitor);
                                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                                client.UploadString(new Uri("https://myduckstudios.fvds.ru/api/controllers/products/monitor/create.php"), "POST", s);

                                WebClient client2 = new WebClient();

                                NameValueCollection query = new NameValueCollection();
                                query.Add("Image", imagebase64);
                                query.Add("ManufacturerCode", ManufacturerCodeBox.Text.Replace(" ", "_"));

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
