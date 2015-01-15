using Biblimania.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblimania.Models
{
    abstract class Media : IMedia
    {
        static public event EventHandler Borrowed;

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

        protected virtual void OnBorrowed(EventArgs e)
        {
            if (Borrowed != null)
            {
                Borrowed(this, e);
            }
        }

        public void Borrow()
        {
            NombreEnStock--;
            OnBorrowed(EventArgs.Empty);
        }

        public void BringBack()
        {
            NombreEnStock++;
        }

        public virtual string ToString()
        {
            return "Media " + Identifiant + ", " + Titre + ", " + NombreEnStock + " en stock.";
        }
    }
}
