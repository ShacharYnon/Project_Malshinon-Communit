using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Malshinon_Communit.DAL;
using Project_Malshinon_Communit.Management;
using Project_Malshinon_Communit.AnalysisAndValidation;


namespace Project_Malshinon_Communit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ManageReport nagar = new ManageReport();
            //nagar.GetAllInfroFromReprter();
            int id = 1;
            int numREports = Search.GetNumForReportsById();
            if (numREports >= 10)
            {
                
                Search.intGetAverageOfCharactersByID();
            }
            
            Search.intGetAverageOfCharactersByID();

        }
    }
}
