﻿
using ManageStudents.Controller;
using ManageStudents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudents.View
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();
            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add a new student");
                Console.WriteLine("2. Search for a student by ID");
                Console.WriteLine("3. Update student details by ID");
                Console.WriteLine("0. Exit program");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        manager.CreateStudent();
                        break;
                    case "2":
                        manager.FindStudentbyId();
                        break;
                    case "3":
                        manager.UpdateStudentById();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
