using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Malshinon_Communit.AnalysisAndValidation;
using Project_Malshinon_Communit.DAL;
using Project_Malshinon_Communit.NewFolder1;
 
namespace Project_Malshinon_Communit.Management
{
    internal class Manager
    {   
        public void Run()
        {
            ManageReport nagar = new ManageReport();
            nagar.GetAllInfroFromReprter();

        }
    }
}
