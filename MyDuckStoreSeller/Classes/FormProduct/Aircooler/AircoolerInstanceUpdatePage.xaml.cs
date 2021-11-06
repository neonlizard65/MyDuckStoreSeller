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
    /// Interaction logic for AircoolerCreatePage.xaml
    /// </summary>
    public partial class AircoolerInstanceUpdatePage : Page
    {
        KeyValuePair<Instance, Product> product;
        public AircoolerInstanceUpdatePage(KeyValuePair<Instance, Product> product)
        {
            InitializeComponent();

            //Для глоб. переменные
            this.product = product;

            DataContext = product;

            ThermalTubesCheckBox.IsChecked = Convert.ToBoolean(Convert.ToInt32((product.Value as Aircooler).ThermalTubes));

            if (product.Key.Sold == "1")
            {
                PriceBox.IsEnabled = false;
                SerialBox.IsEnabled = false;
                SendBtn.IsEnabled = false;
            }

        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new WebClient())
            {
                try
                {
                    var jsoninst = JsonSerializer.Serialize<AircoolerInstance>(new AircoolerInstance((product.Key as AircoolerInstance).AircoolerInstanceID, (product.Value as Aircooler).AircoolerID, SerialBox.Text, MainWindow.seller.SellerID, null, "0", PriceBox.Text));
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    client.UploadString(new Uri("https://myduckstudios.fvds.ru/api/controllers/instances/aircoolerinstance/update.php"), "POST", jsoninst);
                    MessageBox.Show("Товар успешно обновлен.");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString(), "Ошибка обновления");
                }
            }
        }

    }
}
