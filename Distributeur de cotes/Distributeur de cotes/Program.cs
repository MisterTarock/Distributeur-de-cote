using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Distributeur_de_cotes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = ListStudents();
            List<Teacher> teachers = ListTeachers();


            List<Activity> activities = ListActivity();

            readGrades();

            foreach (Student student in students)
            {
                File.WriteAllText("../../Bulletin-" + student.Lastname + "-" + student.Firstname + ".txt", student.Bulletin());
                Console.Write(student.Bulletin());

            }

            Console.ReadKey(); 
            
        }
        public static List<Student> ListStudents()
        {
            string[] studs = System.IO.File.ReadAllLines("../../students.csv");
            List<Student> students = new List<Student>();
            foreach (string line in studs)
            {
                List<string> elems = line.Split(',').Select(elem => elem.Trim()).ToList<string>();
                students.Add(new Student(elems[0], elems[1]));
            }
            return students;
        }
        
        public static List<Teacher> ListTeachers()
        {
            string[] teachs = System.IO.File.ReadAllLines("../../Teachers.csv");
            List<Teacher> teachers = new List<Teacher>();
            foreach(string line in teachs)
            {
                List<string> elems = line.Split(',').Select(elem => elem.Trim()).ToList<string>();
                teachers.Add(new Teacher(elems[0], elems[1], Int32.Parse(elems[2])));
            }
            return teachers;
        }
        public static List<Activity> ListActivity()
        {
            string[] actis = System.IO.File.ReadAllLines("../../Activities.csv");
            List<Activity> activities = new List<Activity>();
            List<Teacher> teachers = ListTeachers();
            foreach(string line in actis)
            {
                List<string> elems = line.Split(',').Select(elem => elem.Trim()).ToList<string>();
                activities.Add(new Activity(elems[0], elems[1], Int32.Parse(elems[3]),teachers.Find(t => t.Lastname == elems[2])));
            }
            return activities;
        }
        public static void readGrades( )
        {
            string[] grds = System.IO.File.ReadAllLines("../../Cotes.csv");
            List<Activity> activities = ListActivity();
            List<Student> students = ListStudents();
            foreach (string line in grds)
            {
                
                List<string> elems = line.Split(',').Select(elem => elem.Trim()).ToList<string>();
                
                Evaluation grade;

                // Grades can be either given as an int or a string (N, C, B, ...)
                // We first try to parse the grade from the file as a number, if that fails (raises an exception)
                // we assume the grade is in the string fromat
                try
                {
                    
                    grade = new Cote(Int32.Parse(elems[2]),activities.Find(a => a.Code == elems[1]));
                    
                    
                }
                catch (FormatException)
                {
                    grade = new Appreciation(activities.Find(a => a.Code == elems[1]), elems[2]);
                }

                // Find the corresponding student and add the grade
                
                students.Find(s => s.Lastname == elems[0]).Add(grade);

                
            }
        }
    }
}
