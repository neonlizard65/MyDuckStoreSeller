﻿using MyDuckStoreSeller.Classes.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.Json;
using System.Net;

namespace MyDuckStoreSeller.Classes.FormProduct
{
    /// <summary>
    /// Interaction logic for AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        List<string> CategoriesList = new List<string>() { "Кулер", "ЦПУ", "Жесткий диск", "Наушники", "Клавиатура", "Монитор", "Материнская плата",
            "Мышь", "Блок питания", "ОЗУ", "Накопитель SSD", "Корпус", "USB накопитель", "Видеокарта", "Водяное охлаждение"};
        ManufacturerList allmanufacturers;

        KeyValuePair<Instance, Product> currentproduct;
        List<Product> allproductss;
        List<Product> allssd;

        public AddEditWindow(KeyValuePair<Instance, Product> product, ref List<Product> allproducts)
        {
            InitializeComponent();

            //Для глоб. переменных
            currentproduct = product;
            allproductss = allproducts;

            //Все SSD
            allssd = (from x in allproductss
                      where x is Ssd
                      select x).ToList();

            //Категории
            CategoriesList.Sort();
            CategoriesComboBox.ItemsSource = CategoriesList;

            //Производители
            allmanufacturers = JsonSerializer.Deserialize<ManufacturerList>(new WebClient().DownloadString("https://myduckstudios.fvds.ru/api/controllers/manufacturer/read.php"));

            if (product.Value != null)
            {
                CategoriesComboBox.IsEnabled = false;
                if (product.Value is Ssd)
                {
                    CategoriesComboBox.SelectedItem = "Накопитель SSD";
                    SsdCreatePage ssdpage = new SsdCreatePage(product, allssd, allmanufacturers);
                    ProductFrame.Navigate(ssdpage);
                }
            }

        }

        private void CategoriesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CategoriesComboBox.SelectedValue == "Накопитель SSD")
            {
                SsdCreatePage ssdpage = new SsdCreatePage(currentproduct, allssd, allmanufacturers);
                ProductFrame.Navigate(ssdpage);
            }
        }
    }
}