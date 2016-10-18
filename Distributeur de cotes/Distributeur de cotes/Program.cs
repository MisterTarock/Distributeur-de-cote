using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributeur_de_cotes
{
    class Program
    {
        static void Main(string[] args)
        {

            //Encore à améliorer....

           
             //To define the students
             Student Puissant = new Student("Puissant", "Victor");
             Student Petit = new Student("Petit", "Jon");

             //To define the teachers
             Teacher Combe = new Teacher("Combefis","Sebastien", 2500); //the salary that is a int should not set between ""
             Teacher Fle = new Teacher("Flemal", "Clemence", 4500);
             Teacher Lur = new Teacher("Lurquin", "Quentin", 10000);

             //To define the differnete activity
             Activity COO = new Activity("Conception oriente objet","COO", 3, Combe); // the same for the teacher call by is var
             Activity EN = new Activity("Electo Numérique", "EN", 4, Fle);
             Activity PI = new Activity("Projet Info", "PO", 10, Lur);

             //To define the appreciations
             Appreciation PuissantCOO = new Appreciation(COO,"X");
             Appreciation PuissantEN = new Appreciation(EN, "");
             Appreciation PuissantPI = new Appreciation(PI, "TB");

             Appreciation PetitCOO = new Appreciation(COO, "X");

             //The bulletin from Puissant
             Puissant.Add(PuissantCOO);
             Puissant.Add(PuissantEN);
             Puissant.Add(PuissantPI);

             //The bulletin from Petit
             Petit.Add(PetitCOO);

             Console.WriteLine(Puissant.Bulletin());
             Console.WriteLine(Puissant.Average());

             Console.WriteLine(Petit.Bulletin());
             Console.WriteLine(Petit.Average());

             Console.ReadKey(); 

             






        }
    }
}
