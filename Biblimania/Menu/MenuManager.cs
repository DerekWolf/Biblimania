using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblimania.Menu
{
    class MenuManager
    {
        public List<MenuAction> Action { get; private set; }

        public MenuManager()
        {
            // Liste d'ations possibles
            Action = new List<MenuAction>();
            Action.Add(DoSomething(ListerTout, "Lister tout."));
            Action.Add(DoSomething(RechercherLivre, "Rechercher un livre."));
            Action.Add(DoSomething(RechercherCD, "Rechercher un CD."));
            Action.Add(DoSomething(EmprunterLivre, "Emprunter un livre."));
            Action.Add(DoSomething(RamenerLivre, "Ramener un livre."));
            Action.Add(DoSomething(AjouterLivre, "Ajouter un livre."));
            Action.Add(DoSomething(AjouterCD, "Ajouter un CD."));
            Action.Add(DoSomething(SupprimerLivre, "Supprimer un livre."));
            Action.Add(DoSomething(SupprimerCD, "Supprimer un CD."));
        }

        public delegate MenuAction Act(String desc);

        public MenuAction DoSomething(Act act, String desc)
        {
            return act(desc);
        }

        public void Launch()
        {
            while (true)
            {
                int i = 0;

                //Liste les action dans la console
                foreach (MenuAction act in Action)
                {
                    Console.WriteLine("{0}. {1}", i, act.Description);
                    i++;
                }

                //Choix d'action
                Console.WriteLine("Entrez un numéro d'action (exit pour quitter) : ");
                string choix = Console.ReadLine();
                int Choix;

                if (choix == "exit")
                {
                    break;
                }
                else if (int.TryParse(choix, out Choix))
                {
                    Choix = int.Parse(choix);
                }
                else
                {
                    continue;
                }

                switch (Choix)
                {
                    case 0:
                        Action[0].ActionToDo.Invoke();
                        break;
                    case 1:
                        Action[1].ActionToDo.Invoke();
                        break;
                    case 2:
                        Action[2].ActionToDo.Invoke();
                        break;
                    case 3:
                        Action[3].ActionToDo.Invoke();
                        break;
                    case 4:
                        Action[4].ActionToDo.Invoke();
                        break;
                    case 5:
                        Action[5].ActionToDo.Invoke();
                        break;
                    case 6:
                        Action[6].ActionToDo.Invoke();
                        break;
                    case 7:
                        Action[7].ActionToDo.Invoke();
                        break;
                    case 8:
                        Action[8].ActionToDo.Invoke();
                        break;
                    default:
                        Console.WriteLine("Choix erroné.");
                        break;
                }
            }

            // Attend input user pour terminer
            Console.ReadLine();
        }

        private MenuAction ListerTout(String desc)
        {
            return new MenuAction(desc, () => { });
        }

        private MenuAction AjouterLivre(String desc)
        {
            return new MenuAction(desc, () => { });
        }

        private MenuAction AjouterCD(String desc)
        {
            return new MenuAction(desc, () => { });
        }

        private MenuAction SupprimerLivre(String desc)
        {
            return new MenuAction(desc, () => { });
        }

        private MenuAction SupprimerCD(String desc)
        {
            return new MenuAction(desc, () => { });
        }

        private MenuAction RechercherLivre(String desc)
        {
            return new MenuAction(desc, () => { });
        }

        private MenuAction RechercherCD(String desc)
        {
            return new MenuAction(desc, () => { });
        }

        private MenuAction EmprunterLivre(String desc)
        {
            return new MenuAction(desc, () => { });
        }

        private MenuAction RamenerLivre(String desc)
        {
            return new MenuAction(desc, () => { });
        }
    }
}
