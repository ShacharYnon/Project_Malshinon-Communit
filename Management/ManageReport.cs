using Org.BouncyCastle.Security;
using Project_Malshinon_Communit.AnalysisAndValidation;
using Project_Malshinon_Communit.DAL;
using Project_Malshinon_Communit.NewFolder1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Malshinon_Communit.Menu_and_designs;

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


            MyColors.Green(reporterPerson.ToString());


            var text = Reporter.GetTextFromReporter();
            DALPerson.UpdateNumReports(IDReporter);

            var FirstAndLastName = Analysis.ExtractingNameFromText(text);
            People targetPerson = new People(FirstAndLastName.FirstName, FirstAndLastName.LastName);
            int IDTrget = 0;
            if (!Search.CheckIfPersonExist(FirstAndLastName.FirstName, FirstAndLastName.LastName))
            {
                DALPerson.AddPersonToTable(targetPerson);
                IDTrget = Search.GetIdByName(FirstAndLastName.FirstName, FirstAndLastName.LastName);
                DALPerson.UpdateTypeByID(IDTrget, "target");
                DALPerson.UpdateNumMentions(IDTrget);
            }
            else 
            {
                IDTrget = Search.GetIdByName(FirstAndLastName.FirstName, FirstAndLastName.LastName);
                DALPerson.UpdateTypeByID(IDTrget, "target");
                DALPerson.UpdateNumMentions(IDTrget);
            }
            IntelReports information = new IntelReports(text, IDTrget, IDReporter);
            InformationUpdates.ADDTextToTableIntelreports(information);

            MyColors.Green(targetPerson.ToString());


            int numREports = Search.GetNumForReportsById(IDReporter);
            if (numREports >= 10)
            {
                int avg = Search.GetAverageOfCharactersByID(IDReporter);
                if(avg >= 100)
                {
                    DALPerson.UpdateTypeByID(IDReporter, "potential_agent");
                }
            }

            int NumMentions = Search.GetNumMentionsById(IDTrget);
            if (NumMentions >= 20)
            {
                MyColors.Red("Potential threat detected !!!");
            }
        }

    }
}
