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
    /// Interaction logic for MouseInstanceCreatePage.xaml
    /// </summary>
    public partial class MouseInstanceCreatePage : Page
    {
       List<Product> allMouse;
        public MouseInstanceCreatePage()
        {
            InitializeComponent();

            allMouse = (from x in MainWindow.allproducts
                        where x is MyDuckStoreSeller.Classes.Products.Mouse
                        orderby x.ManufacturerName
                        select x).ToList();


            NameBox.ItemsSource = allMouse.Select(p => p.Name);
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!MainWindow.sellerproducts.Select(p => p.Key.SerialNumber).Contains(SerialBox.Text))
                {
                using (var client = new WebClient())
                {
                    try
                    {
                        var newinst = new MouseInstance(null, (DataContext as MyDuckStoreSeller.Classes.Products.Mouse).MouseID, SerialBox.Text, MainWindow.seller.SellerID, null, "0", PriceBox.Text);
                        var jsoninst = JsonSerializer.Serialize<MouseInstance>(newinst);
                        client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                        client.UploadString(new Uri("https://myduckstudios.fvds.ru/api/controllers/instances/mouseinstance/create.php"), "POST", jsoninst);
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
            DataContext = allMouse.First(p=> p.Name == NameBox.SelectedValue.ToString());
        }

        private void NameBox_DropDownOpened(object sender, EventArgs e)
        {
            MainWindow.allproducts.Clear();
            MainWindow.AllProductsFill();
            allMouse = (from x in MainWindow.allproducts
                      where x is MyDuckStoreSeller.Classes.Products.Mouse
                        orderby x.ManufacturerName
                      select x).ToList();

            NameBox.ItemsSource = allMouse.Select(p => p.Name);
        }
    }
}
