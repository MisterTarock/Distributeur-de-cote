using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distributeur_de_cotes;

namespace Distributeur_de_cotes
{
   public class Teacher : Person
    {
        //to create my variable (so in minuscule)
        private int salary;

        //to create the properties who are constructor and use the variables 
        //with 'get' and 'set' to write in the variable (the properties in MAJ)
        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        //My constructor + base
        //base call the constructor from person
        public Teacher(string firstname, string lastname, int salary) : base(firstname, lastname)
        {
            Salary = salary;
        }

        public Teacher(string firstname, string lastname) : base(firstname, lastname)
        {
        }
    }
}
