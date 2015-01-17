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

        public int Identifiant { get; set; }
        public string Title { get; set; }
        public uint Stock { get; set; }

        public Media(string titre, uint nmbStock)
        {
            Title = titre;
            Stock = nmbStock;
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
            OnBorrowed(EventArgs.Empty);
        }
    }
}
