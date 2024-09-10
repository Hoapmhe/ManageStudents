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
            listStudents = new List<Student>()
            {
                new Student("Nguyen Van A", new DateTime(2000, 5, 15), "Ha Noi", 170, 65, "HE00000001", "University A", 2018, 3.5),
                new Student("Tran Thi B", new DateTime(2001, 9, 21), "Hai Phong", 160, 55, "HE00001111", "University B", 2019, 3.8),
                new Student("Le Van C", new DateTime(1999, 12, 30), "Da Nang", 175, 70, "HE00000021", "University C", 2017, 3.2)
            };
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

        public void FindStudentbyId()
        {
            string studentId = input.GetStudentId();
            Student student = listStudents.SingleOrDefault(s => s.StudentId == studentId);
            if (student == null)
            {
                Console.WriteLine($"Student with Id {studentId} not found!");
            }
            else
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}
