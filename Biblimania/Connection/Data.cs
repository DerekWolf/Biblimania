using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblimania.Connection
{
    static class Data
    {
        public static DataSet biblimania { get; set; }

        public static DataTable book { get; set; }

        public static DataTable cd { get; set; }

        private static string ConnectionString = ConfigurationManager.ConnectionStrings["Biblimania.Properties.Settings.BiblimaniaConnectionString"].ConnectionString;

        private static SqlConnection connection = new SqlConnection(ConnectionString);

        /// <summary>
        /// Insert the data table into the SQL database.
        /// </summary>
        public static void UpdateDB()
        {
            OpenConnection();

            SqlDataAdapter adapterBook = new SqlDataAdapter("SELECT * FROM Book", connection);
            SqlCommandBuilder builderBook = new SqlCommandBuilder(adapterBook);
            adapterBook.Update(biblimania, "Book");

            SqlDataAdapter adapterCD = new SqlDataAdapter("SELECT * FROM CD", connection);
            SqlCommandBuilder builderCD = new SqlCommandBuilder(adapterCD);
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

        /// <summary>
        /// Fill the DataAdapter with the values in the DataTable.
        /// </summary>
        public static void FillDataSet()
        {
            OpenConnection();
            SqlDataAdapter adapterBook = new SqlDataAdapter("SELECT * FROM Book", connection);
            SqlCommandBuilder builderBook = new SqlCommandBuilder(adapterBook);
            adapterBook.Fill(biblimania, "Book");

            SqlDataAdapter adapterCD = new SqlDataAdapter("SELECT * FROM CD", connection);
            SqlCommandBuilder builderCD = new SqlCommandBuilder(adapterCD);
            adapterCD.Fill(biblimania, "CD");

            CloseConnection();
        }

        /// <summary>
        /// Creates the DataSet
        /// </summary>
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
    }
}
