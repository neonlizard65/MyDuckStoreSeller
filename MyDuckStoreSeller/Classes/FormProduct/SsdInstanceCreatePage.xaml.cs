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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyDuckStoreSeller.Classes.FormProduct
{
    /// <summary>
    /// Interaction logic for SsdCreatePage.xaml
    /// </summary>
    public partial class SsdInstanceCreatePage : Page
    {
        List<Product> allproducts;
        List<Product> allproductsdistinct;
        KeyValuePair<Instance, Product> curproduct;
        ManufacturerList allmanufacturers;
        string OrigManufacturerCode;
        string OrigSerialNumber;

        public SsdInstanceCreatePage(KeyValuePair<Instance, Product> product, List<Product> allproducts, ManufacturerList allmanufacturers)
        {
            InitializeComponent();

            //Для глоб. переменных
            this.allproducts = allproducts;
            allproductsdistinct = allproducts.Distinct().ToList();
            curproduct = product;
            this.allmanufacturers = allmanufacturers;
            OrigManufacturerCode = product.Value.ManufacturerCode;
            OrigSerialNumber = product.Key.SerialNumber;

            NameBox.ItemsSource = allproducts.Select(p => p.Name).ToList();
            ManufacturerBox.Text = product.Value.ManufacturerName;

            if (product.Value != null)
            {
                SendBtn.Content = "Обновить товар";
                DataContext = product;
                NameBox.SelectedItem = product.Value.Name;
                ManufacturerBox.Text = product.Value.ManufacturerName;
            }
            else
            {
                SendBtn.Content = "Добавить товар";
            }

        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {

            
        }
    
}
