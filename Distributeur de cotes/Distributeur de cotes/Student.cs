using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributeur_de_cotes
{
   public class Student:Person
    {
        //To create my variable
        private List<Evaluation>  cours; //with all the cursus

        //My constructor + base
        //base call the constructor from person
        public Student(string firstname, string lastname) : base(firstname, lastname)
        {
            cours = new List<Evaluation>();
        }

        //The different method

        //to Add the Eval
        public void Add(Evaluation eval)
        {
            this.cours.Add(eval);
        }

        //to make the average of all the eval
        public double Average()
        {
            var sum = 0;
            foreach (var n in this.cours)

                sum += n.Note();

            return sum /this.cours.Count;
        }

        //to make a Bulletin
        public string Bulletin()
        {
            // The evaluations can be assigned to any activity and are not sorted
            // We first need to sort them by activity to be able to take an average
            // For this we create a dictionary (hashmap) where the key is an activity and the value is a tuple of two integers
            // representing the running sum of the scores for that activity and the number of evaluations.
            // For each activity we check if it already exists in the dictionary, if it does we update the sum and number
            // otherwise we add the activity
            Dictionary<Activity, Tuple<int, int>> gradesPerActivity = new Dictionary<Activity, Tuple<int, int>>();

            foreach (var g in this.cours)
            {
                // We try to access a given key in the dictionary, if it does not exist it will throw an exception
                // and we know we have to add it to the dictionary.
                try
                {
                    Tuple<int, int> t = gradesPerActivity[g.Activity];
                    gradesPerActivity[g.Activity] = new Tuple<int, int>(t.Item1 + g.Note(), t.Item2 + 1);
                }
                catch (KeyNotFoundException)
                {
                    gradesPerActivity.Add(g.Activity, new Tuple<int, int>(g.Note(), 1));
                }
            }

            // We construct the string to print out, beginning with the name of the student on the first line
            string bulletin = this.Lastname + " " + this.Firstname + "\n";

            // And a line for every activity with the code, name, ects and score
            foreach (KeyValuePair<Activity, Tuple<int, int>> entry in gradesPerActivity)
            {
                bulletin += entry.Key.Code + " " + entry.Key.Name + " " + entry.Key.ECTS + " " + entry.Value.Item1 / entry.Value.Item2 + "\n";
            }

            bulletin += "\n\n";

            return bulletin;
        }
    }

}
