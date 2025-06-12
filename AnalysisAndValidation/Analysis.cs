using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Malshinon_Communit.AnalysisAndValidation
{
    internal class Analysis
    {
        public static (string FirstName, string LastName) ExtractingNameFromText(string Text)
        {
            string FirstName = null;
            string LastName = null;

            string[] words = Text.Split(' ');
            foreach (string word in words)
            {   
                if (word != "")
                {
                    if (char.IsUpper(word[0]))
                    {
                        if (FirstName == null)
                        {
                            FirstName = word;
                        }
                        else if (LastName == null)
                        {
                            LastName = word;
                            break;
                        }
                    }
                }
            }
            return (FirstName, LastName);
        }
    }
}
