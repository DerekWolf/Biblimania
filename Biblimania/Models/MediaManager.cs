using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblimania.Listeners;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Biblimania.Models
{
    static class MediaManager
    {
        private static DataSet biblimania {get; set;}

        private static DataTable book {get; set;}

        private static DataTable cd { get; set; }

        private static string ConnectionString = ConfigurationManager.ConnectionStrings["Biblimania.Properties.Settings.BiblimaniaConnectionString"].ConnectionString;

        public static void CreateDataset()
        {
            biblimania = new DataSet("Biblimania");
            book = new DataTable("Book");
            cd = new DataTable("CD");

            biblimania.Tables.Add(book);
            biblimania.Tables.Add(cd);

            DataColumn idCol = new DataColumn("id");
            idCol.DataType = System.Type.GetType("System.Int32");
            idCol.AutoIncrement = true;
            idCol.AutoIncrementSeed = 0;
            idCol.AutoIncrementStep = 1;
            book.Columns.Add(idCol);

            DataColumn titleCol = new DataColumn("title");
            titleCol.DataType = System.Type.GetType("System.String");
            book.Columns.Add(titleCol);

            DataColumn stockCol = new DataColumn("stock");
            stockCol.DataType = System.Type.GetType("System.UInt32");
            book.Columns.Add(stockCol);

            DataColumn authorCol = new DataColumn("author");
            authorCol.DataType = System.Type.GetType("System.String");
            book.Columns.Add(authorCol);

            DataColumn isbnCol = new DataColumn("isbn");
            isbnCol.DataType = System.Type.GetType("System.Int32");
            book.Columns.Add(isbnCol);

            DataColumn genderCol = new DataColumn("gender");
            genderCol.DataType = System.Type.GetType("System.String");
            book.Columns.Add(genderCol);

            DataColumn idCol2 = new DataColumn("id");
            idCol2.DataType = System.Type.GetType("System.Int32");
            idCol2.AutoIncrement = true;
            idCol2.AutoIncrementSeed = 0;
            idCol2.AutoIncrementStep = 1;
            cd.Columns.Add(idCol2);

            DataColumn titleCol2 = new DataColumn("title");
            titleCol.DataType = System.Type.GetType("System.String");
            cd.Columns.Add(titleCol2);

            DataColumn stockCol2 = new DataColumn("stock");
            stockCol2.DataType = System.Type.GetType("System.UInt32");
            cd.Columns.Add(stockCol2);

            DataColumn artistCol = new DataColumn("artist");
            artistCol.DataType = System.Type.GetType("System.String");
            cd.Columns.Add(artistCol);

            DataColumn styleCol = new DataColumn("style");
            styleCol.DataType = System.Type.GetType("System.String");
            cd.Columns.Add(styleCol);
        }

        public static void Save<T>(T media) where T : IMedia
        {
            if(typeof(T) == typeof(Book))
            {
                DataRow newBookRow = book.NewRow();
                Book newBook = media as Book;
                newBookRow["title"] = newBook.Title;
                newBookRow["stock"] = newBook.Stock;
                newBookRow["author"] = newBook.Author;
                newBookRow["isbn"] = newBook.ISBN;
                newBookRow["gender"] = newBook.Gender;

                book.Rows.Add(newBookRow);
                book.AcceptChanges();
                biblimania.AcceptChanges();
            }

            if(typeof(T) == typeof(CD))
            {
                DataRow newCDRow = cd.NewRow();
                CD newCD = media as CD;
                newCDRow["title"] = newCD.Title;
                newCDRow["stock"] = newCD.Stock;
                newCDRow["artist"] = newCD.Artist;
                newCDRow["style"] = newCD.Style;

                cd.Rows.Add(newCDRow);
                cd.AcceptChanges();
            }
        }

        public static Media Get<T>(int id)
        {
            if (typeof(T) == typeof(Book))
            {
                DataRow dr = biblimania.Tables["Book"].Select("id = " + id)[0];
                Book b = new Book((string) dr["title"], (uint) dr["stock"], (string) dr["author"], (int) dr["isbn"], (string) dr["gender"]);
                b.Identifiant = (int) dr["id"];
                return b;
            }

            if (typeof(T) == typeof(CD))
            {
                DataRow dr = biblimania.Tables["CD"].Select("id = " + id)[0];
                CD c = new CD((string) dr["title"], (uint) dr["stock"], (string) dr["artist"], (string) dr["style"]);
                c.Identifiant = (int) dr["id"];
                return c;
            }
            return null;
        }

        public static List<Media> GetAll()
        {
            List<Media> list = new List<Media>();
            DataRow[] drBook = biblimania.Tables["Book"].Select();
            DataRow[] drCD = biblimania.Tables["CD"].Select();
            foreach (DataRow row in drBook)
            {
                Book b = new Book((string)row["title"], (uint)row["stock"], (string)row["author"], (int)row["isbn"], (string)row["gender"]);
                b.Identifiant = (int)row["id"];
                list.Add(b);
            }

            foreach (DataRow row in drCD)
            {
                CD c = new CD((string)row["title"], (uint)row["stock"], (string)row["artist"], (string)row["style"]);
                c.Identifiant = (int)row["id"];
                list.Add(c);
            }

            return list;
        }

        public static void Remove<T>(int id)
        {
            if (typeof(T) == typeof(Book))
            {
                book.Rows.Remove(book.Rows.Find(id));
            }

            if (typeof(T) == typeof(CD))
            {
                cd.Rows.Remove(cd.Rows.Find(id));
            }
        }

        public static void BringBack<T>(int id)
        {
            if (typeof(T) == typeof(Book))
            {
                DataRow dr = biblimania.Tables["Book"].Select("id = " + id)[0];
                uint a = (uint)dr["stock"];
                dr["stock"] = a + 1;
                book.AcceptChanges();

                Book bModified = Get<Book>(id) as Book;
            }
            if (typeof(T) == typeof(CD))
            {
                DataRow dr = biblimania.Tables["CD"].Select("id = " + id)[0];
                uint a = (uint) dr["stock"];
                dr["stock"] = a + 1;
                cd.AcceptChanges();

                CD cdModified = Get<CD>(id) as CD;
            }
        }

        public static void Borrow<T>(int id)
        {
            if (typeof(T) == typeof(Book))
            {
                DataRow dr = biblimania.Tables["Book"].Select("id = " + id)[0];
                uint a = (uint)dr["stock"];
                if (a > 0)
                {
                    dr["stock"] = a - 1;
                    book.AcceptChanges();

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
                DataRow dr = biblimania.Tables["CD"].Select("id = " + id)[0];
                uint a = (uint)dr["stock"];
                if (a > 0)
                {
                    dr["stock"] = a - 1;
                    cd.AcceptChanges();

                    CD cdModified = Get<CD>(id) as CD;
                    cdModified.Borrow();
                }
                else
                {
                    Console.WriteLine("Cet album n'est plus disponible.");
                }
            }
        }
    }
}
