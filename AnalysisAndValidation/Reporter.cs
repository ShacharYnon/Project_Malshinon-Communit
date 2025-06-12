using Project_Malshinon_Communit.AnalysisAndValidation;
using Project_Malshinon_Communit.DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Malshinon_Communit.NewFolder1
{
    internal class Reporter
    {
        public static string GetTextFromReporter()
        {
            Console.WriteLine("Please enter your report. ");
            string text = Console.ReadLine();
            return text;
        }
        
    }
}
