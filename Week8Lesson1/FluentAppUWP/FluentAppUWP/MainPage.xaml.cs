using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System.Profile;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FluentAppUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void handleBtnClick(object sender, RoutedEventArgs e)
        {
            btnClick.Content = DateTime.Now.ToString("hh:mm:ss");
        }

        private void handlePageLoaded(object sender, RoutedEventArgs e)
        {
            Style reveal = Resources.ThemeDictionaries["ButtonRevealStyle"] as Style;
            foreach ( var key in Resources.ThemeDictionaries.Keys)
            {
                System.Diagnostics.Debug.WriteLine($"Key: {key}");
            }

            foreach(Button btn in GridCalculator.Children.OfType<Button>())
            {
                btn.Style = reveal;
            }
        }
    }
}
