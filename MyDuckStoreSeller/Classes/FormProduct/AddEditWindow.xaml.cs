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
using MyDuckStoreSeller.Classes.Products;

namespace MyDuckStoreSeller.Classes.FormProduct
{
    /// <summary>
    /// Interaction logic for AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        List<string> CategoriesList = new List<string>() { "Кулер", "ЦПУ", "Жесткий диск", "Наушники", "Клавиатура", "Монитор", "Материнская плата",
            "Мышь", "Блок питания", "ОЗУ", "Накопитель SSD", "Корпус", "Накопитель USB", "Видеокарта", "Водяное охлаждение"};

        string Method;

        public AddEditWindow(string method, KeyValuePair<Instance, Product> product)
        {
            InitializeComponent();

            //Для глоб. переменных
            this.Method = method;

            //Категории
            CategoriesList.Sort();
            CategoriesComboBox.ItemsSource = CategoriesList;

            if (Method == "UpdateInstance")
            {
                CategoriesComboBox.IsEnabled = false;
                if (product.Value is Ssd)
                {
                    CategoriesComboBox.SelectedItem = "Накопитель SSD";
                    SsdInstanceUpdatePage ssdpage = new SsdInstanceUpdatePage(product);
                    ProductFrame.Navigate(ssdpage);
                }
                if (product.Value is Aircooler)
                {
                    CategoriesComboBox.SelectedItem = "Кулер";
                    AircoolerInstanceUpdatePage aircoolerpage = new AircoolerInstanceUpdatePage(product);
                    ProductFrame.Navigate(aircoolerpage);
                }
                if (product.Value is Cpu)
                {
                    CategoriesComboBox.SelectedItem = "ЦПУ";
                    CpuInstanceUpdatePage cpupage = new CpuInstanceUpdatePage(product);
                    ProductFrame.Navigate(cpupage);
                }
            }
        }

        private void CategoriesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CategoriesComboBox.SelectedValue.ToString() == "Накопитель SSD")
            {
                if (Method == "CreateInstance")
                {
                    SsdInstanceCreatePage ssdpage = new SsdInstanceCreatePage();
                    ProductFrame.Navigate(ssdpage);
                }
                if (Method == "CreateProduct")
                {
                    SsdCreatePage ssdpage = new SsdCreatePage();
                    ProductFrame.Navigate(ssdpage);
                }
            }
            if (CategoriesComboBox.SelectedValue.ToString() == "Кулер")
            {
                if (Method == "CreateInstance")
                {
                    AircoolerInstanceCreatePage aircoolerpage = new AircoolerInstanceCreatePage();
                    ProductFrame.Navigate(aircoolerpage);
                }
                if (Method == "CreateProduct")
                {
                    AircoolerCreatePage aircoolerpage = new AircoolerCreatePage();
                    ProductFrame.Navigate(aircoolerpage);
                }
            }
            if (CategoriesComboBox.SelectedValue.ToString() == "ЦПУ")
            {
                if (Method == "CreateInstance")
                {
                    CpuInstanceCreatePage cpupage = new CpuInstanceCreatePage();
                    ProductFrame.Navigate(cpupage);
                }
                if (Method == "CreateProduct")
                {
                    CpuCreatePage cpupage = new CpuCreatePage();
                    ProductFrame.Navigate(cpupage);
                }
            }
        }
    }
}