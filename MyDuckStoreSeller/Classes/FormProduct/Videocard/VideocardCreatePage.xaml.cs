﻿using Microsoft.Win32;
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
    /// Interaction logic for VideocardCreatePage.xaml
    /// </summary>
    public partial class VideocardCreatePage : Page
    {
        Videocard newVideocard;
        public static string imageurl { get; set; }
        List<string> manufacturers = new List<string>();
        string imagebase64;
        public VideocardCreatePage()
        {
            InitializeComponent();
            manufacturers = MainWindow.manufacturers.manufacturer.Select(m => m.ManufacturerName).ToList();
            manufacturers.Sort();
            manufacturers.Insert(0, "Добавить нового производителя...");
            ManufacturerBox.ItemsSource = manufacturers;
            InterfaceBox.ItemsSource = new List<string>() { "PCI Express 2.0", "PCI Express 3.0", "PCI Express 4.0" };
            VidProcBox.ItemsSource = new List<string>() { "AMD", "nVidia"};
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
                !String.IsNullOrWhiteSpace(ManufacturerCodeBox.Text) && !String.IsNullOrWhiteSpace(InterfaceBox.SelectedValue.ToString()) &&
                !String.IsNullOrWhiteSpace(VidProcBox.SelectedValue.ToString()) && !String.IsNullOrWhiteSpace(SeriesBox.Text) && !String.IsNullOrWhiteSpace(NanometersBox.Text) &&
                !String.IsNullOrWhiteSpace(NanometersBox.Text) && !String.IsNullOrWhiteSpace(ClockSpeedBox.Text) && 
                !String.IsNullOrWhiteSpace(CountUnivBox.Text) && !String.IsNullOrWhiteSpace(DirectXBox.Text) && !String.IsNullOrWhiteSpace(OpenGLBox.Text)
                && !String.IsNullOrWhiteSpace(MemoryMBBox.Text) && !String.IsNullOrWhiteSpace(MemoryTypeBox.Text) && !String.IsNullOrWhiteSpace(PortsBox.Text)
                && !String.IsNullOrWhiteSpace(CountUnivBox.Text) && !String.IsNullOrWhiteSpace(MaxResolutionBox.Text) && !String.IsNullOrWhiteSpace(PinsBox.Text)
                 && !String.IsNullOrWhiteSpace(WattBox.Text) && !String.IsNullOrWhiteSpace(DimensionsBox.Text)
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
                        string Interface = InterfaceBox.SelectedValue.ToString();
                        string ProcessorManufacturer = VidProcBox.SelectedValue.ToString();
                        string Series = SeriesBox.Text;
                        string Nanometers = NanometersBox.Text;
                        string ClockSpeed = ClockSpeedBox.Text;
                        string CountUniversalProcessor = CountUnivBox.Text;
                        string SLICrossfire = Convert.ToInt32(SliBox.IsChecked).ToString();
                        string DirectXSupport = DirectXBox.Text;
                        string OpenGLSupport = OpenGLBox.Text;
                        string MemoryMB = MemoryMBBox.Text;
                        string MemoryType = MemoryTypeBox.Text;
                        string Ports = PortsBox.Text;
                        string CountMonitorsSupport = CountMonitorsBox.Text;
                        string MaxResolution = MaxResolutionBox.Text;
                        string Pins = PinsBox.Text;
                        string Watt = WattBox.Text;
                        string Dimensions = DimensionsBox.Text;
                        string GuaranteeMon = GuaranteeBox.Text;
                        if (!String.IsNullOrWhiteSpace(Name) && !String.IsNullOrWhiteSpace(ManufacturerId) && !String.IsNullOrWhiteSpace(ImagePath) &&
                            !String.IsNullOrWhiteSpace(ManufacturerCode) && !String.IsNullOrWhiteSpace(Interface) && !String.IsNullOrWhiteSpace(ProcessorManufacturer) &&
                            !String.IsNullOrWhiteSpace(Series) && !String.IsNullOrWhiteSpace(Nanometers) && !String.IsNullOrWhiteSpace(ClockSpeed) &&
                            !String.IsNullOrWhiteSpace(CountUniversalProcessor) && !String.IsNullOrWhiteSpace(SLICrossfire) && !String.IsNullOrWhiteSpace(DirectXSupport)
                            && !String.IsNullOrWhiteSpace(OpenGLSupport) && !String.IsNullOrWhiteSpace(MemoryMB) && !String.IsNullOrWhiteSpace(MemoryType)
                            && !String.IsNullOrWhiteSpace(Ports) && !String.IsNullOrWhiteSpace(CountMonitorsSupport)
                             && !String.IsNullOrWhiteSpace(MaxResolution) && !String.IsNullOrWhiteSpace(Pins) && !String.IsNullOrWhiteSpace(Watt)
                              && !String.IsNullOrWhiteSpace(Dimensions) && !String.IsNullOrWhiteSpace(GuaranteeMon))
                        {
                            newVideocard = new Videocard(null, null, ManufacturerId, null, null, null, Name, ImagePath, ManufacturerCode, Interface, ProcessorManufacturer, Series, Nanometers, ClockSpeed, CountUniversalProcessor, SLICrossfire, DirectXSupport, OpenGLSupport, MemoryMB, MemoryType, Ports, CountMonitorsSupport, MaxResolution, Pins, Watt, Dimensions, GuaranteeMon);

                            using (WebClient client = new WebClient())
                            {
                                var s = JsonSerializer.Serialize<Videocard>(newVideocard);
                                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                                client.UploadString(new Uri("https://myduckstudios.fvds.ru/api/controllers/products/videocard/create.php"), "POST", s);

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
