using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblimania.Listeners;
namespace Biblimania.Menu
{
    static class QuestionMenuManager
    {
        /// <summary>
        /// Ask a type of answer to the user
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="question"></param>
        /// <returns></returns>
        public static T Ask<T>(String question)
        {
            while (true)
            {
                Console.WriteLine(question);
                try
                {
                    T choice = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                    return choice;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Erreur de format. Le type attendu est {0}. Veuillez re-essayer.", typeof(T).Name);
                    Program.appLogger.Write(AppLogger.TypeError.Error, e.Message);
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("La valeur était trop grande ou trop petite pour un {0}. Veuillez re-essayer.", typeof(T).Name);
                    Program.appLogger.Write(AppLogger.TypeError.Error, e.Message);
                }
            }
        }
    }
}
