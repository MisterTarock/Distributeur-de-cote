using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Distributeur_de_cotes
{
    class Choice3:Choice2
    {
        public static new void Init() //Void indicates that the method Init() doesn't return any value
        {
            Console.Clear();
            bool state = true;  //To define a state used by the loop to allow our programm to run as long as we don't write 'exit'

            while (state == true)
            {
                //we initiate some lits of entities thanks to the methods created in the Program Class
                List<Student> students = ListStudents();

                List<Teacher> teachers = ListTeachers();
                List<Activity> activities = ListActivity(teachers);
                Console.WriteLine(ListOfAvailableActivities(activities));
                string query = Console.ReadLine();
                if (query == "exit")
                {
                    //setting statte to false breaks the while loop
                    state = false;
                    Console.Clear();
                    break;
                }

                Console.Clear();
                string result = Environment.NewLine + "For the " + query + " Activity there is:" + Environment.NewLine + Environment.NewLine;
                string[] bulletins = System.IO.File.ReadAllLines("../../../Database/cotes.csv");
                double sum = 0;  // To init the sum
                int i = 0;       // To init the increment i
                try
                {
                    //this line allow the program to convert the name of the lesson in its code
                    //So it can be found in the Cotes.csv
                    string querycode = activities.Find(a => a.Name == query).Code;
                    //And here we look for a match between the lesson code asked and the ones available in
                    //cotes.csv
                    foreach (string line in bulletins)
                    {
                        List<string> elems = line.Split(',').Select(elem => elem.Trim()).ToList<string>();

                        if (elems[1] == querycode)
                        {
                            sum += Convert.ToInt32(elems[2]);
                            i += 1;
                        }
                    }
                    double average = 0;
                    average = sum / i;  //To make the average of the student attending the class
                    //Concatenation and display
                    result += "The average of this activity is: " + Convert.ToString(average) + Environment.NewLine + Environment.NewLine;  //To display the average of the class
                    Console.WriteLine(result);
                    Console.WriteLine("Press any key to see another activity");

                    Console.ReadKey();
                    Console.Clear();
                }

                catch
                {
                    //if there is a spelling error ot hr activity doesn't exists, it shows this exeption.
                    Console.Clear();
                    Console.WriteLine("There is no such activity");

                    Console.WriteLine("Press any key to try again");
                    Console.ReadKey();
                    Console.Clear();
                }

            }
        }
    }
}
