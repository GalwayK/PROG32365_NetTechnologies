using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IWouldLikeToDie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<KillMe> listIWantToDie;

        public MainWindow()
        {
            InitializeComponent();
            listIWantToDie = new List<KillMe>()
            {
                new KillMe(0, "Nihilism", "Absurdism", "0"), 
                new KillMe(1, "I hate", "Existence", "Why"), 
                new KillMe(2, "Nothing", "Matters", "Godamnit"), 
                new KillMe(3, "There is no point", "Bleh", "Meh"), 
                new KillMe(4, "Meh", "Meh", "Meh")
            };
        }

        private void Clear_Textboxes()
        {
            textId.Text = string.Empty;
            textName.Text = string.Empty;
            textCity.Text = string.Empty;
            textPhone.Text = string.Empty;
        }

        private void Window_Refresh()
        {
            var empNames = from dead in listIWantToDie
                           select dead.Name;
            listEmployees.ItemsSource = empNames;

            Clear_Textboxes();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Window_Refresh();
        }

        private void ListKillMeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int currentIndex = listEmployees.SelectedIndex;
            
            if (listEmployees.SelectedItems.Count == 0)
            {
                return;
            }
            KillMe killMe = listIWantToDie[listEmployees.SelectedIndex];

            void updateTextFields(KillMe meKill)
            {
                textId.Text = meKill.Id.ToString();
                textName.Text = meKill.Name;
                textCity.Text = meKill.City;
                textPhone.Text = meKill.Phone;
            }

            updateTextFields(killMe);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(textId.Text);
            string name = textName.Text;
            string city = textCity.Text;    
            string phone = textPhone.Text;
            KillMe killMe = new KillMe(id, name, city, phone);
            listIWantToDie.Add(killMe);
            Window_Refresh();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(textId.Text);
            string name = textName.Text;
            string city = textCity.Text;
            string phone = textPhone.Text;

            KillMe killMe = (from kill in listIWantToDie where kill.Id == id select kill).First();
            killMe.City = city;
            killMe.Phone = phone;
            killMe.Name = name;
            Window_Refresh();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            KillMe killMe = (from kill in listIWantToDie
                            where kill.Id == Convert.ToInt32(textId.Text)
                            select kill).First();
            listIWantToDie.Remove(killMe);
            Window_Refresh();
        }
    }
}
