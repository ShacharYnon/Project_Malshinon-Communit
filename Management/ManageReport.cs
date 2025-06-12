using Org.BouncyCastle.Security;
using Project_Malshinon_Communit.AnalysisAndValidation;
using Project_Malshinon_Communit.DAL;
using Project_Malshinon_Communit.NewFolder1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Malshinon_Communit.Management
{
    internal class ManageReport
    {
        public void GetAllInfroFromReprter()
        {
            var names = Search.GetNameReporter();
            People reporterPerson = new People(names.FirstName, names.LastName);
            
            if (!Search.CheckIfPersonExist(names.FirstName, names.LastName))
            {
                DALPerson.AddPersonToTable(reporterPerson);
            }

            int IDReporter = Search.GetIdByName(names.FirstName, names.LastName);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(reporterPerson.ToString());
            Console.ResetColor();

            DALPerson.UpdateNumReports(IDReporter);

            var text = Reporter.GetTextFromReporter();
            var FirstAndLastName = Analysis.ExtractingNameFromText(text);
            People targetPerson = new People(FirstAndLastName.FirstName, FirstAndLastName.LastName);
            int IDTrget = 0;
            if (!Search.CheckIfPersonExist(FirstAndLastName.FirstName, FirstAndLastName.LastName))
            {
                DALPerson.AddPersonToTable(targetPerson);
                IDTrget = Search.GetIdByName(FirstAndLastName.FirstName, FirstAndLastName.LastName);
                DALPerson.UpdateTypeByID(IDTrget, "target");
            }
            else 
            {
                IDTrget = Search.GetIdByName(FirstAndLastName.FirstName, FirstAndLastName.LastName);
                DALPerson.UpdateTypeByID(IDTrget, "target");
            }
            IntelReports information = new IntelReports(text, IDTrget, IDReporter);
            InformationUpdates.ADDTextToTableIntelreports(information);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(targetPerson.ToString());
            Console.ResetColor();
            DALPerson.UpdateNumMentions(IDTrget);




        }

    }
}
