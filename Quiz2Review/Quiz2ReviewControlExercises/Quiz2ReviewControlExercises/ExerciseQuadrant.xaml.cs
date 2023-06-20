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
    /// Interaction logic for ExerciseQuadrant.xaml
    /// </summary>
    public partial class ExerciseQuadrant : Window
    {
        public ExerciseQuadrant()
        {
            InitializeComponent();
        }

        private void submitInformation(object sender, RoutedEventArgs e)
        {
            if (txtInputEmail.Text.Length > 0 && txtInputName.Text.Length > 0) 
            {
                txtDisplayEmail.Text = txtInputEmail.Text;
                txtDisplayName.Text = txtInputName.Text;
            }
        }

        private void exitWindow(object sender, RoutedEventArgs e)
        {
            exitWindow exitWindow = new exitWindow();
            exitWindow.ShowDialog();
            Console.WriteLine(exitWindow.StayInApp);
            if (!exitWindow.StayInApp) 
            {
                this.Close();
            }
        }
    }
}
