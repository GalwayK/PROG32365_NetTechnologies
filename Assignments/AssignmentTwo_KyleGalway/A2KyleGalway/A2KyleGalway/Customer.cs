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
        // Placeholder customer for when no user is signed in
        public static Customer PlaceholderCustomer = new Customer("No Customer Selected", "", "", "", "", "", "", "");

        // Lists to provide viable payment types
        public static List<string> GetListPaymentTypes()
        {
            List<string> listPaymentTypes = new List<string>()
            {
                "Cash", "Master Card", "Visa Card", "Amex Card" 
            };

            return listPaymentTypes;
        }

        // Getters and Setters for Customer properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; } 
        public string Province { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        // Getter for concatenating first and last name
        public string FullName
        { 
            get => FirstName + " " + LastName;
        }

        // Getter for retieving string to display list
        public string CustomerDisplay
        {
            get => $"#{Id}. {FullName}";
        }

        // Blank setter for object binding
        public Customer()
        {
        }

        // Constructor for providing fields to new object instances
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
