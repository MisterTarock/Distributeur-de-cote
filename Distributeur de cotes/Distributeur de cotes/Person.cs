using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributeur_de_cotes
{
    public class Person
    {
        //to create my variable (so in minuscule)
        private string firstname, lastname;

        //to create the properties who are constructor and use the variables 
        //with 'get' and 'set' to write in the variable (the properties in MAJ)
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

      
        //My Constructor
        //to make the variable accesible and use them via the properties
        public Person(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        //The different method
        //to display the names
        public string DisplayName()
        {          
            return (firstname + lastname);
        }
    }
}
