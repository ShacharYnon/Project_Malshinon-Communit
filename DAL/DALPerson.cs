using Google.Protobuf.Compiler;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;
using Project_Malshinon_Communit.Menu_and_designs;

namespace Project_Malshinon_Communit.DAL
{
    internal class DALPerson
    {
        public static void AddPersonToTable(People person)
        {
            string connstring = "server=localhost;user=root;password=;database=malshinondb";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {
                    connection.Open();
                    string query = @"INSERT INTO 
                        peoples (First_name ,Last_name ,Secret_code ,Type)
                        VALUES (@First_name ,@Last_name ,@Secret_code ,@Type)";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@First_name" ,person.GetFirstname());
                        cmd.Parameters.AddWithValue("@Last_name" ,person.GetLastname());
                        cmd.Parameters.AddWithValue("@Secret_code" , person.SetSecretCode());
                        cmd.Parameters.AddWithValue("@Type" ,person.GetType());
                        cmd.ExecuteNonQuery();
                    }
                    MyColors.Blue("Person added successfully! ");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Error in AddPersonToTable: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error in AddPersonToTable: " + ex.Message);
            }
        }
        public static void UpdateTypeByID(int id ,string type)
        {
            string connstring = "server=localhost;user=root;password=;database=malshinondb";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {
                    connection.Open();
                    string query = @"UPDATE peoples 
                        SET Type = @type WHERE Id = @id;";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@type", type);
                        cmd.ExecuteNonQuery();
                    }
                    MyColors.Yellow($"The type:{type} was updated successfully! to id {id} ");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Error in UpdateTypeByID: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error in UpdateTypeByID: " + ex.Message);
            }
        }
        public static void UpdateNumReports(int id) 
        {
            string connstring = "server=localhost;user=root;password=;database=malshinondb";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {
                    connection.Open();
                    string query = @"UPDATE peoples 
                        SET Num_reports = Num_reports + 1 WHERE Id = @id;";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    MyColors.Yellow("The Num of reports updated successfully! by id " + id);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Error in UpdateNumReports: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error in UpdateNumReports: " + ex.Message);
            }
        }
        public static void UpdateNumMentions(int id) 
        {
            string connstring = "server=localhost;user=root;password=;database=malshinondb";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {
                    connection.Open();
                    string query = @"UPDATE peoples 
                        SET Num_mentions = Num_mentions + 1 WHERE Id = @id;";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        
                        cmd.ExecuteNonQuery();
                    }
                    MyColors.Yellow("The Num of reports updated successfully! by id " + id);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Error in UpdateNumMentions: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error in UpdateNumMentions: " + ex.Message);
            }

        }
    }
}
