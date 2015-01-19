using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblimania.Listeners;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using Biblimania.Connection;

namespace Biblimania.Models
{
    static class MediaManager
    {
        private static DataSet biblimania = Data.biblimania;

        private static DataTable book = Data.book;

        private static DataTable cd = Data.cd;

        public static void Save<T>(T media)
        {
            if(typeof(T) == typeof(Book))
            {
                DataRow newBookRow = book.NewRow();
                Book newBook = media as Book;
                newBookRow["Title"] = newBook.Title;
                newBookRow["Stock"] = newBook.Stock;
                newBookRow["Author"] = newBook.Author;
                newBookRow["ISBN"] = newBook.ISBN;
                newBookRow["Gender"] = newBook.Gender;

                book.Rows.Add(newBookRow);
            }

            if(typeof(T) == typeof(CD))
            {
                DataRow newCDRow = cd.NewRow();
                CD newCD = media as CD;
                newCDRow["Title"] = newCD.Title;
                newCDRow["Stock"] = newCD.Stock;
                newCDRow["Artist"] = newCD.Artist;
                newCDRow["Style"] = newCD.Style;

                cd.Rows.Add(newCDRow);
            }
        }

        public static Media Get<T>(int id)
        {
            if (typeof(T) == typeof(Book))
            {
                DataRow dr = biblimania.Tables["Book"].Select("Id = " + id)[0];
                Book b = new Book(dr["Title"].ToString(), uint.Parse(dr["Stock"].ToString()), dr["Author"].ToString(), int.Parse(dr["ISBN"].ToString()), dr["Gender"].ToString());
                b.Identifiant = int.Parse(dr["Id"].ToString());
                return b;
            }

            if (typeof(T) == typeof(CD))
            {
                DataRow dr = biblimania.Tables["CD"].Select("Id = " + id)[0];
                CD c = new CD(dr["Title"].ToString(), uint.Parse(dr["Stock"].ToString()), dr["Artist"].ToString(), dr["Style"].ToString());
                c.Identifiant = int.Parse(dr["Id"].ToString());
                return c;
            }
            return null;
        }

        public static List<Media> GetAll()
        {
            List<Media> list = new List<Media>();
            DataRow[] drBook = biblimania.Tables["Book"].Select();
            DataRow[] drCD = biblimania.Tables["CD"].Select();
            foreach (DataRow dr in drBook)
            {
                Book b = new Book(dr["Title"].ToString(), uint.Parse(dr["Stock"].ToString()), dr["Author"].ToString(), int.Parse(dr["ISBN"].ToString()), dr["Gender"].ToString());
                b.Identifiant = int.Parse(dr["Id"].ToString());
                list.Add(b);
            }

            foreach (DataRow dr in drCD)
            {
                CD c = new CD(dr["Title"].ToString(), uint.Parse(dr["Stock"].ToString()), dr["Artist"].ToString(), dr["Style"].ToString());
                c.Identifiant = int.Parse(dr["Id"].ToString());
                list.Add(c);
            }

            return list;
        }

        public static void Remove<T>(int id)
        {
            try
            {
                if (typeof(T) == typeof(Book))
                {
                    book.Rows.Find(id).Delete();
                }

                if (typeof(T) == typeof(CD))
                {
                    cd.Rows.Find(id).Delete();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ID introuvable");
            }
        }

        public static void BringBack<T>(int id)
        {
            try
            {
                if (typeof(T) == typeof(Book))
                {
                    DataRow dr = book.Rows.Find(id);
                    uint a = uint.Parse(dr["Stock"].ToString());
                    dr["Stock"] = a + 1;

                    Book bModified = Get<Book>(id) as Book;
                }
                if (typeof(T) == typeof(CD))
                {
                    DataRow dr = cd.Rows.Find(id);
                    uint a = uint.Parse(dr["Stock"].ToString());
                    dr["Stock"] = a + 1;

                    CD cdModified = Get<CD>(id) as CD;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ID introuvable");
            }
        }

        public static void Borrow<T>(int id)
        {
            try 
            {
                if (typeof(T) == typeof(Book))
                {
                    DataRow dr = book.Rows.Find(id);
                    uint a = uint.Parse(dr["Stock"].ToString());
                    if (a > 0)
                    {
                        dr["Stock"] = a - 1;

                        Book bModified = Get<Book>(id) as Book;
                        bModified.Borrow();
                    }
                    else
                    {
                        Console.WriteLine("Ce livre n'est plus disponible.");
                    }
                }
                if (typeof(T) == typeof(CD))
                {
                    DataRow dr = cd.Rows.Find(id);
                    uint a = uint.Parse(dr["Stock"].ToString());
                    if (a > 0)
                    {
                        dr["Stock"] = a - 1;

                        CD cdModified = Get<CD>(id) as CD;
                        cdModified.Borrow();
                    }
                    else
                    {
                        Console.WriteLine("Cet album n'est plus disponible.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ID introuvable");
            }
        }
    }
}
