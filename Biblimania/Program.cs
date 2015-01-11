using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using Biblimania.Menu;
using Biblimania.Logs;

namespace Biblimania
{
    class Program
    {
        // Set the logger (the path can be absolute or relative)
        static public AppLogger appLoger = new AppLogger("error.log");

        static void Main(string[] args)
        {
            try
            {
                MenuManager mm = new MenuManager();
                mm.Launch();
            }
            catch (Exception e)
            {
                appLoger.Write(AppLogger.TypeError.Error, e.Message, e.Source);
            }
        }
    }
}
