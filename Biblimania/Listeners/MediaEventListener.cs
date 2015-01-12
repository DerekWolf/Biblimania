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
        private Media _media;

        public MediaEventListener(Media media)
        {
            _media = media;
            _media.Borrowed += new EventHandler(MediaBorrowed);
            _media.BrangBack += new EventHandler(MediaBrangBack);
        }

        private void MediaBorrowed(object sender, EventArgs e)
        {
            Media media = sender as Media;
            Console.WriteLine("Emprunté : {0}", media.ToString());
        }

        private void MediaBrangBack(object sender, EventArgs e)
        {
            Media media = sender as Media;
            Console.WriteLine("Ramené : {0}", media.ToString());
        }
    }
}
