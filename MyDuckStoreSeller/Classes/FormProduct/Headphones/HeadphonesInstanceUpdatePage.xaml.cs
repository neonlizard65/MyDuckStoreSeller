using MyDuckStoreSeller.Classes.Instances;
using MyDuckStoreSeller.Classes.Products;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for HeadphonesCreatePage.xaml
    /// </summary>
    public partial class HeadphonesInstanceUpdatePage : Page
    {
        KeyValuePair<Instance, Product> product;
        public HeadphonesInstanceUpdatePage(KeyValuePair<Instance, Product> product)
        {
            InitializeComponent();

            //Для глоб. переменные
            this.product = product;

            DataContext = product;

            if (product.Key.Sold == "1")
            {
                PriceBox.IsEnabled = false;
                SerialBox.IsEnabled = false;
                SendBtn.IsEnabled = false;
                DeleteBtn.IsEnabled = false;
            }

        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new WebClient())
            {
                try
                {
                    var jsoninst = JsonSerializer.Serialize<HeadphonesInstance>(new HeadphonesInstance((product.Key as HeadphonesInstance).HeadphonesInstanceID, (product.Value as Headphones).HeadphonesID, SerialBox.Text, MainWindow.seller.SellerID, null, "0", PriceBox.Text));
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    client.UploadString(new Uri("https://myduckstudios.fvds.ru/api/controllers/instances/headphonesinstance/update.php"), "POST", jsoninst);
                    MessageBox.Show("Товар успешно обновлен.");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString(), "Ошибка обновления");
                }
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы точно хотите удалить этот товар?", "Удаление", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                using (var client = new WebClient())
                {
                    try
                    {
                        client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                        client.UploadString(new Uri("https://myduckstudios.fvds.ru/api/controllers/instances/headphonesinstance/delete.php"), "DELETE", "{" + $"\"HeadphonesInstanceID\" : \"{(product.Key as HeadphonesInstance).HeadphonesInstanceID}\"" + "}");
                        MessageBox.Show("Товар успешно удален.");
                        this.IsEnabled = false;

                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.ToString(), "Ошибка удаления");
                    }
                }
            }
        }
    }
}
