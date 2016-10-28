using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributeur_de_cotes
{
    class Choice1:Program
    {
        public static void Init(List<Student> students) //Void indicates that the methode Init() doesn't return any value
        {
            Console.Clear();

            bool state = true;  //To define a state used by the loop to allow our programm to run as long as we don't write 'exit'
            while (state==true)
            {
                string result = "Available bulletins:" + Environment.NewLine;  
                //to show the various students
                foreach (Student student in students)
                {
                    result += student.Lastname + Environment.NewLine;
                }

                result += Environment.NewLine;
                
                result += "Wich one do you want to see? (or type exit to go back to the main menu)";
                Console.Write(result);
                
                string query = Console.ReadLine(); //To read the answer that we gave at the console
                //Here we use a bool so when have been through the whole bulletin, if the student is not 
                //found, An error pops out saying "No student found" (see line 56)
                
                bool found = false;//when we went through all students, if found=false, throws an exeption  
                foreach (Student person in students)
                {
                                        
                    //see if the query matches any od the students
                    if (person.Lastname == query) 
                    {
                        //print the bulletin and the average
                        result = person.Bulletin();
                        result += person.Average() + Environment.NewLine + Environment.NewLine; //Environment.NewLine does a linebreak
                        Console.WriteLine(result);
                        //found=true means we found at least a match and throws no exeption
                        found = true;
                        Console.WriteLine("Press any key to see another bulletin");
                        Console.ReadKey();                      
                    }

                    else if (query == "exit")
                    {                     
                        state = false; //we go out from the loop
                        found = true;
                        break;
                    }

                }
                //exeption if typo error or no entry
                if (found == false)
                {
                    Console.Clear();
                    Console.WriteLine("No such person");
                    Console.WriteLine("Press any key to return to the main menu");
                    Console.ReadKey();
                    break;
                }

                Console.Clear();
            }

        }
    }
}
