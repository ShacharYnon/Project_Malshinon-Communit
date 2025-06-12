using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Malshinon_Communit.AnalysisAndValidation
{
    internal interface IReportChecking
    {
        void GetIDByName();
        void ExtractNameFromText();
        void AddPersonToTable();
        void AddTextToTable();
    }
}
