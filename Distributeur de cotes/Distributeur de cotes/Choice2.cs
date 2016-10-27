using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Distributeur_de_cotes
{
    class Choice2:Program
    {
        public static void Init() {
            Console.Clear();
            bool state = true;
            bool found = false;
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
                string result =Environment.NewLine+ "For the " + query + " Activity there is:" + Environment.NewLine+ Environment.NewLine;
                string[] bulletins = System.IO.File.ReadAllLines("../../../Database/Cotes.csv");
                try
                {
                    string querycode = activities.Find(a => a.Name == query).Code;
                    foreach (string line in bulletins)
                    {
                        List<string> elems = line.Split(',').Select(elem => elem.Trim()).ToList<string>();

                        if (elems[1] == querycode)
                        {
                            result += elems[0] + Environment.NewLine;

                        }


                    }
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
        public static string ListOfAvailableActivities(List<Activity> activities)
        {
            
            string result = "";
            result+="Available activities:"+Environment.NewLine + Environment.NewLine;
            
            foreach (Activity activity in activities)
            {
                result += activity.Name+ Environment.NewLine;
            }
            result += Environment.NewLine;
            result +="For which activity do you need information? Or type exit" ;
            return result;


        }
        }
    }
    

