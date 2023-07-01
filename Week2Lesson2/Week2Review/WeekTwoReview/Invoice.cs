using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekTwoReview
{
    public class Invoice
    {
        private int _quantity = 0;
        private decimal _price = 0.0M;

        private Invoice(string part, string type, int quantity, decimal price) 
        {
            Part = part;
            Type = type;
            Quantity = quantity;   
            Price = price;
        }

        public static Invoice CreateInvoice(string part, string type, int quantity, decimal price)
        {
            return (quantity > 0 && price > 0) 
                ? new Invoice(part, type, quantity, price) 
                : null;
        }

        public string Part
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        public int Quantity
        {
            get => this._quantity;
            set => this._quantity = value > 0 ? value : this._quantity;
            
        }

        public decimal Price
        {
            get => this._price; 
            set => this._price = value > 0 ? value : this._price;
        }

        public decimal InvoiceAmount
        {
            get => Quantity * Price;
        }

        public override string ToString()
        {
            return $"Part: {Part} Type: {Type} Quantity: {Quantity} Price: {Price} Total: {InvoiceAmount}";
        }
    }
}
