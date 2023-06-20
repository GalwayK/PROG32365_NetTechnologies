using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

namespace Galway_991418738_Midterm
{
    /// <summary>
    /// Interaction logic for BookManagement.xaml
    /// </summary>
    public partial class BookManagement : Window
    {
        public bool continueApplication = false;

        private static BookStore bookStore = BookStore.BookStoreFactory();
        public BookManagement()
        {
            InitializeComponent();
        }

        // Function for initializing all default values in window.
        private void InitializeWindow(object sender, RoutedEventArgs e)
        {
            continueApplication = false;
            gridData.ItemsSource = bookStore.GetInventory();
            gridSearchedData.ItemsSource = null;
        }


        private void SearchByGenre(object sender, RoutedEventArgs e)
        {
            string strGenre = txtSearchInputGenre.Text;

            List<Book> searchedBooks = bookStore.SearchInventoryByGenre(strGenre);

            string status = $"Could not find books of genre {strGenre}";
            if (searchedBooks.Count > 0)
            {
                gridSearchedData.ItemsSource = searchedBooks;
                status = $"Found books of genre {strGenre}";
            }
            lblStatus.Content = status;
            ClearSearchText();
        }

        private void SearchByAuthor()
        {
            string strAuthor = txtSearchInputAuthor.Text.ToLower();
            string status = "Error: Author name not valid";

            if (strAuthor.Length > 0)
            {
                List<Book> searchedBooks = bookStore.SearchInventoryByAuthor(strAuthor);
                status = $"Could not find books by {strAuthor}";
                if (searchedBooks.Count > 0)
                {
                    gridSearchedData.ItemsSource = searchedBooks;
                    status = $"Found books by {strAuthor}";
                }
                gridSearchedData.ItemsSource = searchedBooks;
            }
            lblStatus.Content = status;
            ClearSearchText();
        }

        private void SearchByAuthor(object sender, RoutedEventArgs e)
        {
            SearchByAuthor();
        }

        private void SearchByAuthor(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) 
            {
                SearchByAuthor();
            }
        }

        private void InsertNewBook(object sender, RoutedEventArgs e)
        {
            string strTitle = "";
            string strAuthor = "";
            string strGenre = "";
            decimal monPrice = 0.0M;
            int isbn = 0;

            bool IsInputValid()
            {
                bool isInputValid = false;
                try
                {
                    strTitle = txtInsertTitle.Text;
                    strAuthor = txtInsertAuthor.Text;
                    strGenre = txtInsertGenre.Text;
                    monPrice = Convert.ToDecimal(txtInsertPrice.Text);
                    isbn = Convert.ToInt32(txtInsertISBN.Text);

                    Console.WriteLine(strTitle);
                    Console.WriteLine(strAuthor);
                    Console.WriteLine(strGenre);
                    Console.WriteLine(monPrice);
                    Console.WriteLine(isbn);

                    bool isTitleValid = strTitle.Length > 0;
                    bool isAuthorValid = strAuthor.Length > 0;
                    bool isGenreValid = strGenre.Length > 0;
                    bool isPriceValid = monPrice > BookStore.BOOK_MIN_PRICE && monPrice < BookStore.BOOK_MAX_PRICE;
                    bool isISBNValid = isbn > 0;

                    isInputValid = isTitleValid && isAuthorValid && isGenreValid && isPriceValid && isISBNValid;

                }
                catch (Exception) { }
                return isInputValid;
            }

            BookStore.StatusNumber statusNumber;

            if (IsInputValid() ) 
            {
                Console.WriteLine("Trying to Insert!");
                statusNumber = bookStore.AddBookToInventory(strTitle, strAuthor, strGenre, isbn, monPrice);
            }
            else
            {
                Console.WriteLine("Can't insert for some reason!");
                statusNumber = BookStore.StatusNumber.INSERT_ERROR;
            }
            lblStatus.Content = BookStore.GetStatusMessage(statusNumber);
            ClearInsertText();
        }

        private void RevealEditInformationMouseEvent(object sender, RoutedEventArgs e)
        {
            RevealEditInformation();
        }

        private void RevealEditInformationKeyEvent(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) 
            {
                RevealEditInformation();
            }
        }

        private void RevealEditInformation()
        {
            EditInnerGrid.Opacity = 0;
            bool isISBNValid = false;
            string status = "No matching book found";
            int isbn = 0;

            void RevealEditInformation(Book book)
            {
                if (book != null)
                {
                    txtEditAuthor.Text = book.Author;
                    txtEditTitle.Text = book.Title;
                    txtEditGenre.Text = book.Genre;
                    txtEditPrice.Text = book.Price.ToString();

                    status = $"Found book with ISBN {isbn}";
                    EditInnerGrid.Opacity = 1;
                }
            }

            try
            {
                isbn = Convert.ToInt32(txtEditISBN.Text);
                isISBNValid = isbn > 0;
            }
            catch
            {
                status = "ISBN must be a number";
            }

            if (isISBNValid)
            {
                Book searchedBook = bookStore.GetBookByISBN(isbn);
                RevealEditInformation(searchedBook);
            }
            else
            {
                status = "ISBN invalid";
            }
            lblStatus.Content = status;
        }

        private void UpdateBook(object sender, RoutedEventArgs e)
        {
            string status = "Invalid input";
            int? isbn = 0;
            decimal? monPrice = 0.0M;
            bool IsInputValid()
            {
                bool isPriceValid = false;
                bool isISBNValid = false;
                bool isInputValid = false;

                monPrice = Convert.ToDecimal(txtEditPrice.Text);
                isPriceValid = monPrice != null && monPrice > BookStore.BOOK_MIN_PRICE && monPrice < BookStore.BOOK_MAX_PRICE;

                isbn = Convert.ToInt32(txtEditISBN.Text);
                isISBNValid = isbn != null && isbn > 0;

                isInputValid = isPriceValid && isISBNValid;

                return isInputValid;
            }

            BookStore.StatusNumber statusNumber;
            if (IsInputValid()) 
            {
                statusNumber = bookStore.UpdateBook((int)isbn, (decimal)monPrice);
                status = BookStore.GetStatusMessage(statusNumber);
            }
            else
            {
                statusNumber = BookStore.StatusNumber.UPDATE_ERROR;
                status = BookStore.GetStatusMessage(statusNumber);
            }
            lblStatus.Content = status;
            ClearEditText();
        }

        private void DeleteBook(object sender, RoutedEventArgs e)
        {
            string status = "ISBN Invalid";
            BookStore.StatusNumber statusNumber;

            if (IsTextValidISBN(txtDeleteISBN))
            {
                int isbn = Convert.ToInt32(txtDeleteISBN.Text);
                statusNumber = bookStore.DeleteBook(isbn);
                status = BookStore.GetStatusMessage(statusNumber);
            }
            else
            {
                statusNumber = BookStore.StatusNumber.DELETION_ERROR;
                status = BookStore.GetStatusMessage(statusNumber);
            }
            lblStatus.Content = status;
            ClearDeleteText();
        }

        private bool IsTextValidISBN(TextBox txtIsbn)
        {
            int? isbn = Convert.ToInt32(txtIsbn.Text);
            return isbn != null && isbn > 0;
        }

        private bool IsTextValidPrice(TextBox txtPrice)
        {
            decimal? monPrice = Convert.ToDecimal(txtPrice.Text);
            return monPrice != null && monPrice > BookStore.BOOK_MIN_PRICE && monPrice < BookStore.BOOK_MAX_PRICE;
        }

        private void FocusShowTab(object sender, RoutedEventArgs e)
        {
            TabShow.Focus();
            ClearAllText();
        }

        private void FocusSearchTab(object sender, RoutedEventArgs e)
        {
            TabSearch.Focus();
            ClearAllText();
        }

        private void FocusInsertTab(object sender, RoutedEventArgs e)
        {
            TabInsert.Focus();
            ClearAllText();
        }

        private void FocusEditTab(object sender, RoutedEventArgs e)
        {
            TabEdit.Focus();
            ClearAllText();
        }

        private void FocusDeleteTab(object sender, RoutedEventArgs e)
        {
            TabDelete.Focus();
            ClearAllText();
        }

        private void Return(object sender, RoutedEventArgs e)
        {
            continueApplication = true;
            this.Close();
        }

        private void QuitApplication(object sender, RoutedEventArgs e)
        {
            continueApplication = false;
            this.Close();
        }

        void ClearSearchText()
        {
            txtSearchInputAuthor.Text = string.Empty;
            txtSearchInputGenre.Text = string.Empty;
        }


        void ClearEditText()
        {
            txtDeleteISBN.Text = string.Empty;
            txtEditAuthor.Text = string.Empty;
            txtEditPrice.Text = string.Empty;
            txtEditTitle.Text = string.Empty;
            txtEditISBN.Text = string.Empty;
        }

        void ClearDeleteText()
        {
            txtDeleteISBN.Text = string.Empty;
        }

        void ClearInsertText()
        {
            txtInsertAuthor.Text = string.Empty;
            txtInsertPrice.Text = string.Empty;
            txtInsertISBN.Text = string.Empty;  
            txtInsertTitle.Text = string.Empty;
            txtInsertGenre.Text = string.Empty;
        }

        void ClearAllText()
        {
            ClearEditText();
            ClearDeleteText();
            ClearInsertText();
            ClearSearchText();
        }

        private void TabChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl) 
            {
                ClearAllText();
            }
        }
    }
}
