using MyDuckStoreSeller.Classes.Instances;
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
        List<Product> allproducts;
        List<Product> allssd;
        object senderbutton;

        public AddEditWindow(object sender, KeyValuePair<Instance, Product> product, ref List<Product> allproducts)
        {
            InitializeComponent();

            //Для глоб. переменных
            currentproduct = product;
            this.allproducts = allproducts;
            senderbutton = sender;

            //Все SSD
            allssd = (from x in this.allproducts
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
                    SsdInstanceCreatePage ssdpage = new SsdInstanceCreatePage(product, allssd, allmanufacturers);
                    ProductFrame.Navigate(ssdpage);
                }
            }

        }

        private void CategoriesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CategoriesComboBox.SelectedValue.ToString() == "Накопитель SSD")
            {
                if ((sender as Button).Name == "CreateInstance")
                {
                    SsdInstanceCreatePage ssdpage = new SsdInstanceCreatePage(currentproduct, allssd, allmanufacturers);
                    ProductFrame.Navigate(ssdpage);
                }
                if ((sender as Button).Name == "CreateProduct")
                {
                    SsdCreatePage ssdpage = new SsdCreatePage();
                    ProductFrame.Navigate(ssdpage);
                }
            }
        }
    }
}