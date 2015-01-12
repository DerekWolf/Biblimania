using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using Biblimania.Menu;
using Biblimania.Listeners;
using Biblimania.Models;

namespace Biblimania
{
    class Program
    {
        // Set the logger (the path can be absolute or relative)
        static public AppLogger appLogger = new AppLogger("error.log");
        static public MenuManager menuManager;

        static void Main(string[] args)
        {
            try
            {
                // Retrieve all Medias available
                MediaManager.Initialize();

                menuManager = new MenuManager();
                menuManager.Launch();
            }
            catch (Exception e)
            {
                appLogger.Write(AppLogger.TypeError.Error, e.Message, e.Source);
            }
        }
    }
}
