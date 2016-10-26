using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //To allow us to read in the file.csv

namespace Distributeur_de_cotes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = ListStudents();  //To init the list with the function below
            List<Teacher> teachers = ListTeachers();
            List<Activity> activities = ListActivity(teachers);

            readGrades(students,activities);

            foreach (Student student in students)
            {
                File.WriteAllText("../../../Bulletins/Bulletin-" + student.Lastname + "-" + student.Firstname + ".txt", student.Bulletin()+"/n /n");
               //To create the bulletin in the folder Bulletins
               //The ../ allow us to go one folder ahaed form the the debug file

            }

            double width= Console.WindowWidth; //To define the width of the window

            for ( int i = 0; i < ((width/2)-14); i++) //To make a beautiful title
            {
                Console.Write("=");
            }
            Console.Write("Bienvenue dans evaluator 2.0 ");
            for (int i = 0; i < ((width / 2) - 15); i++)
            {
                Console.Write("=");
            }

            while (true) //To compose our menu
            {
                Console.WriteLine("What are you here for?");
                Console.WriteLine("1) See Bulletin");
                Console.WriteLine("2) Something");
                Console.WriteLine("3) Some other thing");
                Console.WriteLine("4) Dunno LOL");
                Console.WriteLine("5)Exit");
            
            
                switch (Convert.ToString(Console.ReadLine()))  //To make the action of the 4 different possibilities or the default result
                {
                    case "1":
                        Choice1.Init(students);

                        break;
<<<<<<< HEAD
                    case "5":
                        Environment.Exit(0);
                        break;
                    case "4":
                        Console.WriteLine("¯\\_(ツ)_/¯");
                        break;
=======



>>>>>>> 1b13acc630db845d07b8314c1d9cb221faa6518c
                    default:
                        Console.WriteLine("Chose a valid choice please >:(");
                        break;
                    


                }
            }
<<<<<<< HEAD
            
=======

>>>>>>> 1b13acc630db845d07b8314c1d9cb221faa6518c

        }
        public static List<Student> ListStudents()
        {
            string[] studs = System.IO.File.ReadAllLines("../../../Database/students.csv"); //To go in the students file and read his content
            List<Student> students = new List<Student>(); //To set the info from the student in a list that we can go through with
            foreach (string line in studs)
            {
                List<string> elems = line.Split(',').Select(elem => elem.Trim()).ToList<string>();  //To cut the info with the ','
                students.Add(new Student(elems[0], elems[1]));
            }
            return students;
        }
        
        public static List<Teacher> ListTeachers()
        {
            string[] teachs = System.IO.File.ReadAllLines("../../../Database/teachers.csv");
            List<Teacher> teachers = new List<Teacher>();
            foreach(string line in teachs)
            {
                List<string> elems = line.Split(',').Select(elem => elem.Trim()).ToList<string>();
                teachers.Add(new Teacher(elems[0], elems[1], Int32.Parse(elems[2]))); //the salary of the teacher is a int32
            }
            return teachers;
        }

        public static List<Activity> ListActivity(List<Teacher> teachers)
        {
            string[] actis = System.IO.File.ReadAllLines("../../../DataBase/activities.csv");
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
            string[] grds = System.IO.File.ReadAllLines("../../../Database/cotes.csv");
            
            foreach (string line in grds)
            {
                
                List<string> elems = line.Split(',').Select(elem => elem.Trim()).ToList<string>();

                
                Evaluation grade;


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
