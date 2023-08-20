using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToDatabaseProgramming
{
    internal class DatabaseRepository
    {
        private static string connectionString = @"Data Soure=(LocalDB)\MSSQLLocalDB; Initial Catalog=Northwind; Integrated Security=True";

        public static string ConnectionString
        {
            get => connectionString;
        }
    }
}
