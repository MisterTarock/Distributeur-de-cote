using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributeur_de_cotes
{
   public class Student:Person
    {
        
        private List<Evaluation>  cours; //To make a list with all the evaluation from each activity

        //My constructor + base
        //base call the constructor from person
        public Student(string lastname, string firstname) : base(lastname,firstname)
        {
            cours = new List<Evaluation>();
        }

        

        //The method to Add the Eval
        public void Add(Evaluation eval)
        {
            cours.Add(eval);            
        }

        //The method to make the average of all the eval
        public string Average()
        {
            var sum = 0;  //to init the sum
            string result = "";
            
            foreach (var n in this.cours)  //to set the loop + increment that will read each eval 

                sum += n.Note();
            try
            {                               //To give the average
                sum = sum / this.cours.Count;
                result = "The student average is:";
                result +=Convert.ToString(sum);
                return result;
                
            }
            catch(DivideByZeroException)  //To make the exception where there are no eval (so the count equals 0)
            {
                Convert.ToString(sum);
                result="Can't do student average: No evalutaions yet";
                return result;
            }
            
        }

       
        public string Bulletin()  //To write the Bulletin as a dictionnary 
        { 
            //We create a dictionary containing a key with the activity and a key containing a tuple.
            //The tuple contains 2 ints: one for the sum of the grades and one that counts how many evaluations have been made.
            Dictionary<Activity, Tuple<int, int>> cotesforActivity = new Dictionary<Activity, Tuple<int, int>>();
            
            foreach (var point in cours) //for each activity in the list of activities
            {               
                try
                {
                    Tuple<int, int> t = cotesforActivity[point.Activity];
                    //add the new grade to the previous tuple value. Same for the eval counter.
                    cotesforActivity[point.Activity] = new Tuple<int, int>(t.Item1 + point.Note(), t.Item2 + 1);
                }
                //For the first evaluation
                catch (KeyNotFoundException)
                {
                    cotesforActivity.Add(point.Activity, new Tuple<int, int>(point.Note(), 1));
                }
            }

            //We concatenate everything
            string bulletin = this.Lastname + " " + this.Firstname + "\n";
            
            
            foreach (KeyValuePair<Activity, Tuple<int, int>> entry in cotesforActivity)
            {              
                bulletin += entry.Key.Code + " " + entry.Key.Name + " " + entry.Key.ECTS + " " + entry.Value.Item1 / entry.Value.Item2 + "\n";
            }

            
            return bulletin;
        }
    }

}
