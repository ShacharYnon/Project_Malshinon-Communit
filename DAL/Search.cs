using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Google.Protobuf.Compiler;
using MySql.Data.MySqlClient;
using Mysqlx.Prepare;
using Mysqlx.Session;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Asn1.X509.SigI;
using Org.BouncyCastle.Crypto.Agreement;


namespace Project_Malshinon_Communit.DAL
{
    internal class Search
    {
        public static int GetIdByName(string FirstName, string LastName)
        {
            string connstring = "server=localhost;user=root;password=;database=malshinondb";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {
                    connection.Open();
                    string query = "SELECT Id FROM peoples " +
                        "WHERE First_name = @first_name " +
                        "AND Last_name = @Last_name;";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@first_name", FirstName);
                        cmd.Parameters.AddWithValue("@Last_name", LastName);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Console.WriteLine("You have successfully received the numID! ");
                                return reader.GetInt32("Id");
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Error in GetIdByName: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error in GetIdByName: " + ex.Message);
            }
            return 0;
        }
        public static (string FirstName, string LastName) GetNameReporter()
        {
            Console.WriteLine("enter yuor first name: ");
            string FirstName = Console.ReadLine();
            Console.WriteLine("enter your last name: ");
            string LastName = Console.ReadLine();
            return (FirstName, LastName);
        }
        public static bool CheckIfPersonExist(string FirstName, string LastName)
        {
            string connstring = "server=localhost;user=root;password=;database=malshinondb";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {
                    connection.Open();
                    string query = "SELECT * FROM peoples " +
                        "WHERE First_name = @FirstName " +
                        "AND Last_name = @LastName;";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", FirstName);
                        cmd.Parameters.AddWithValue("@LastName", LastName);
                        var reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            Console.WriteLine("Found User: " + FirstName);
                            return true;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("MySQL Error in CheckIfPersonExist: " + ex.Message);
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("General Error in CheckIfPersonExist: " + ex.Message);
                Console.ResetColor();

            }
            return false;
        }
        public static int GetNumOfCharInText()
        {
            string connstring = "server=localhost;user=root;password=;database=malshinondb";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {
                    connection.Open();
                    string query = "SELECT CHARACTER_LENGTH(Texts) numChars FROM intelreports;";
                    using (var cmd = new MySqlCommand(query, connection))
                    {

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int num = reader.GetInt32("numChars");
                                Console.WriteLine($"You have {num} of chars in the text! ");
                                return num;
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Error in GetNumOfCharInText: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error in GetNumOfCharInText: " + ex.Message);
            }
            return 0;

        }
        public static int GetNumForReportsById(int id )
        {
            string connstring = "server=localhost;user=root;password=;database=malshinondb";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {
                    connection.Open();
                    string query = "SELECT Num_reports FROM peoples WHERE Id = @Id ;";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id",id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int num = reader.GetInt32("Num_reports");
                                Console.WriteLine($"You have {num} reports ! ");
                                return num;
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Error in GetNumForReportsById: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error in GetNumForReportsById: " + ex.Message);
            }
            return 0;

        }
        public static int GetAverageOfCharactersByID(int id )
        {
            string connstring = "server=localhost;user=root;password=;database=malshinondb";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {
                    connection.Open();
                    string query = "SELECT AVG(CHARACTER_LENGTH(Texts)) AS avereg" +
                        " FROM intelreports " +
                        "WHERE ReporterId = @id ;";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int num = reader.GetInt32("avereg");
                                Console.WriteLine($"You have {num} AVG in your reports! ");
                                return num;
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Error in GetNumForReportsById: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error in GetNumForReportsById: " + ex.Message);
            }
            return 0;
        }
        public static int GetNumMentionsById(int id)
        {
            string connstring = "server=localhost;user=root;password=;database=malshinondb";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {
                    connection.Open();
                    string query = "SELECT Num_mentions FROM peoples WHERE Id = @Id ;";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int num = reader.GetInt32("Num_mentions");
                                Console.WriteLine($"You have {num} mentions ! ");
                                return num;
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Error in GetNumMentionsById: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error in GetNumMentionsById: " + ex.Message);
            }
            return 0;

        }
    }
}
