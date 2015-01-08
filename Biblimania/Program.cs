using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using Biblimania.Menu;
using Biblimania.Connection;
using Bibliemania.Model;

namespace Biblimania
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuManager mm = new MenuManager();
            mm.Launch();
        }
    }
}
