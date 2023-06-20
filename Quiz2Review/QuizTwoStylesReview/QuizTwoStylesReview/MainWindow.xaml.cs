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

namespace QuizTwoStylesReview
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Console.WriteLine(this.Title);
            Console.WriteLine(this.WindowStyle);
            Console.WriteLine(this.Content);
            Console.WriteLine(this.Foreground);
            Console.WriteLine(this.Background);
            InitializeComponent();
            MessageBox.Show("Hello", "There");
        }

        private void mouseEnterEvent(object sender, MouseEventArgs e)
        {
            Label theActualSenderYouGarbageFramework = (Label)sender;
            Console.WriteLine(theActualSenderYouGarbageFramework.Content);
            BrushConverter whyDoesThisExist = new BrushConverter();

            StackLabel.Background = (Brush)whyDoesThisExist.ConvertFrom(theActualSenderYouGarbageFramework.Content);

            lblLastAction.Content = $"{theActualSenderYouGarbageFramework.Name} hovered.";
            ListBox box = new ListBox();
        }

        private void RadioClicked(object sender, RoutedEventArgs e)
        {
            RadioButton theButton = (RadioButton)sender;    
            lblLastAction.Content = $"{theButton.Name} clicked.";
        }

        private void ResetAll(object sender, RoutedEventArgs e)
        {
            BrushConverter whyDoesThisExist = new BrushConverter();
            SolidColorBrush brush = new SolidColorBrush();
            StackLabel.Background = (Brush)whyDoesThisExist.ConvertFrom("white");
            radioBlue.IsChecked = false;
            radioGreen.IsChecked = false;
            radioRed.IsChecked = false;

            lblLastAction.Content = "All Styles Reset";
        }





        /*        private void displayMessage(object sender, RoutedEventArgs e)
                {
                    MessageBox.Show("The Window is Loaded!", 
                        "Window Loaded", 
                        MessageBoxButton.OK, 
                        MessageBoxImage.Exclamation);
                }*/
    }
}
