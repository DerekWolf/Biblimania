using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Biblimania.Connection
{
    static class ConnectionManager
    {

        public static String ConnectionString = ConfigurationManager.ConnectionStrings["MainDatabaseConnectionString"].ConnectionString;
    }
}
