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
    public partial class SsdCreatePage : Page
    {
        List<Product> allproducts;
        KeyValuePair<Instance, Product> curproduct;
        ManufacturerList allmanufacturers;

        public SsdCreatePage(KeyValuePair<Instance, Product> product, List<Product> allproducts, ManufacturerList allmanufacturers)
        {
            InitializeComponent();

            //Для глоб. переменных
            this.allproducts = allproducts;
            curproduct = product;
            this.allmanufacturers = allmanufacturers;

            NameBox.ItemsSource = allproducts.Select(p => p.Name).ToList();
            ManufacturerBox.ItemsSource = allmanufacturers.manufacturer.Select(m => m.ManufacturerName);

            if (product.Value != null)
            {
                SendBtn.Content = "Обновить товар";
                DataContext = product;
                NameBox.SelectedItem = product.Value.Name;
                ManufacturerBox.SelectedItem = product.Value.ManufacturerName;
            }
            else
            {
                SendBtn.Content = "Добавить товар";
            }

        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            KeyValuePair<Instance, Product> newproduct = new KeyValuePair<Instance, Product>(curproduct.Key, new Ssd(null, null, (allmanufacturers.manufacturer.First(p => p.ManufacturerName == ManufacturerBox.SelectedItem)).ManufacturerID, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null));
            
            if ()
            {
                //create
                var result = MessageBox.Show("Изменение названия или кода производителя создаст новый вид товара.", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                if (result == MessageBoxResult.OK)
                {

                }
            }
            else
            {
               //update
            }
        }

        private void NameBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                KeyValuePair<Instance, Product> newproduct = new KeyValuePair<Instance, Product>(curproduct.Key, allproducts.First(p => p.Name == NameBox.SelectedItem));
                DataContext = newproduct;
            }
            catch
            {

            }
        }
    }
}
