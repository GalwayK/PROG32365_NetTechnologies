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

namespace Quiz2ReviewControlExercises
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        static string strValidLogin = "KyleGalway";
        static string strValidPassword = "12345678";

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void SignInClicked(object sender, RoutedEventArgs e)
        {
            string strFirstName = txtFirstName.Text;
            string strLastName = txtLastName.Text;
            string strPassword = txtPassword.Password;
            Console.WriteLine($"First Name: {strFirstName}");
            Console.WriteLine($"Last Name: {strLastName}");
            Console.WriteLine($"Password: {strPassword}");

            if ((strFirstName + strLastName).Equals(strValidLogin) && strPassword.Equals(strValidPassword)) 
            {
                this.Close();
                lblOutcome.Content = "Successfully logged in!";
            }
            else
            {
                lblOutcome.Content = "Login Unsuccessful!";
            }
        }

    }
}
