using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
//Param Patel - 101411591
//Dhrumil Kumbhani - 101410402
//Jeel Patel - 101410368

namespace gp2prac
{
    class Course
    {
        private string name;
        private int maxStudents;
        private Student[] students; 
        private int StudentCount;

        public Course(string name, int maxStudents)
        {
            this.name = name;
            this.maxStudents = maxStudents;
            this.students = new Student[maxStudents];
            StudentCount= 0;
        }

        public string Name { get =>name; set => name = value; }
        public int MaxStudents { get => maxStudents;set => maxStudents = value; }

        public Student[] Students { get => students; set => students = value;}

        public bool AddStudnetToCourse(Course course,Student student)
        {
            if (StudentCount < maxStudents)
            {
                students[StudentCount] = student ;
                StudentCount++;   
            }
            return StudentCount < maxStudents;



        }

        public double GetCourseAveragGrade(Course course)
        {
            double sum = 0.0;
            for (int i = 0; i < StudentCount; i++)
            {
                sum += students[i].GetAverageGrade(students[i]);
            }
            return sum / StudentCount;
        }

        public override string ToString()
        {
            return $"Course: {name}, Maximum Students: {maxStudents}, Enrolled Students: {Array.IndexOf(students, null)}";
        }
    }
}


