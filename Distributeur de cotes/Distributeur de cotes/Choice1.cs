using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributeur_de_cotes
{
    class Choice1:Program
    {
        
        public static void Init(List<Student> students)
        {
            string result = "Available bulletins:" + Environment.NewLine;
            foreach (Student student in students)
            {
                result += student.Lastname+Environment.NewLine;
            }
            result += "Wich one do you want to see?";
            Console.Write(result);
            string query = Console.ReadLine();
            foreach (Student person in students)
            {
                if (person.Lastname == query)
                {
                    result = person.Bulletin();
                    result += person.Average()+ Environment.NewLine+ Environment.NewLine;

                }
            }
            Console.WriteLine(result);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
