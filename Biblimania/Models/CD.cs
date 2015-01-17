using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblimania.Models
{
    class CD : Media
    {
        public string Artist { get; private set; }
        public string Style { get; private set; }

        public CD(string titre, uint nbStock, string artiste, string style) : base(titre, nbStock)
        {
            Artist = artiste;
            Style = style;
        }

        public override string ToString()
        {
            return "CD " + Identifiant + ", " + Title + ", " + Stock + " en stock, par " + Artist + ", Style : " + Style;
        }
    }
}
