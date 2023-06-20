using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

/*
 * Midterm Assignment
 * Name: Kyle Galway
 * ID: 991418738
 * This is the main controller class for accessing Book data
*/

namespace Galway_991418738_Midterm
{
    internal class Book: IComparable<Book>, INotifyPropertyChanged
    {
        private string _author;
        private string _title;
        private string _genre;
        private decimal _price;
        private int _isbn;

        public event PropertyChangedEventHandler PropertyChanged;

        public Book(string title, string author, string genre, int isbn, decimal price)
        {
            ISBN = isbn;
            Price = price;
            Title = title;
            Author = author;
            Genre = genre;
        }

        public string Title
        {
            get;
            set;
        }

        public string Author
        {
            get;
            set;
        }

        public string Genre
        {
            get;
            set;    
        }

        public int ISBN
        {
            get => _isbn;
            set
            {
                if (value >= 0) 
                { 
                    _isbn  = value;
                }
                else
                {
                    throw new ArgumentException("Error: ISBN cannot be negative!");
                }
            }
        }

        public decimal Price
        {
            get => _price; 
            set
            {
                if (value >= 0)
                {
                    _price = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
                }
                else
                {
                    throw new ArgumentException("Error: Price cannot be negative!");
                }
            }
        }

        public static bool operator > (Book bookOne, Book bookTwo)
        {
            return bookOne.Price > bookTwo.Price;
        }

        public static bool operator < (Book bookOne, Book bookTwo)
        {
            return bookOne.Price < bookTwo.Price;
        }

        public override bool Equals(object obj)
        {
            if (obj is Book)
            {
                Book book = obj as Book;
                return book.Price == this.Price;
            }
            return false;
        }

        public static bool operator >= (Book bookOne, Book bookTwo)
        {
            return bookOne.Price >= bookTwo.Price;
        }

        public static bool operator <= (Book bookOne, Book bookTwo)
        {
            return bookOne.Price <= bookTwo.Price;
        }

        public int CompareTo(Book book)
        {
            return this > book 
                ? 1
                : this < book 
                    ? -1 
                    : 0;
        }

        public bool IsSameBook(Book that)
        {
            return this.Author.Equals(that.Author) && this.Author.Equals(that.Author);
        }

        public override string ToString()
        {
            return $"Title: {Title} Author: {Author} Genre: {Genre} ISBN: {ISBN}";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
