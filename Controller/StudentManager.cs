using ManageStudents.Models;
using ManageStudents.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
                new Student("Nguyen Van A", new DateTime(2000, 5, 15), "Ha Noi", 170, 65, "HE00000001", "University A", 2018, 6.5),
                new Student("Tran Thi B", new DateTime(2001, 9, 21), "Hai Phong", 160, 55, "HE00001111", "University B", 2019, 3.8),
                new Student("Le Van C", new DateTime(1999, 12, 30), "Da Nang", 175, 70, "HE00000021", "University C", 2017, 7.2),
                new Student("Le Van C", new DateTime(1999, 12, 30), "Da Nang", 175, 70, "HE00000022", "University C", 2017, 9.2),
                new Student("Le Van C", new DateTime(1999, 12, 30), "Da Nang", 175, 70, "HE00000422", "University C", 2017, 9.2),
                new Student("Le Van C", new DateTime(1999, 12, 30), "Da Nang", 175, 70, "HE00000122", "University C", 2017, 9.2),
                new Student("Le Van C", new DateTime(1999, 12, 30), "Da Nang", 175, 70, "HE00000222", "University C", 2017, 9.2),
                new Student("Le Van C", new DateTime(1999, 12, 30), "Da Nang", 175, 70, "HE00000023", "University C", 2017, 6.2)
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

        public Student FindStudentById()
        {
            string studentId = input.GetStudentId();
            Student student = listStudents.SingleOrDefault(s => s.StudentId == studentId);
            if (student == null)
            {
                Console.WriteLine($"Student with Id {studentId} not found!");
                return null;
            }
            else
            {
                Console.WriteLine(student.ToString());
                return student;
            }
        }

        public void UpdateStudentById()
        {
            Student student = FindStudentById();
            if (student != null)
            {
                while (true)
                {
                    Console.WriteLine("\nSelect the field you want to update: ");
                    Console.WriteLine("1. Name");
                    Console.WriteLine("2. Date of Birth");
                    Console.WriteLine("3. Address");
                    Console.WriteLine("4. Height");
                    Console.WriteLine("5. Weight");
                    Console.WriteLine("6. Current School");
                    Console.WriteLine("7. Year of University Entry");
                    Console.WriteLine("8. GPA");
                    Console.WriteLine("0. Exit update");
                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine();
                    try
                    {
                        switch (choice)
                        {
                            case "1":
                                student.Name = input.GetName();
                                break;
                            case "2":
                                student.DOB = input.GetDate();
                                break;
                            case "3":
                                student.Address = input.GetAddress();
                                break;
                            case "4":
                                student.Height = input.GetHeight();
                                break;
                            case "5":
                                student.Weight = input.GetWeight();
                                break;
                            case "6":
                                student.School = input.GetSchoolName();
                                break;
                            case "7":
                                student.YearStarted = input.GetYearStarted();
                                break;
                            case "8":
                                student.GPA = input.GetGpa();
                                break;
                            case "0":
                                Console.WriteLine("Update finished.");
                                return;
                            default:
                                Console.WriteLine("Invalid choice. Please try again.");
                                break;
                        }

                        Console.WriteLine("Student details updated successfully:");
                        Console.WriteLine(student.ToString());
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}. Update failed.");
                    }
                }
            }
        }

        public void DeleteStudentById()
        {
            Student student = FindStudentById();
            if (student != null)
            {
                listStudents.Remove(student);
                Console.WriteLine("Student deleted successfully");

                //update ID of remaining student
                for(int i = 0; i < listStudents.Count; i++)
                {
                    listStudents[i].Id = i+1;
                }
            }
        }

        public void DisplayAllStudent()
        {
            foreach (Student student in listStudents)
            {
                Console.WriteLine(student.ToString());
            }
        }

        public void DisplayPercentAcademicPerformance()
        {
            if (!listStudents.Any())
            {
                Console.WriteLine("No students in the list");
                return;
            }

            var academicPerformaceGroups = listStudents.GroupBy(s => s.AcademicPerformance)
                                            .Select(group => new
                                            {
                                                TypeAcademicPerformance = group.Key,
                                                Percent = (double)group.Count() / listStudents.Count * 100
                                            })
                                            .OrderByDescending(g => g.Percent)
                                            .ToList();  
            foreach(var group in academicPerformaceGroups)
            {
                Console.WriteLine($"{group.TypeAcademicPerformance}: {group.Percent}%");
            }
        }
    }
}
