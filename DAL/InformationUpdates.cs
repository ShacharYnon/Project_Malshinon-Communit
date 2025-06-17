using Google.Protobuf.Compiler;
using MySql.Data.MySqlClient;
using Project_Malshinon_Communit.AnalysisAndValidation;
using Project_Malshinon_Communit.Menu_and_designs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Malshinon_Communit.DAL
{
    internal class InformationUpdates
    {
        public static void ADDTextToTableIntelreports(IntelReports report)
        {
            string connstring = "server=localhost;user=root;password=;database=malshinondb";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {
                    connection.Open();
                    string query = @"INSERT INTO 
                        IntelReports (Texts ,TargetId ,ReporterId )
                        VALUES (@Texts ,@TargetId ,@ReporterId )";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Texts", report.GetTexts());
                        cmd.Parameters.AddWithValue("@TargetId", report.GetTargetId());
                        cmd.Parameters.AddWithValue("@ReporterId", report.GetReporterId());
                        cmd.ExecuteNonQuery();
                    }
                    MyColors.Blue("The text was successfully inserted into the table! ");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Error in ADDTextToTableIntelreports: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error in ADDTextToTableIntelreports: " + ex.Message);
            }
        }
    }
}
