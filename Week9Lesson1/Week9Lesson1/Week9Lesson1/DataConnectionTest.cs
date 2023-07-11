using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week9Lesson1
{
    internal class DataConnectionTest
    {

        public DataConnectionTest(string strConnection)
        {
            StrConnection = strConnection;
        }

            public string StrConnection
        {
            get;
            set;
        }
    }
}
