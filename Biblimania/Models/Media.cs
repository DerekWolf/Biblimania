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
        public event EventHandler Borrowed;
        public event EventHandler BrangBack;

        protected int Identifiant;
        protected string Titre;
        protected int NombreEnStock;

        private MediaEventListener Listener { get; set; }

        public Media(int id)
        {
            Identifiant = id;

            StartListening();
        }

        public Media(int id, string titre, int nmbStock)
        {
            Identifiant = id;
            Titre = titre;
            NombreEnStock = nmbStock;

            StartListening();
        }

        private void StartListening()
        {
            Listener = new MediaEventListener(this);
        }

        protected virtual void OnBorrowed(EventArgs e)
        {
            if (Borrowed != null)
            {
                Borrowed(this, e);
            }
        }

        protected virtual void OnBrangBack(EventArgs e)
        {
            if (BrangBack != null)
            {
                BrangBack(this, e);
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
            OnBrangBack(EventArgs.Empty);
        }

        public virtual string ToString()
        {
            return "Media " + Identifiant + ", " + Titre + ", " + NombreEnStock + " en stock.";
        }
    }
}
