using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using Biblimania.Listeners;

namespace Biblimania.Connection
{
    static class ConnectionManager
    {
        public static String ConnectionString
        {
            get
            {
                Program.appLogger.Write(AppLogger.TypeError.Info, "Accessing the database");
                return ConfigurationManager.ConnectionStrings["MainDatabaseConnectionString"].ConnectionString;
            }
        }
    }
}
