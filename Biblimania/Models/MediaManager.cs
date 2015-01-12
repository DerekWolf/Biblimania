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
        static public List<Media> Medias { get; private set; }
        
        static public void Initialize()
        {
            Medias = GetAll();
        }

        public static void Save<T>(T media)
        {
            throw new NotImplementedException();
            // TODO
        }

        public static Media Get<T>(T media)
        {
            throw new NotImplementedException();
            // TODO
        }

        public static List<Media> GetAll()
        {
            List<Media> list = new List<Media>();

            // TODO

            return list;
        }

        public static void Remove<T>(T media)
        {
            throw new NotImplementedException();
            // TODO
        }

        public static void BringBack<T>(T media) where T : IMedia
        {
            media.BringBack();
            // TODO
        }

        public static void Borrow<T>(T media) where T : IMedia
        {
            media.Borrow();
            // TODO
        }
    }
}
