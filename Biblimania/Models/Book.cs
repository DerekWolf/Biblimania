using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblimania.Models
{
    class Book : Media
    {
        public string Author { get; set; }
        public int ISBN { get; set; }
        public string Gender { get; set; }

        public Book(string titre, uint nbStock, string auteur, int isbn, string genre) : base(titre, nbStock)
        {
            Author = auteur;
            ISBN = isbn;
            Gender = genre;
        }

        public override string ToString()
        {
            return "Livre " + Identifiant + ", " + Title + ", " + Stock + " en stock, de " + Author + ", ISBN : " + ISBN + ", Genre : " + Gender;
        }
    }
}
