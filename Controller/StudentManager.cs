﻿using ManageStudents.Models;
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
            listStudents = new List<Student>();
            ReadFromFile();
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
                if (listStudents.Any(s => s.StudentId.Equals(studentId, StringComparison.OrdinalIgnoreCase)))
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
                return new Student();
            }

            Console.WriteLine(student.ToString());
            return student;
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
                for (int i = 0; i < listStudents.Count; i++)
                {
                    listStudents[i].Id = i + 1;
                }
            }
        }

        public void DisplayAllStudent()
        {
            if(!listStudents.Any())
            {
                Console.WriteLine("No student in the list");
                return;
            }
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
            foreach (var group in academicPerformaceGroups)
            {
                Console.WriteLine($"{group.TypeAcademicPerformance}: {group.Percent:F1}%");
            }
        }

        public void DisplayPercentGpa()
        {
            if (!listStudents.Any())
            {
                Console.WriteLine("No students in the list");
                return;
            }
            Dictionary<double, int> frequencyGpa = new Dictionary<double, int>();

            foreach (Student student in listStudents)
            {
                if (frequencyGpa.ContainsKey(student.GPA))
                {
                    frequencyGpa[student.GPA]++;
                }
                else
                {
                    frequencyGpa[student.GPA] = 1;
                }
            }

            foreach (var entry in frequencyGpa)
            {
                double percent = (double)entry.Value / listStudents.Count * 100;
                Console.WriteLine($"GPA: {entry.Key} - {percent:F1}%");
            }
        }
        public void DisplayListStudentByAcademicPerformance()
        {
            while (true)
            {
                Console.WriteLine("1. Poor");
                Console.WriteLine("2. Weak");
                Console.WriteLine("3. Average");
                Console.WriteLine("4. Fair");
                Console.WriteLine("5. Good");
                Console.WriteLine("6. Excellent");
                Console.WriteLine("0. Back to menu");
                Console.WriteLine("Choose option to show list student by academic performance: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ListStudentByAcademicPerformane(AcademicPerformanceEnum.POOR);
                        break;
                    case "2":
                        ListStudentByAcademicPerformane(AcademicPerformanceEnum.WEAK);
                        break;
                    case "3":
                        ListStudentByAcademicPerformane(AcademicPerformanceEnum.AVERAGE);
                        break;
                    case "4":
                        ListStudentByAcademicPerformane(AcademicPerformanceEnum.FAIR);
                        break;
                    case "5":
                        ListStudentByAcademicPerformane(AcademicPerformanceEnum.GOOD);
                        break;
                    case "6":
                        ListStudentByAcademicPerformane(AcademicPerformanceEnum.EXCELLENT);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void ListStudentByAcademicPerformane(AcademicPerformanceEnum name)
        {
            var list = listStudents.Where(s => s.AcademicPerformance == name).ToList();
            if(!list.Any())
            {
                Console.WriteLine($"No students found with {name} performance.");
            }
            else
            {
                foreach (var student in list)
                {
                    Console.WriteLine(student.ToString());  
                }
            }
        }

        public void SaveToFile()
        {
            string dicrectoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(dicrectoryPath, "listStudents.txt");
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var student in listStudents)
                    {
                        writer.WriteLine($"{student.Name}, {student.DOB.ToShortDateString()}, {student.Address}," +
                            $" {student.Height}, {student.Weight}, {student.StudentId}, {student.School}," +
                            $" {student.YearStarted}, {student.GPA}, {student.AcademicPerformance}");
                    }
                }
                Console.WriteLine("Data saved to file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to file: {ex.Message}");
            }
        }

        public void ReadFromFile()
        {
            string dicrectoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(dicrectoryPath, "listStudents.txt");
            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close(); 
                    return; 
                }

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    listStudents.Clear();

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length == 10) 
                        {
                            string name = parts[0].Trim();
                            DateTime dob = DateTime.Parse(parts[1]);
                            string address = parts[2].Trim();
                            float height = float.Parse(parts[3].Trim());
                            float weight = float.Parse(parts[4].Trim());
                            string studentId = parts[5].Trim();
                            string school = parts[6].Trim();
                            int yearStarted = int.Parse(parts[7].Trim());
                            double gpa = double.Parse(parts[8].Trim());
                            Student student = new Student(name, dob, address, height, weight, studentId, school, yearStarted, gpa);
                            listStudents.Add(student);
                        }
                    }
                }
                Console.WriteLine("Data read from file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading from file: {ex.Message}");
            }
        }

    }
}
