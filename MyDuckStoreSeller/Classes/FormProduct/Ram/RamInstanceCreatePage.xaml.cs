using MyDuckStoreSeller.Classes.Instances;
using MyDuckStoreSeller.Classes.Products;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyDuckStoreSeller.Classes.FormProduct
{
    /// <summary>
    /// Interaction logic for RamInstanceCreatePage.xaml
    /// </summary>
    public partial class RamInstanceCreatePage : Page
    {
       List<Product> allRam;
        public RamInstanceCreatePage()
        {
            InitializeComponent();

            allRam = (from x in MainWindow.allproducts
                        where x is Ram
                        orderby x.ManufacturerName
                        select x).ToList();


            NameBox.ItemsSource = allRam.Select(p => p.Name);
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!MainWindow.sellerproducts.Select(p => p.Key.SerialNumber).Contains(SerialBox.Text))
                {
                using (var client = new WebClient())
                {
                    try
                    {
                        var newinst = new RamInstance(null, (DataContext as Ram).RamID, SerialBox.Text, MainWindow.seller.SellerID, null, "0", PriceBox.Text);
                        var jsoninst = JsonSerializer.Serialize<RamInstance>(newinst);
                        client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                        client.UploadString(new Uri("https://myduckstudios.fvds.ru/api/controllers/instances/raminstance/create.php"), "POST", jsoninst);
                        MessageBox.Show("Товар успешно добавлен.");
                        
                        //закрыть окно
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.ToString(), "Ошибка добавления");
                    }
                }
            }
            else
            {
                MessageBox.Show("Товар с указанным серийным номером уже существует.");
            }
        }

        private void NameBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataContext = allRam.First(p=> p.Name == NameBox.SelectedValue.ToString());
        }

        private void NameBox_DropDownOpened(object sender, EventArgs e)
        {
            MainWindow.allproducts.Clear();
            MainWindow.AllProductsFill();
            allRam = (from x in MainWindow.allproducts
                      where x is Ram
                      orderby x.ManufacturerName
                      select x).ToList();

            NameBox.ItemsSource = allRam.Select(p => p.Name);
        }
    }
}
