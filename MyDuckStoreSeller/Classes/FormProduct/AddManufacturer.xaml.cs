using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
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

namespace MyDuckStoreSeller.Classes.FormProduct
{
    /// <summary>
    /// Interaction logic for AddManufacturer.xaml
    /// </summary>
    public partial class AddManufacturer : Window
    {
        string imageurl { get; set; }
        string imagebase64;
        public AddManufacturer()
        {
            InitializeComponent();
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(NameBox.Text))
            {
                try
                {
                    //диалоговое окно для импорта
                    OpenFileDialog open = new OpenFileDialog();
                    open.Filter = "Изображения (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";

                    var result = open.ShowDialog();

                    if (result == true)
                    {
                        Byte[] imagebytes = File.ReadAllBytes(open.FileName);
                        ManuImage.Source = new BitmapImage(new Uri(open.FileName));
                        imagebase64 = Convert.ToBase64String(imagebytes);
                        imageurl = "https://myduckstudios.fvds.ru/photos/manufacturers/" + NameBox.Text + ".png";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Заполните название производителя перед добавлением фото", "Внимание");
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.manufacturers.manufacturer.Clear();
            MainWindow.ManufacturersFill();
            if (!String.IsNullOrWhiteSpace(NameBox.Text) && !String.IsNullOrWhiteSpace(SiteBox.Text) && !String.IsNullOrWhiteSpace(imageurl))
            {
                if (!MainWindow.manufacturers.manufacturer.Select(p => p.ManufacturerName).Contains(NameBox.Text))
                {
                    Manufacturer newmanu = new Manufacturer(null, NameBox.Text, SiteBox.Text, imageurl);
                    using (var client = new WebClient())
                    {
                        try
                        {
                            var s = JsonSerializer.Serialize<Manufacturer>(newmanu);
                            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                            client.UploadString(new Uri("https://myduckstudios.fvds.ru/api/controllers/manufacturer/create.php"), "POST", s);

                            WebClient client2 = new WebClient();
                            NameValueCollection query = new NameValueCollection();
                            query.Add("ManufacturerImage", imagebase64);
                            query.Add("ManufacturerName", NameBox.Text);
                            var responce = client2.UploadValues("https://myduckstudios.fvds.ru/api/controllers/manuimage.php", "POST", query);

                            MessageBox.Show("Производитель добавлен!");
                            MainWindow.manufacturers.manufacturer.Clear();
                            MainWindow.ManufacturersFill();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Ошибка добавления");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Производитель уже существует!");
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля и импортируйте фото перед добавлением производителя", "Внимание");
            }
        }
    }
}
