using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliemania.Model
{
    class Book : Media
    {
        public string Artiste { get; private set; }
        public string Style { get; private set; }

        public Book(int id, string titre, int nbStock, string artiste, string style) : base(id, titre, nbStock)
        {
            Artiste = artiste;
            Style = style;
        }
    }
}
