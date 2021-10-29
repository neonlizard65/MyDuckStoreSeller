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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyDuckStoreSeller.Classes.FormProduct
{
    /// <summary>
    /// Interaction logic for SsdInstanceCreatePage.xaml
    /// </summary>
    public partial class SsdInstanceCreatePage : Page
    {
        List<Product> allssd;
        public SsdInstanceCreatePage(ref List<Product> products)
        {
            InitializeComponent();

            allssd = (from x in products
                        where x is Ssd
                        select x).ToList();

            NameBox.ItemsSource = allssd.Select(p => p.Name);

        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
            }
            catch
            {

            }
            MessageBox.Show("Добавляем товар...");
        }

        private void NameBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataContext = allssd.First(p=> p.Name == NameBox.SelectedValue.ToString());
        }
    }
}
