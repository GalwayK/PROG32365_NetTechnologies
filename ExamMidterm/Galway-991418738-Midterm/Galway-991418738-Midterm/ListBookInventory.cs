using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galway_991418738_Midterm
{
    internal class ListBookInventory: List<Book>, INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        // Implement custom overloaded behaviour for searching for specific ISBN
        public bool Contains(int isbn)
        {
            bool containsIsbn = false;
            Action<Book> GenerateContainsISBNAction()
            {
                void SearchForISBNAction(Book book) 
                { 
                    if (book.ISBN == isbn)
                    {
                        containsIsbn = true;
                    }
                }
                return SearchForISBNAction;
            }

            this.ForEach(GenerateContainsISBNAction());
            return containsIsbn;
        }

        public new void Add(Book book) 
        { 
            base.Add(book);
            CollectionChanged?.Invoke(this, new 
                NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, book));
        }

        public new void Remove(Book book) 
        { 
            base.Remove(book);
            CollectionChanged?.Invoke(this, new 
                NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, book));
        }
    }
}
