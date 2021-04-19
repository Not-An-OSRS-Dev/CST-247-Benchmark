using Bible_Verse_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Bible_Verse_Project.Services
{
    public class DataService: IDataService
    {
        string dbString = "Data Source=DESKTOP-453TS7U\\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public bool CreateVerse(BibleVerse verse)
        {
            bool success = false;

            string sqlStatement = "INSERT INTO dbo.verse (Testament, Book, Chapter, Verse, Text) VALUES (@TESTAMENT, @BOOK, @CHAPTER, @VERSE, @TEXT)";

            using (SqlConnection connection = new SqlConnection(this.dbString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@TESTAMENT", System.Data.SqlDbType.VarChar, 50);
                command.Parameters["@TESTAMENT"].Value = verse.Testament;
                command.Parameters.Add("@BOOK", System.Data.SqlDbType.VarChar, 50);
                command.Parameters["@BOOK"].Value = verse.Book;
                command.Parameters.Add("@CHAPTER", System.Data.SqlDbType.Int);
                command.Parameters["@CHAPTER"].Value = verse.Chapter;
                command.Parameters.Add("@VERSE", System.Data.SqlDbType.Int);
                command.Parameters["@VERSE"].Value = verse.Verse;
                command.Parameters.Add("@TEXT", System.Data.SqlDbType.VarChar, 200);
                command.Parameters["@TEXT"].Value = verse.Text;

                try
                {
                    connection.Open();
                    if (command.ExecuteNonQuery() != 0)
                        success = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return success;
        }

        public BibleVerse Search(string testament, string book, int chapter, int verseNum)
        {
            string sqlStatement = "SELECT * FROM dbo.verse WHERE Book = @BOOK AND Chapter = @CHAPTER AND" +
                " Verse = @VERSE AND Testament = @TESTAMENT";

            BibleVerse verse = new BibleVerse();

            using (SqlConnection connection = new SqlConnection(this.dbString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@TESTAMENT", System.Data.SqlDbType.VarChar, 50);
                command.Parameters["@TESTAMENT"].Value = testament;
                command.Parameters.Add("@BOOK", System.Data.SqlDbType.VarChar, 50);
                command.Parameters["@BOOK"].Value = book;
                command.Parameters.Add("@CHAPTER", System.Data.SqlDbType.Int);
                command.Parameters["@CHAPTER"].Value = chapter;
                command.Parameters.Add("@VERSE", System.Data.SqlDbType.Int);
                command.Parameters["@VERSE"].Value = verseNum;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        verse.Testament = (string)reader[1];
                        verse.Book = (string)reader[2];
                        verse.Chapter = (int)reader[3];
                        verse.Verse = (int)reader[4];
                        verse.Text = (string)reader[5];
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return verse;
        }
    }
}
