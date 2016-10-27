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
        public static new void Init() //Void indicates that the methode Init() doesn't return any value
        {
            Console.Clear();
            bool state = true;  //To define a state used by the loop to allow our programm to run as long as we don't write 'exit'

            while (state == true)
            {
                List<Student> students = ListStudents();

                List<Teacher> teachers = ListTeachers();
                List<Activity> activities = ListActivity(teachers);
                Console.WriteLine(ListOfAvailableActivities(activities));
                string query = Console.ReadLine();
                if (query == "exit")
                {
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
                    string querycode = activities.Find(a => a.Name == query).Code;
                    foreach (string line in bulletins)
                    {
                        List<string> elems = line.Split(',').Select(elem => elem.Trim()).ToList<string>();

                        if (elems[1] == querycode)
                        {
                            sum += Convert.ToInt32(elems[2]);
                            i += 1;
                        }
                    }

                    sum = sum / i;  //To make the average of the student attending the class
                    result += "The average of this activity is: " + Convert.ToString(sum) + Environment.NewLine + Environment.NewLine;  //To display the average of the class
                    Console.WriteLine(result);
                    Console.WriteLine("Press any key to see another activity");

                    Console.ReadKey();
                    Console.Clear();
                }

                catch
                {
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
