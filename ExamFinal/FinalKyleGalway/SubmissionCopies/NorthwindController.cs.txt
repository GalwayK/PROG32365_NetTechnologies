using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalKyleGalway
{
    public class NorthwindController
    {
        private NorthwindRepository _dataRepository = new NorthwindRepository();
        private static NorthwindController _dataController = new NorthwindController();

        // Get All Products from Repository
        public DataView GetAllProducts()
        {
            return DataRepository.ReadAllProducts().DefaultView;
        }

        // Get all Products with Category ID from Repository
        public DataView GetProductsByCategoryId(int categoryId)
        {
            return DataRepository.ReadProductsByCategoryId(categoryId).DefaultView;
        }

        // Get Products by name from Repository
        public DataView GetProductsByName(string productName)
        {
            return DataRepository.ReadProductsByProductName(productName).DefaultView;
        }

        // Add new Product through Repository
        public int AddProduct(string name, decimal price, int categoryId)
        {
            return DataRepository.CreateProduct(name, price, categoryId);
        }

        // Get all Categories from Repository
        public List<Category> GetAllCategories()
        {
            return DataRepository.ReadAllCategories();
        }

        // Private Controller to disallow multiple instances
        private NorthwindController()
        {
        }

        // Private Repository to disallow misc Database Access
        private NorthwindRepository DataRepository
        {
            get => _dataRepository;
        }

        public static NorthwindController DataController
        {
            get => _dataController;
        }
    }
}
