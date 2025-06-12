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
                Console.WriteLine("MySQL Error in CheckIfPersonExist: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error in CheckIfPersonExist: " + ex.Message);
            }
            return false;
        }
    }
}
