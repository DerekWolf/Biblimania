using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblimania.Listeners;

namespace Biblimania.Models
{
    static class MediaManager
    {
        public static void Save<T>(T media)
        {
            ListMedia.Add(media as Media);
            // TODO Query
        }

        public static Media Get<T>(T media)
        {
            throw new NotImplementedException();
            // TODO Query
        }

        public static List<Media> GetAll()
        {
            List<Media> list = new List<Media>();
            ListMedia.Initialize(list);
            // TODO Query

            return list;
        }

        public static void Remove<T>(T media)
        {
            ListMedia.Remove(media as Media);
            // TODO Query
        }

        public static void BringBack<T>(T media) where T : IMedia
        {
            ListMedia.Remove(media as Media);
            media.BringBack();
            ListMedia.Add(media as Media);
            // TODO Query
        }

        public static void Borrow<T>(T media) where T : IMedia
        {
            ListMedia.Remove(media as Media);
            media.Borrow();
            ListMedia.Add(media as Media);
            // TODO Query
        }
    }
}
