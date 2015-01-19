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
using Biblimania.Connection;

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
                Data.CreateDataset();
                Data.FillDataSet();

                // Initialize the Borrowed listener
                MediaEventListener listener = new MediaEventListener();

                menuManager = new MenuManager();
                menuManager.Launch();

                // Done before closing
                Data.UpdateDB();
            }
            catch (Exception e)
            {
                // Log the error, display a short message and wait for an input
                appLogger.Write(AppLogger.TypeError.Error, e.Message, e.Source);
                Console.WriteLine("{0} L'application  va maintenant se fermer.", e.Message);
                Console.ReadLine();
            }
        }
    }
}
