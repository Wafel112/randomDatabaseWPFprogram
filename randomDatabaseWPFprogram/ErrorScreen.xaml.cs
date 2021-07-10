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
using System.Windows.Shapes;

namespace randomDatabaseWPFprogram
{
    /// <summary>
    /// Interaction logic for ErrorScreen.xaml
    /// </summary>
    public partial class ErrorScreen : Window
    {
        public ErrorScreen(string ErrorMessage,string ErrorType,string lang)
        {
            InitializeComponent();
            ErrorMessageTextBox.Text += ErrorMessage;

            //Change Window size in way that is comfortable to read
            //Zmien wielkosc okna tak aby mozna bylo przyjemnie czytac

            switch (lang)
            {
                case "Polski":

                    switch (ErrorType)
                    {
                        case "configFile":
                            ErrorScreenWindow.Title = "Bład podczas odczytu/zapisu pliku configuracyjnego";

                            ErrorScreenWindow.Width = 800;
                            ErrorScreenWindow.Height = 650;

                            break;

                        case "credentials":
                            ErrorScreenWindow.Title = "Bład podczas logowania";
                            ErrorScreenWindow.Width = 210;
                            ErrorScreenWindow.Height = 100;

                            ErrorMessageTextBox.TextAlignment = TextAlignment.Center;

                            break;


                        case "mysql":
                            ErrorScreenWindow.Width = 800;
                            ErrorScreenWindow.Height = 650;

                            ErrorScreenWindow.Title = "Bład bazy danych";

                            break;
                        default:
                            break;
                    }


                    break;

                case "English":

                    switch (ErrorType)
                    {
                        case "configFile":
                            ErrorScreenWindow.Title = "Error while reading/saving configuration file";

                            ErrorScreenWindow.Width = 800;
                            ErrorScreenWindow.Height = 650;

                            break;

                        case "credentials":
                            ErrorScreenWindow.Title = "Error while logging in";
                            ErrorScreenWindow.Width = 210;
                            ErrorScreenWindow.Height = 100;

                            ErrorMessageTextBox.TextAlignment = TextAlignment.Center;

                            break;

                        case "mysql":
                            ErrorScreenWindow.Width = 800;
                            ErrorScreenWindow.Height = 650;

                            ErrorScreenWindow.Title = "Database error";

                            break;


                        default:
                            break;
                    }



                    break;
                default:
                    break;
            }

        }
    }
}
