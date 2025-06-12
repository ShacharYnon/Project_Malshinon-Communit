using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;

namespace Project_Malshinon_Communit.AnalysisAndValidation
{
    internal class IntelReports
    {      
		string Texts;
        int TargetId;
        int ReporterId; 
        public IntelReports(string Texts ,int TargetId ,int ReporterId)
        {
            this.Texts = Texts;
            this.TargetId = TargetId;
            this.ReporterId = ReporterId;
        }
        public string GetTexts()
        {
            return Texts;
        }
        public int GetTargetId()
        {
            return TargetId;
        }
        public int GetReporterId()
        {
            return ReporterId;
        }
        
    }
}
