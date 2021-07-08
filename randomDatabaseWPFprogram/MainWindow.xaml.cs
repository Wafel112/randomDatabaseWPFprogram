﻿using System;
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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace randomDatabaseWPFprogram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
                
        }
        //Changing colors due to theme change
        //Zmiana kolorow ze wzgledu na zmiane motywu
        private void WhiteThemeCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            MW_Grid.Background = new SolidColorBrush(Color.FromRgb(50, 50, 50));
            WhiteThemeCheckBox.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
            WhiteThemeCheckBox.Background = new SolidColorBrush(Color.FromRgb(50, 50, 50));
            

            user_login_Label.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
            user_login_TextBox.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
            user_login_TextBox.Background = new SolidColorBrush(Color.FromRgb(50, 50, 50));

            user_password_Label.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
            user_password_TextBox.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
            user_password_TextBox.Background = new SolidColorBrush(Color.FromRgb(50, 50, 50));

            user_login_Button.Background = new SolidColorBrush(Color.FromRgb(158, 158, 158));
            user_login_Button.Foreground=  new SolidColorBrush(Color.FromRgb(50, 50, 50));

        }

        //Changing colors due to theme change
        //Zmiana kolorow ze wzgledu na zmiane motywu
        private void WhiteThemeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MW_Grid.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            WhiteThemeCheckBox.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            WhiteThemeCheckBox.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            user_login_Label.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            user_login_TextBox.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            user_login_TextBox.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            user_password_Label.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            user_password_TextBox.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            user_password_TextBox.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            user_login_Button.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            user_login_Button.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }


        //Checking login credentials
        //Sprawdzanie danych logowania
        private void user_login_Button_Click(object sender, RoutedEventArgs e)
        {
            string user_login = user_login_TextBox.Text;
            string user_password = user_password_TextBox.Password;


            string serverConnectionString = "server=localhost;user=root;database=lawfirm;port=3306;password=";
            string sqlQuery = $"SELECT COUNT(u.login) FROM users u WHERE u.login = '{user_login}' AND u.password = '{user_password}'";

            MySqlConnection sqlConnection = new MySqlConnection(serverConnectionString);


            //Trying to execute query to select user
            //Proba odczytu uzytkownika z bazy danych
            try
            {
                // MessageBox.Show(sqlQuery);
                sqlConnection.Open();

                MySqlCommand sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
                object usersResult = sqlCommand.ExecuteScalar();

                if (usersResult != null)
                {
                    int userResultToInt = Convert.ToInt32(usersResult);
                    switch (userResultToInt)
                    {
                        case 1:
                            MessageBox.Show("Logged in");
                            break;
                        case (0 or > 2):
                            MessageBox.Show("Login Failed");
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.ToString()}");
            }
            sqlConnection.Close();

        }
    }
}
