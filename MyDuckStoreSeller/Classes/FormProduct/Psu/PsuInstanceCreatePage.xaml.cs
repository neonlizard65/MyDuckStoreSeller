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
    /// Interaction logic for PsuInstanceCreatePage.xaml
    /// </summary>
    public partial class PsuInstanceCreatePage : Page
    {
       List<Product> allPsu;
        public PsuInstanceCreatePage()
        {
            InitializeComponent();

            allPsu = (from x in MainWindow.allproducts
                        where x is Psu
                        orderby x.ManufacturerName
                        select x).ToList();


            NameBox.ItemsSource = allPsu.Select(p => p.Name);
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!MainWindow.sellerproducts.Select(p => p.Key.SerialNumber).Contains(SerialBox.Text))
                {
                using (var client = new WebClient())
                {
                    try
                    {
                        var newinst = new PsuInstance(null, (DataContext as Psu).PsuID, SerialBox.Text, MainWindow.seller.SellerID, null, "0", PriceBox.Text);
                        var jsoninst = JsonSerializer.Serialize<PsuInstance>(newinst);
                        client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                        client.UploadString(new Uri("https://myduckstudios.fvds.ru/api/controllers/instances/psuinstance/create.php"), "POST", jsoninst);
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
            DataContext = allPsu.First(p=> p.Name == NameBox.SelectedValue.ToString());
            OverFlowBox.IsChecked = Convert.ToBoolean(Convert.ToInt32((DataContext as Psu).OverflowProtection));
            OverpressureBox.IsChecked = Convert.ToBoolean(Convert.ToInt32((DataContext as Psu).OverpressureProtection));
            ShortCircuitBox.IsChecked = Convert.ToBoolean(Convert.ToInt32((DataContext as Psu).ShortCircuitProtection));
        }

        private void NameBox_DropDownOpened(object sender, EventArgs e)
        {
            MainWindow.allproducts.Clear();
            MainWindow.AllProductsFill();
            allPsu = (from x in MainWindow.allproducts
                      where x is Psu
                        orderby x.ManufacturerName
                      select x).ToList();

            NameBox.ItemsSource = allPsu.Select(p => p.Name);
        }
    }
}
