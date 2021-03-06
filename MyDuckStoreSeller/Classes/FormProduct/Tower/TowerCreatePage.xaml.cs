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
    /// Interaction logic for TowerCreatePage.xaml
    /// </summary>
    public partial class TowerCreatePage : Page
    {
        Tower newTower;
        public static string imageurl { get; set; }
        List<string> manufacturers = new List<string>();
        string imagebase64;
        public TowerCreatePage()
        {
            InitializeComponent();
            manufacturers = MainWindow.manufacturers.manufacturer.Select(m => m.ManufacturerName).ToList();
            manufacturers.Sort();
            manufacturers.Insert(0, "Добавить нового производителя...");
            ManufacturerBox.ItemsSource = manufacturers;

            SizeBox.ItemsSource = new List<string>() { "Full-Tower", "Micro-Tower", "Midi-Tower", "Mini-Tower", "Slim-Desktop"};
            WindowMaterialBox.ItemsSource = new List<string>() { "Акрил", "Закаленное стекло" };
            WindowMaterialBox.IsEnabled = false;

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
                !String.IsNullOrWhiteSpace(ManufacturerCodeBox.Text) && !String.IsNullOrWhiteSpace(FormFactorBox.Text)
                && !String.IsNullOrWhiteSpace(SizeBox.SelectedValue.ToString()) && !String.IsNullOrWhiteSpace(BPLocationBox.Text) &&
                !String.IsNullOrWhiteSpace(TowerMaterialBox.Text) && !String.IsNullOrWhiteSpace(Slot2p5Box.Text) && !String.IsNullOrWhiteSpace(Slot3p5Box.Text) &&
                !String.IsNullOrWhiteSpace(ExpansionSlotsBox.Text) && !String.IsNullOrWhiteSpace(HDDPlacementBox.Text) && !String.IsNullOrWhiteSpace(MaxVideocardLengthBox.Text)
                && !String.IsNullOrWhiteSpace(MaxCoolerHeightBox.Text) && !String.IsNullOrWhiteSpace(InterfacesFrontBox.Text) && !String.IsNullOrWhiteSpace(FansBox.Text) 
                && !String.IsNullOrWhiteSpace(DimensionsBox.Text) && !String.IsNullOrWhiteSpace(WeightBox.Text) && !String.IsNullOrWhiteSpace(GuaranteeBox.Text))
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
                        string Size = SizeBox.SelectedValue.ToString();
                        string FormFactor = FormFactorBox.Text;
                        string BPIncluded = Convert.ToInt32(BPIncludedBox.IsChecked).ToString();
                        string BPLocation = BPLocationBox.Text;
                        string TowerMaterial = TowerMaterialBox.Text;
                        string SideWindow = Convert.ToInt32(SideWindowBox.IsChecked).ToString();
                        string WindowMaterial = WindowMaterialBox.Text;
                        string Slot2p5Qty = Slot2p5Box.Text;
                        string Slot3p5Qty = Slot3p5Box.Text;
                        string ExpansionSlots = ExpansionSlotsBox.Text;
                        string HDDPlacement = HDDPlacementBox.Text;
                        string MaxVideocardLength = MaxVideocardLengthBox.Text;
                        string MaxCoolerHeight = MaxCoolerHeightBox.Text;
                        string InterfacesFront = InterfacesFrontBox.Text;
                        string Fans = FansBox.Text;
                        string Dimensions = DimensionsBox.Text;
                        string Weight = WeightBox.Text;
                        string GuaranteeMon = GuaranteeBox.Text;
                        if (!String.IsNullOrWhiteSpace(Name) && !String.IsNullOrWhiteSpace(ManufacturerId) && !String.IsNullOrWhiteSpace(ImagePath) &&
                            !String.IsNullOrWhiteSpace(ManufacturerCode) && !String.IsNullOrWhiteSpace(FormFactor) && !String.IsNullOrWhiteSpace(Size) &&
                            !String.IsNullOrWhiteSpace(BPLocation) && !String.IsNullOrWhiteSpace(TowerMaterial) && !String.IsNullOrWhiteSpace(Slot2p5Qty) &&
                            !String.IsNullOrWhiteSpace(Slot3p5Qty)  && !String.IsNullOrWhiteSpace(ExpansionSlots) && !String.IsNullOrWhiteSpace(HDDPlacement)
                            && !String.IsNullOrWhiteSpace(MaxVideocardLength) && !String.IsNullOrWhiteSpace(MaxCoolerHeight) && !String.IsNullOrWhiteSpace(InterfacesFront)
                            && !String.IsNullOrWhiteSpace(Fans) && !String.IsNullOrWhiteSpace(Dimensions) && !String.IsNullOrWhiteSpace(Weight) 
                            && !String.IsNullOrWhiteSpace(GuaranteeMon))
                        {
                            newTower = new Tower(null, null, ManufacturerId, null, null, null, Name, ImagePath, ManufacturerCode, FormFactor, FormFactor, BPIncluded, BPLocation, TowerMaterial, SideWindow, WindowMaterial, Slot2p5Qty, Slot3p5Qty, ExpansionSlots, HDDPlacement, MaxVideocardLength, MaxCoolerHeight, InterfacesFront, Fans, Dimensions, Weight, GuaranteeMon);

                            using (WebClient client = new WebClient())
                            {
                                var s = JsonSerializer.Serialize<Tower>(newTower);
                                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                                client.UploadString(new Uri("https://myduckstudios.fvds.ru/api/controllers/products/tower/create.php"), "POST", s);

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
            if (!e.Text.Contains(" "))
            {
                Regex regex = new Regex(@"[^a-zA-Z0-9-_]");
                e.Handled = regex.IsMatch(e.Text);
            }
            else
                e.Handled = true;
        }

        private void SideWindowBox_Unchecked(object sender, RoutedEventArgs e)
        {
            WindowMaterialBox.IsEnabled = false;
            WindowMaterialBox.SelectedIndex = -1;
        }

        private void SideWindowBox_Checked(object sender, RoutedEventArgs e)
        {
            WindowMaterialBox.IsEnabled = true;
        }
    }
}
