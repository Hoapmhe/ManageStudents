using ManageStudents.Models;
using ManageStudents.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudents.Controller
{
    public class StudentManager
    {
        private List<Student> listStudents;
        private Inputter input;
        public StudentManager()
        {
            listStudents = new List<Student>();
            input = new Inputter();
        }

        public void CreateStudent()
        {
            string name = input.GetName();
            DateTime dob = input.GetDate();
            string address = input.GetAddress();
            float height = input.GetHeight();
            float weight = input.GetWeight();
            string studentId;
            while (true)
            {
                studentId = input.GetStudentId();
                //check dupplicate student id
                if (listStudents.Any(s => s.StudentId == studentId))
                {
                    Console.WriteLine("Student ID already exists. Please enter a different Student ID.");
                }
                else
                {
                    break;
                }
            }
            string schoolName = input.GetSchoolName();
            int yearStrarted = input.GetYearStarted();
            double gpa = input.GetGpa();

            Student student = new Student(name, dob, address, height, weight, studentId, schoolName, yearStrarted, gpa);
            listStudents.Add(student);
            Console.WriteLine("Student added successfully!");
        }
    }
}
