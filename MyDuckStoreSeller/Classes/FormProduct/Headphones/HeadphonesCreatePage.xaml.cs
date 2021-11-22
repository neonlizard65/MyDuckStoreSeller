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
    /// Interaction logic for HeadphonesCreatePage.xaml
    /// </summary>
    public partial class HeadphonesCreatePage : Page
    {
        Headphones newHeadphones;
        public static string imageurl { get; set; }
        List<string> manufacturers = new List<string>();
        string imagebase64;
        public HeadphonesCreatePage()
        {
            InitializeComponent();
            manufacturers = MainWindow.manufacturers.manufacturer.Select(m => m.ManufacturerName).ToList();
            manufacturers.Sort();
            manufacturers.Insert(0, "Добавить нового производителя...");
            ManufacturerBox.ItemsSource = manufacturers;
            ConnectionBox.ItemsSource = new List<string>() { "Беспроводное", "Беспроводное/с проводом", "Проводное" };
            JackBox.ItemsSource = new List<string>() { "2 x mini jack 3.5 mm", "Bluetooth", "jack 6.3 mm", "lightning", "mini jack 2.5 mm", "mini jack 3.5 mm", "mini jack 3.5 mm/Bluetooth",
            "Quick Disconnect", "USB", "USB / 2 x mini jack 3.5 mm", "USB / Bluetooth", "USB / mini jack 3.5 mm", "USB / USB-C", "USB-C", "USB-C / Bluetooth", "USB-C / Bluetooth",
            "USB-C / 2 x mini jack 3.5 mm", "USB-C / mini jack 3.5 mm", "радиоканал"};
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
                !String.IsNullOrWhiteSpace(ManufacturerCodeBox.Text) && !String.IsNullOrWhiteSpace(ConnectionBox.SelectedValue.ToString())
                && !String.IsNullOrWhiteSpace(FrequencyBox.Text) &&
                !String.IsNullOrWhiteSpace(SensitivityBox.Text) && !String.IsNullOrWhiteSpace(JackBox.SelectedValue.ToString()) && !String.IsNullOrWhiteSpace(MicFreqBox.Text) &&
                !String.IsNullOrWhiteSpace(WeightBox.Text) && !String.IsNullOrWhiteSpace(GuaranteeBox.Text))
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
                        string ConnectionType = ConnectionBox.SelectedValue.ToString();
                        string FrequencyRange = FrequencyBox.Text;
                        string SensitivitydB = SensitivityBox.Text;
                        string Jack=JackBox.SelectedValue.ToString();
                        string MicrophoneSensitivity = MicFreqBox.Text;
                        string Weight = WeightBox.Text;
                        string GuaranteeMon = GuaranteeBox.Text;
                        if (!String.IsNullOrWhiteSpace(Name) && !String.IsNullOrWhiteSpace(ManufacturerId) && !String.IsNullOrWhiteSpace(ImagePath) &&
                            !String.IsNullOrWhiteSpace(ManufacturerCode) && !String.IsNullOrWhiteSpace(ConnectionType) && !String.IsNullOrWhiteSpace(FrequencyRange) &&
                            !String.IsNullOrWhiteSpace(SensitivitydB) && !String.IsNullOrWhiteSpace(Jack) && !String.IsNullOrWhiteSpace(MicrophoneSensitivity) &&
                            !String.IsNullOrWhiteSpace(Weight)  && !String.IsNullOrWhiteSpace(GuaranteeMon))
                        {
                            newHeadphones = new Headphones(null, null, ManufacturerId, null, null, null, Name, ImagePath, ManufacturerCode, ConnectionType, FrequencyRange, SensitivitydB, Jack, MicrophoneSensitivity, Weight, GuaranteeMon);

                            using (WebClient client = new WebClient())
                            {
                                var s = JsonSerializer.Serialize<Headphones>(newHeadphones);
                                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                                client.UploadString(new Uri("https://myduckstudios.fvds.ru/api/controllers/products/headphones/create.php"), "POST", s);

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
