using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Biblimania.Models;

namespace Biblimania.Listeners
{
    class MediaEventListener
    {
        public MediaEventListener()
        {
            Media.Borrowed += new EventHandler(MediaBorrowed);
        }

        /// <summary>
        /// Display which Media is borrowed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MediaBorrowed(object sender, EventArgs e)
        {
            Media media = sender as Media;
            Console.WriteLine("Emprunté : {0}", media.ToString());
        }
    }
}
