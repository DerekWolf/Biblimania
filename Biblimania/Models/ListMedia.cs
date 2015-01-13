using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblimania.Models
{
    static class ListMedia : List<Media>
    {
        static private List<Media> Medias { get; private set; }

        static public void Initialize() {
            Medias = new List<Media>();
        }

        static public void Initialize(List<Media> medias)
        {
            Medias = medias;
        }

        static public void Add(Media media)
        {
            Medias.Add(media);
        }

        static public void Remove(Media media)
        {
            Medias.Remove(media);
        }

        static public Media Get(int index)
        {
            return Medias[index];
        }

        static public Media First()
        {
            return Medias.First<Media>();
        }

        static public Media Last()
        {
            return Medias.Last<Media>();
        }

    }
}
