using MyDuckStoreSeller.LoginForm;
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

namespace MyDuckStoreSeller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            LoginWindowManager.loginWindow = (LoginWindow)Application.Current.Windows[0];
            LoginFrameManager.loginFrame = LoginFrame;
            LoginFrame.Navigate(new LoginPage());
        }

        private void Image_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.myduckstudios.fvds.ru");
        }
    }
}
