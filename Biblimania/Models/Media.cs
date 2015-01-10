using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblimania.Models
{
    abstract class Media
    {
        protected int Identifiant;
        protected string Titre;
        protected int NombreEnStock;

        public Media(int id)
        {
            Identifiant = id;
        }

        public Media(int id, string titre, int nmbStock)
        {
            Identifiant = id;
            Titre = titre;
            NombreEnStock = nmbStock;
        }

        public virtual string ToString()
        {
            return "Media " + Identifiant + ", " + Titre + ", " + NombreEnStock + " en stock.";
        }
    }
}
