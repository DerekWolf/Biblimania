using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblimania.Models;

namespace Biblimania.Menu
{
    class MenuManager
    {
        public List<MenuAction> Action { get; private set; }

        public MenuManager()
        {
            // Liste d'ations possibles
            Action = new List<MenuAction>();
            Action.Add(DoSomething(ListAll, "Lister tout."));
            Action.Add(DoSomething(SearchBook, "Rechercher un livre."));
            Action.Add(DoSomething(SearchCD, "Rechercher un CD."));
            Action.Add(DoSomething(BorrowBook, "Emprunter un livre."));
            Action.Add(DoSomething(BorrowCD, "Emprunter un CD."));
            Action.Add(DoSomething(BringBackBook, "Ramener un livre."));
            Action.Add(DoSomething(BringBackCD, "Ramener un CD."));
            Action.Add(DoSomething(AddBook, "Ajouter un livre."));
            Action.Add(DoSomething(AddCD, "Ajouter un CD."));
            Action.Add(DoSomething(RemoveBook, "Supprimer un livre."));
            Action.Add(DoSomething(RemoveCD, "Supprimer un CD."));
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

                // Liste les action dans la console
                foreach (MenuAction act in Action)
                {
                    Console.WriteLine("{0}. {1}", i, act.Description);
                    i++;
                }

                // Choix d'action
                Console.WriteLine("Entrez un numéro d'action (exit pour quitter) : ");
                string choix = Console.ReadLine();
                int Choix;

                if (choix == "exit")
                {
                    break;
                }
                if (! int.TryParse(choix, out Choix))
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
                    case 9:
                        Action[9].ActionToDo.Invoke();
                        break;
                    case 10:
                        Action[10].ActionToDo.Invoke();
                        break;
                    default:
                        Console.WriteLine("Choix erroné.");
                        break;
                }
            }

            // Attend input user pour terminer
            Console.ReadLine();
        }

        private MenuAction ListAll(String desc)
        {
            return new MenuAction(desc, () =>
            {
                List<Media> list = MediaManager.GetAll();
                foreach (Media media in list)
                {
                    Console.WriteLine(media.ToString());
                }
            });
        }

        private MenuAction AddBook(String desc)
        {
            return new MenuAction(desc, () =>
            {
                String titre = QuestionMenuManager.Ask<String>("Titre ?");
                uint nbStock = QuestionMenuManager.Ask<uint>("Nombre en stock ?");
                String auteur = QuestionMenuManager.Ask<String>("Auteur ?");
                int isbn = QuestionMenuManager.Ask<int>("ISBN ?");
                String genre = QuestionMenuManager.Ask<String>("Genre ?");
                Book book = new Book(titre, nbStock, auteur, isbn, genre);
                MediaManager.Save<Book>(book);
            });
        }

        private MenuAction AddCD(String desc)
        {
            return new MenuAction(desc, () =>
            {
                String titre = QuestionMenuManager.Ask<String>("Titre ?");
                uint nbStock = QuestionMenuManager.Ask<uint>("Nombre en stock ?");
                String artiste = QuestionMenuManager.Ask<String>("Artiste ?");
                String style = QuestionMenuManager.Ask<String>("Style ?");
                CD cd = new CD(titre, nbStock, artiste, style);
                MediaManager.Save<CD>(cd);
            });
        }

        private MenuAction RemoveBook(String desc)
        {
            return new MenuAction(desc, () =>
            {
                int id = QuestionMenuManager.Ask<int>("Identifiant ?");
                MediaManager.Remove<Book>(id);
            });
        }

        private MenuAction RemoveCD(String desc)
        {
            return new MenuAction(desc, () =>
            {
                int id = QuestionMenuManager.Ask<int>("Identifiant ?");
                MediaManager.Remove<CD>(id);
            });
        }

        private MenuAction SearchBook(String desc)
        {
            return new MenuAction(desc, () =>
            {
                int id = QuestionMenuManager.Ask<int>("Identifiant ?");
                Book m = MediaManager.Get<Book>(id) as Book;
                Console.WriteLine(m.ToString());

            });
        }

        private MenuAction SearchCD(String desc)
        {
            return new MenuAction(desc, () =>
            {
                int id = QuestionMenuManager.Ask<int>("Identifiant ?");
                CD cd = MediaManager.Get<CD>(id) as CD;
                Console.WriteLine(cd.ToString());
            });
        }

        private MenuAction BorrowBook(String desc)
        {
            return new MenuAction(desc, () =>
            {
                int id = QuestionMenuManager.Ask<int>("Identifiant ?");
                MediaManager.Borrow<Book>(id);
            });
        }

        private MenuAction BorrowCD(String desc)
        {
            return new MenuAction(desc, () =>
            {
                int id = QuestionMenuManager.Ask<int>("Identifiant ?");
                MediaManager.Borrow<CD>(id);
            });
        }

        private MenuAction BringBackBook(String desc)
        {
            return new MenuAction(desc, () =>
            {
                int id = QuestionMenuManager.Ask<int>("Identifiant ?");
                MediaManager.BringBack<Book>(id);
            });
        }

        private MenuAction BringBackCD(String desc)
        {
            return new MenuAction(desc, () =>
            {
                int id = QuestionMenuManager.Ask<int>("Identifiant ?");
                MediaManager.BringBack<CD>(id);
            });
        }
    }
}
