using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliemania.Model
{
    class CD : Media
    {
        public string Auteur { get; set; }
        public int NumeroISBN { get; set; }
        public string Genre { get; set; }

        public CD(int id, string titre, int nbStock, string auteur, int isbn, string genre) : base(id,  titre, nbStock)
        {
            Auteur = auteur;
            NumeroISBN = isbn;
            Genre = genre;
        }
    }
}
