using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliemania.Model
{
    abstract class Media
    {
        protected int Identifiant;
        protected string Titre;
        protected int NombreEnStock;

        public Media(int Id, string titre, int nmbStock)
        {
            Identifiant = Id;
            Titre = titre;
            NombreEnStock = nmbStock;
        }
    }
}
