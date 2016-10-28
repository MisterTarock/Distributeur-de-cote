﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Distributeur_de_cotes
{
    class Choice2:Program
    {
        public static void Init() //Void indicates that the methode Init() doesn't return any value
        {
            Console.Clear();

            bool state = true;  //To define a state used by the loop to allow our programm to run as long as we don't write 'exit'           
            while (state == true)
            {
                
                List<Teacher> teachers = ListTeachers();
                List<Activity> activities = ListActivity(teachers); //To init the list with the function below

                Console.WriteLine(ListOfAvailableActivities(activities));
                string query = Console.ReadLine();

                if (query == "exit")
                {
                    //breaks the loop
                    state = false;
                    Console.Clear();
                    break;
                }

                //displays the list of available students
                Console.Clear();
                string result =Environment.NewLine+ "For the " + query + " Activity there is:" + Environment.NewLine+ Environment.NewLine;
                string[] bulletins = System.IO.File.ReadAllLines("../../../Database/cotes.csv");

                try
                {
                    string querycode = activities.Find(a => a.Name == query).Code;
                    //goes trough every line of bulletin and splits every line in a string array
                    foreach (string line in bulletins)
                    {
                        List<string> elems = line.Split(',').Select(elem => elem.Trim()).ToList<string>();
                        if (elems[1] == querycode)
                        {
                            //concatenation of every match
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
            //displays a list of available activities and waits for an input
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
    

