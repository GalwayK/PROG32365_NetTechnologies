using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace A2KyleGalway
{
    public class Customer
    {
        private static int numCustomers = 0;
        public static Customer PlaceholderCustomer = new Customer("", "", "", "", "", "", "", "");

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; } 
        public string Province { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CardNumber { get; set; }  

        public string FullName
        { 
            get => FirstName + " " + LastName;
        }

        public string CustomerDisplay
        {
            get => $"{Id}. {FullName}";
        }

        public Customer()
        {
            Id = numCustomers++;
        }

        public Customer(string firstName, string lastName, string address, string postalCode, string phoneNumber, 
            string province = "", string city = "", string email = "")
        {
            Id = numCustomers++;
            FirstName = firstName;
            LastName = lastName;    
            Address = address;
            Province = province;
            City = city;
            Email = email;
            PostalCode = postalCode;
            PhoneNumber = phoneNumber;
        }
    }
}
