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

namespace MouseEvents
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

        private void btnClick_Click(object sender, RoutedEventArgs e)
        {
            if (slider.Value > slider.Minimum)
            {
                slider.Value = slider.Value - slider.TickFrequency;
            }
           
        }

        private void btnTouch_Entered(object sender, MouseEventArgs e)
        {
            if (slider.Value < slider.Maximum)
            {
                slider.Value = slider.Value + slider.TickFrequency;
            }
        }

        private void windowLoaded(object sender, RoutedEventArgs e)
        {
            mainLabel.Content = "The page is loaded!";
        }

        private void leftMouseUp(object sender, MouseButtonEventArgs e)
        {
            mainLabel.Content = "Left mouse clicked!";
        }

        private void rightMouseUp(object sender, MouseButtonEventArgs e)
        {
            mainLabel.Content = "Right mouse clicked!";
        }

        private void windowLoseFocus(object sender, MouseButtonEventArgs e)
        {
            mainLabel.Content = "Window not in focus!";
        }

        private void windowGainFocus(object sender, MouseButtonEventArgs e)
        {
            mainLabel.Content = "Window in focus!";
        }

        private void showMousePosition(object sender, MouseEventArgs e)
        {
            Point point = e.GetPosition(this);
            mouseLabel.Content = $"The mouse position is: {point.ToString()}";
        }
    }
}
