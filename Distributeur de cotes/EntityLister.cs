using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Distributeur_de_cotes
{
    class EntityLister:Program
    {

        public static void Init()
        {
            Console.Clear();
            bool state = true;    //To define a state used by the loop to allow our programm to run as long as we don't write 'exit'
            while (state == true)
            {
                Console.WriteLine("You want a list of wich entity?");
                Console.WriteLine("1) Teachers");
                Console.WriteLine("2) Students");
                Console.WriteLine("3) Activities");
                Console.WriteLine("4) Exit");
                switch (Convert.ToString(Console.ReadLine()))  //To make the action of the 4 different possibilities or the default result
                {

                    case "1":
                        Console.Clear();
                        Console.WriteLine("Format: Firstname, Lastname, Salary");
                        Console.Write(List("../../../Database/teachers.csv"));
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Format: Firstname, Lastname");
                        Console.Write(List("../../../Database/students.csv"));
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Format: Name, Code, Teacher, ECTS");
                        Console.Write(List("../../../Database/activities.csv"));
                        break;
                    case "4":
                        state = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Chose a valid choice please >:(");
                        break;

                }
                Console.WriteLine("Press any key ");
                Console.ReadKey();
                Console.Clear();
            }

        }
        public static string List(string path)
        {
            string result = "";
            //Here we use the "path" variable so we can use this function for every entity whitout wrtiting
            //everything again
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (string line in lines)
            {
                result += line+Environment.NewLine;               
            }
            return result;
        }

    }
}
