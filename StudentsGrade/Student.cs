using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Param Patel - 101411591
//Dhrumil Kumbhani - 101410402
//Jeel Patel - 101410368

namespace gp2prac
{
    class Student
    {
        private string name;
        private int age;
        private int[] grades;
        

        public string Name { get { return name; } set { name = value; } }
        public int Age { get { return age; } set { age = value; } }
        public int[] Grades { get { return grades; } set { grades = value; } }

        public Student(string name, int age, int[] grades)
        {
            this.grades = grades;
            this.name = name;
            this.age = age;
        }
        public double GetAverageGrade(Student student)
        {
            double sum;
            sum = 0.0;
            foreach (int grade in grades)
            {
                sum += grade;
            }

            return sum / grades.Length;

        }



        public override string ToString()
        {
            return $"Name: {name}, Age: {age}, Grades: [{string.Join(",", grades)}]";

        }


    }
}
