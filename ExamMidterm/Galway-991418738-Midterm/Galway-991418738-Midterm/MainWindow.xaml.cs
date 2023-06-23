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

namespace Galway_991418738_Midterm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static BookStore bookStore = BookStore.BookStoreFactory();

        public MainWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void QuitApplication(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void StartApplication(object sender, RoutedEventArgs e)
        {
            BookManagement bookManagement = new BookManagement();
            bookManagement.ResizeMode = ResizeMode.NoResize;
            this.Hide();
            bookManagement.ShowDialog();
            if (bookManagement.continueApplication)
            {
                this.Show();
            }
            else
            {
                this.Close();
            }
        }
    }
}
