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
        public static void Init()
        {
            Console.Clear();
            bool state = true;

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
                string[] bulletins = System.IO.File.ReadAllLines("../../../Database/Cotes.csv");
                double sum=0;
                int i = 0;
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
                    sum = sum / i;
                    result += "The average of this activity is: " + Convert.ToString(sum)+Environment.NewLine + Environment.NewLine;
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
