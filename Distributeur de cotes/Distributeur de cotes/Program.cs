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
            List<Activity> activities = ListActivity(teachers);

            readGrades(students,activities);

            foreach (Student student in students)
            {
                File.WriteAllText("../../Bulletin-" + student.Lastname + "-" + student.Firstname + ".txt", student.Bulletin()+"/n /n");
                //Console.Write(student.Bulletin());
                //Console.WriteLine(student.Average());
                //Console.WriteLine("\n \n");

            }
            double width= Console.WindowWidth;
            for ( int i = 0; i < ((width/2)-14); i++)
            {
                Console.Write("=");
            }
            Console.Write("Bienvenue dans evaluator 2.0 ");
            for (int i = 0; i < ((width / 2) - 15); i++)
            {
                Console.Write("=");
            }
            while (true)
            {
                Console.WriteLine("What are you here for?");
                Console.WriteLine("1) See Bulletin");
                Console.WriteLine("2) Something");
                Console.WriteLine("3) Some other thing");
                Console.WriteLine("4) Dunno LOL");
            
            
                switch (Convert.ToString(Console.ReadLine()))
                {
                    case "1":
                        Choice1.Init(students);

                        break;
                    default:
                        Console.WriteLine("Chose a valid choice please >:(");
                        break;


                }
            }
            Console.WriteLine("Press any key to exit.");
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
        public static List<Activity> ListActivity(List<Teacher> teachers)
        {
            string[] actis = System.IO.File.ReadAllLines("../../Activities.csv");
            List<Activity> activities = new List<Activity>();
            
            foreach(string line in actis)
            {
                List<string> elems = line.Split(',').Select(elem => elem.Trim()).ToList<string>();
                activities.Add(new Activity(elems[0], elems[1], Int32.Parse(elems[3]),teachers.Find(t => t.Lastname == elems[2])));
            }
            return activities;
        }
        public static void readGrades(List<Student> students, List<Activity> activities)
        {
            string[] grds = System.IO.File.ReadAllLines("../../Cotes.csv");
            
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
                try
                {
                    students.Find(s => s.Lastname == elems[0]).Add(grade);
                }
                catch
                {
                    Console.Write(elems[0]);
                    Console.WriteLine(": Student not registered");
                }
                

                
            }
        }
    }
}
