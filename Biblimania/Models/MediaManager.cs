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

        private static SqlConnection connection = new SqlConnection(ConnectionString);

        public static void UpdateDB()
        {
            OpenConnection();
            SqlDataAdapter adapterBook = new SqlDataAdapter("SELECT * FROM Book", connection);
            SqlCommandBuilder builderBook = new SqlCommandBuilder(adapterBook);

            // Insert the data table into the SQL database.
            //
            adapterBook.Update(biblimania, "Book");

            SqlDataAdapter adapterCD = new SqlDataAdapter("SELECT * FROM CD", connection);
            SqlCommandBuilder builderCD = new SqlCommandBuilder(adapterCD);

            // Insert the data table into the SQL database.
            //
            adapterCD.Update(biblimania, "CD");
            CloseConnection();
        }

        public static void OpenConnection()
        {
            connection.Open();
        }

        public static void CloseConnection()
        {
            connection.Close();
        }

        public static void FillDataSet()
        {
            OpenConnection();
            using (var adapter = new SqlDataAdapter("SELECT * FROM Book", connection))
            using (new SqlCommandBuilder(adapter))
            {
                //
                // Fill the DataAdapter with the values in the DataTable.
                //
                adapter.Fill(biblimania, "Book");
            }
            using (var adapter = new SqlDataAdapter("SELECT * FROM CD", connection))
            using (new SqlCommandBuilder(adapter))
            {
                //
                // Fill the DataAdapter with the values in the DataTable.
                //
                adapter.Fill(biblimania, "CD");
            }
            CloseConnection();
        }

        public static void CreateDataset()
        {
            biblimania = new DataSet("Biblimania");
            book = new DataTable("Book");
            cd = new DataTable("CD");

            biblimania.Tables.Add(book);
            biblimania.Tables.Add(cd);

            DataColumn idColBook = new DataColumn("Id");
            idColBook.DataType = System.Type.GetType("System.Int32");
            idColBook.AutoIncrement = true;
            idColBook.AutoIncrementSeed = 0;
            idColBook.AutoIncrementStep = 1;
            book.Columns.Add(idColBook);

            DataColumn titleColBook = new DataColumn("Title");
            titleColBook.DataType = System.Type.GetType("System.String");
            book.Columns.Add(titleColBook);

            DataColumn stockColBook = new DataColumn("Stock");
            stockColBook.DataType = System.Type.GetType("System.UInt32");
            book.Columns.Add(stockColBook);

            DataColumn authorColBook = new DataColumn("Author");
            authorColBook.DataType = System.Type.GetType("System.String");
            book.Columns.Add(authorColBook);

            DataColumn isbnColBook = new DataColumn("ISBN");
            isbnColBook.DataType = System.Type.GetType("System.Int32");
            book.Columns.Add(isbnColBook);

            DataColumn genderColBook = new DataColumn("Gender");
            genderColBook.DataType = System.Type.GetType("System.String");
            book.Columns.Add(genderColBook);

            book.PrimaryKey = new DataColumn[] { idColBook };

            DataColumn idColCD = new DataColumn("Id");
            idColCD.DataType = System.Type.GetType("System.Int32");
            idColCD.AutoIncrement = true;
            idColCD.AutoIncrementSeed = 0;
            idColCD.AutoIncrementStep = 1;
            cd.Columns.Add(idColCD);

            DataColumn titleColCD = new DataColumn("Title");
            titleColCD.DataType = System.Type.GetType("System.String");
            cd.Columns.Add(titleColCD);

            DataColumn stockColCD = new DataColumn("Stock");
            stockColCD.DataType = System.Type.GetType("System.UInt32");
            cd.Columns.Add(stockColCD);

            DataColumn artistColCD = new DataColumn("Artist");
            artistColCD.DataType = System.Type.GetType("System.String");
            cd.Columns.Add(artistColCD);

            DataColumn styleColCD = new DataColumn("Style");
            styleColCD.DataType = System.Type.GetType("System.String");
            cd.Columns.Add(styleColCD);

            cd.PrimaryKey = new DataColumn[] { idColCD };
        }

        public static void Save<T>(T media) where T : IMedia
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
