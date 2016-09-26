using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distributeur_de_cotes;

namespace Distributeur_de_cotes
{
    class Activity //reated to teacher with a composition so we replace 
                //the type 'int, string...' by the name from the related class
    {
        //to create my variable (so in minuscule)
        private int ects;
        private string name, code;
        //Teacher became my type with a variable teacher 
        private Teacher teacher;

        //to create the properties who are constructor and use the variables 
        //with 'get' and 'set' to write in the variable (the properties in MAJ)
        public int ECTS
        {
            get { return ects; }
            set { ects = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        public Teacher Teacher
        {
            get { return teacher; }
            set { teacher = value; }
        }

        // My Constructor
        public Activity(string name, string code, int ects, Teacher teacher)
        {
            Name = name;
            Code = code;
            ECTS = ects;
            Teacher = teacher;
        }
    } 

}
