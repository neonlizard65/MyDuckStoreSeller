﻿using MyDuckStoreSeller.Classes.Instances;
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
    /// Interaction logic for SsdCreatePage.xaml
    /// </summary>
    public partial class SsdInstanceUpdatePage : Page
    {
        KeyValuePair<Instance, Product> product;
        public SsdInstanceUpdatePage(KeyValuePair<Instance, Product> product)
        {
            InitializeComponent();

            //Для глоб. переменные
            this.product = product;

            DataContext = product;
            if(product.Key.Sold == "1")
            {
                PriceBox.IsEnabled = false;
                SerialBox.IsEnabled = false;
            }

        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new WebClient())
            {
                try
                {
                    var jsoninst = JsonSerializer.Serialize<SsdInstance>(new SsdInstance((product.Key as SsdInstance).SsdInstanceID, (product.Value as Ssd).SsdID, SerialBox.Text, MainWindow.seller.SellerID, null, "0", PriceBox.Text));
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    client.UploadString(new Uri("https://myduckstudios.fvds.ru/api/controllers/instances/ssdinstance/update.php"), "POST", jsoninst);
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