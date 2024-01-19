using System.Globalization;
using System.Runtime.CompilerServices;

//Param Patel - 101411591
//Dhrumil Kumbhani - 101410402
//Jeel Patel - 101410368
namespace gp2prac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello !");

            Console.WriteLine("\n");
            Console.WriteLine("---------------------------------------------------------------------");

            Course[,] courses = new Course[3, 3];

            courses[0, 0] = new Course("Math", 20);
            courses[0, 1] = new Course("English", 15);
            courses[0, 2] = new Course("History", 10);
            courses[1, 0] = new Course("Science", 25);
            courses[1, 1] = new Course("Art", 12);
            courses[1, 2] = new Course("Music", 18);
            courses[2, 0] = new Course("Physical Education", 30);
            courses[2, 1] = new Course("Computer Science", 20);
            courses[2, 2] = new Course("Foreign Language", 15);






            Student[] students = new Student[10]
            {
                new Student("Param" , 18 , new int[] {80,75,90}),
                new Student("Tanmay", 19, new int[] { 85, 90, 95 }),
                new Student("Rushil", 20, new int[] { 70, 85, 80 }),
                new Student("Dhrumil", 18, new int[] { 90, 95, 85 }),
                new Student("Jeel", 19, new int[] { 80, 80, 90 }),
                new Student("Ankitha", 18, new int[] { 80, 75, 90 }),
                new Student("Drasti", 19, new int[] { 85, 90, 95 }),
                new Student("Shiv", 20, new int[] { 70, 85, 80 }),
                new Student("Omakar", 18, new int[] { 90, 95, 85 }),
                new Student("Nisarg", 19, new int[] { 80, 80, 90 }),


            };

            Console.WriteLine("Student Information");


            Random rnd = new Random();
            foreach (Student student in students)
            {
                
                int i = rnd.Next(3);
                int j = rnd.Next(3);
                
                    courses[i, j].AddStudnetToCourse(courses[i, j], student);
                
                
            }
            Console.WriteLine("\n");
            // Print out name, age, and average grade of each student
            foreach (Student student in students)
            {
                Console.WriteLine("{0}, Age: {1}, Average Grade: {2}", student.Name, student.Age, student.GetAverageGrade(student));
            }

            Console.WriteLine("\n");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("\n");
            Console.WriteLine("Course Information");
            Console.WriteLine("\n");



            // Print out name and average grade of each course
            foreach (Course course in courses)
            {
                              
                    Console.WriteLine("{0}, Max Students : {1} Average Grade: {2}", course.Name, course.MaxStudents , course.GetCourseAveragGrade(course));
                
            }

        }
    }
}






    
