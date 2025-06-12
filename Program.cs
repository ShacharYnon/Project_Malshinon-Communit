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
            //Manager start = new Manager();
            //start.Run();
            //string text = "yigtfuy07o jlivgcfgyhuoj ljbhvgjihkjGHG   gfYVFTYVG  KJHKJhjkjnhbhj KUTYGUJ";
            //var ttt = Analysis.ExtractingNameFromText(text);
            //Console.WriteLine(ttt);
            ManageReport nagar = new ManageReport();
            nagar.GetAllInfroFromReprter();

        }
}
}
