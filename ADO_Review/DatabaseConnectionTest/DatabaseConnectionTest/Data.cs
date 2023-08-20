using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectionTest
{
    internal class Data
    {
        private static string connStr = @"Data Source = (localdb)\MSSQLLocalDB;
            Initial Catalog = Northwind;
        Integrated Security = True;";
        public string ConnectionStr { get=>connStr; }
    }
}
