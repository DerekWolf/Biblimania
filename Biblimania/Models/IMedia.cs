using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblimania.Models
{
    interface IMedia
    {
        void Borrow();
        void BringBack();
    }
}
