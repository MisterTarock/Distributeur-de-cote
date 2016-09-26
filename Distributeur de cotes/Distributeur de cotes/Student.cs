using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributeur_de_cotes
{
    class Student:Person
    {
        //To create my variable
        private List<Evaluation>  cours;

        //My constructor + base
        //base call the constructor from person
        public Student(string firstname, string lastname) : base(firstname, lastname)
        {
            cours = new List<Evaluation>();
        }

        //The different method

        //to Add the Eval
        public void Add(Evaluation)
        {
            // ecrire ma fonction cf labo precedent pour get mes eval et les add
        }

        //to make the average
        public double Average()
        {
            // diviser mon add par le nombre d'eval
        }

        //to make a Bulletin
        public string Bulletin()
        {
           //remplir mon bulletin avec mes moyennes
        }



    }
}
