using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Malshinon_Communit.DAL
{
    internal class People
    {
        string FirstName;
        string LastName;
        string SecretCode;
        string Type;

        public string SetSecretCode()
        {
            var secret = Guid.NewGuid().ToString();
            return secret;
        }
        public People(string First_name, string Last_name , string Type = "reporter")
        {
            this.FirstName = First_name;
            this.LastName = Last_name;
            this.Type = Type;
            this.SecretCode = SetSecretCode();    
        }
        public string GetFirstname()
        {
            return FirstName;
        }
        public string GetLastname()
        { 
            return LastName;
        }
        public string GetSecretCode()
        {
            return SecretCode;
        }

        public string GetType()
        {
            return Type;
        }

        public void SetType(string type)
        {
            this.Type = type;
        }

        public override string ToString()
        {
            return $"my First name is: {FirstName} ,and my Last name is: {LastName} ,my Secret Code is: {SecretCode} ,and my Type is: {Type} ";
        }
    }
}
