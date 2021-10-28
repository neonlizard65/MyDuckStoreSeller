﻿using MyDuckStoreSeller.Classes;
using MyDuckStoreSeller.LoginForm;
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

namespace MyDuckStoreSeller
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.myduckstudios.fvds.ru/EULA.pdf");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if(FIOBox.Text != "")
            {
                if (EmailBox.Text.Contains('@')) 
                {
                    if (EmailBox.Text.Length > 5)
                    {
                        if (AdressBox.Text != "")
                        {
                            if (PhoneBox.Text != "")
                            {
                                if (INNBox.Text != "")
                                {
                                    if (PassBox.Password != "")
                                    {
                                        if (Pass2Box.Password != "")
                                        {
                                            if (PassBox.Password == Pass2Box.Password)
                                            {
                                                if (TermsBox.IsChecked == true)
                                                {
                                                    RegisterSeller();
                                                }
                                                else
                                                {
                                                    errors.AppendLine("Обязательно нужно принять пользовательское соглашение.");
                                                }
                                            }
                                            else
                                            {
                                                errors.AppendLine("Повторный пароль не совпадает с исходным.");
                                            }
                                        }
                                        else
                                        {
                                            errors.AppendLine("Заполните повторно пароль.");
                                        }
                                    }
                                    else
                                    {
                                        errors.AppendLine("Введите пароль.");
                                    }
                                }
                                else
                                {
                                    errors.AppendLine("Заполните ИНН");
                                }
                            }
                            else
                            {
                                errors.AppendLine("Введите номер телефона.");
                            }
                        }
                        else
                        {
                            errors.AppendLine("Введите адрес.");
                        }
                    }
                    else
                    {
                        errors.AppendLine("Длина электронной почты должна быть больше 5 символов.");
                    }
                }
                else
                {
                    errors.AppendLine("Введен неправильный формат почты.");
                }
            }
            else
            {
                errors.AppendLine("Введите ФИО.");
            }
            if(errors.Length > 0)
                MessageBox.Show(errors.ToString(), "Ошибка добавления");
        }

        private void RegisterSeller()
        {
            string newpass = BCrypt.Net.BCrypt.HashPassword(PassBox.Password);
            Seller newseller = new Seller("", FIOBox.Text, EmailBox.Text, PhoneBox.Text, AdressBox.Text, Convert.ToInt32(StorageBox.IsChecked).ToString(), newpass, INNBox.Text);
            using (var client = new WebClient())
            {
                try
                {
                    var s = JsonSerializer.Serialize<Seller>(newseller);
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    client.UploadString(new Uri("http://myduckstudios.fvds.ru/api/controllers/seller/create.php"), "POST", s);
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.ToString(), "Ошибка добавления");
                }
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            LoginFrameManager.loginFrame.GoBack();
        }
    }
}
