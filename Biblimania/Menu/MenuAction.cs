using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblimania.Menu
{
    class MenuAction
    {
        public String Description { get; set; }
        public Action ActionToDo { get; set; }

        public MenuAction(String desc, Action action)
        {
            Description = desc;
            ActionToDo = action;
        }
    }
}
