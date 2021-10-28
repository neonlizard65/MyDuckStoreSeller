using MyDuckStoreSeller.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Text.Json;


namespace MyDuckStoreSeller.LoginForm
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public Seller seller; //Аккаунт продавца, глобальная переменная
        public LoginPage()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Добавить объект класса Seller
            bool login = Authenticate();

            if (login)
            {
                MainWindow mw = new MainWindow(seller);
                mw.Show();
                LoginWindowManager.loginWindow.Close();
            }
            else
            {
                IncorrectLogin.Visibility = Visibility.Visible;
            }    
        }
           
        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            LoginFrameManager.loginFrame.Navigate(new RecoverPass());
        }

        private bool Authenticate()
        { 
            using (WebClient client = new WebClient())
            {
                try
                {
                    string s;
                    //Почта
                    if (SellerLogin.Text.Contains('@'))
                    {
                        s = client.DownloadString("http://myduckstudios.fvds.ru/api/controllers/seller/read_one_email.php?Email=" + StripHTML(SellerLogin.Text));
                    }
                    else
                    {
                        s = client.DownloadString("http://myduckstudios.fvds.ru/api/controllers/seller/read_one_phone.php?Phone=" + StripHTML(SellerLogin.Text));
                    }
                    seller = JsonSerializer.Deserialize<Seller>(s);
                    if(BCrypt.Net.BCrypt.Verify(SellerPass.Password, seller.Password))
                    {
                        return true;
                    } 
                }
                catch
                {
                    IncorrectLogin.Visibility = Visibility.Visible;
                }
            }
            return false;
        }

        public static string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }

        private void TextBlock_PreviewMouseDown_1(object sender, MouseButtonEventArgs e)
        {
            LoginFrameManager.loginFrame.Navigate(new Register());
        }
    }
}
