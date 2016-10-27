using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributeur_de_cotes
{
    class Choice2:Program
    {
        public static void Init() {
            List<Student> students = ListStudents();
            List<Teacher> teachers = ListTeachers();
            List<Activity> activities = ListActivity(teachers);
            Console.WriteLine(ListStudentsInActivity(students, activities));
        }
        public static string ListStudentsInActivity(List<Student> students, List<Activity> activities)
        {
            string foo ="";
            return foo;
        }
    }
    
}
