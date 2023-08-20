using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalKyleGalway
{
    public class Category
    {
        // Getters for creating Category objects from database
        public int id;

        public string CategoryName;

        public string Description;

        // Factory for easy generation of Category objects with parameters
        public static Category CategoryFactory(int id, string name, string description)
        {
            Category category = new Category();
            category.id = id;
            category.Description = description;
            category.CategoryName = name;
            return category;  
        }

        // Get String to display in Application Combobox
        public override string ToString()
        {
            return $"{id}. {CategoryName}";
        }
    }
}
