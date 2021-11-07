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
    /// Interaction logic for KeyboardCreatePage.xaml
    /// </summary>
    public partial class KeyboardInstanceUpdatePage : Page
    {
        KeyValuePair<Instance, Product> product;
        public KeyboardInstanceUpdatePage(KeyValuePair<Instance, Product> product)
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

            NumpadCheckbox.IsChecked = Convert.ToBoolean(Convert.ToInt32((product.Value as MyDuckStoreSeller.Classes.Products.Keyboard).Numpad));

        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new WebClient())
            {
                try
                {
                    var jsoninst = JsonSerializer.Serialize<KeyboardInstance>(new KeyboardInstance((product.Key as KeyboardInstance).KeyboardInstanceID, (product.Value as MyDuckStoreSeller.Classes.Products.Keyboard).KeyboardID, SerialBox.Text, MainWindow.seller.SellerID, null, "0", PriceBox.Text));
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    client.UploadString(new Uri("https://myduckstudios.fvds.ru/api/controllers/instances/keyboardinstance/update.php"), "POST", jsoninst);
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
                        client.UploadString(new Uri("https://myduckstudios.fvds.ru/api/controllers/instances/keyboardinstance/delete.php"), "DELETE", "{" + $"\"KeyboardInstanceID\" : \"{(product.Key as KeyboardInstance).KeyboardInstanceID}\"" + "}");
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
