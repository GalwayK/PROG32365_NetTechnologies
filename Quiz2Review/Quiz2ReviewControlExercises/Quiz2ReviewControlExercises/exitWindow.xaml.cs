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
using System.Windows.Shapes;

namespace Quiz2ReviewControlExercises
{
    /// <summary>
    /// Interaction logic for exitWindow.xaml
    /// </summary>
    public partial class exitWindow : Window
    {
        public bool StayInApp
        {
            get;
            set;
        }

        public exitWindow()
        {
            StayInApp = true;
            InitializeComponent();
        }



        private void stayInApplication(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void exitApplication(object sender, RoutedEventArgs e)
        {
            StayInApp = false;
            this.Close();
        }
    }
}
