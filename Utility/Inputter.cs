﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ManageStudents.Utility
{
    public class Inputter
    {
        public string GetName()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter name: ");
                    string input = Console.ReadLine();
                    Validate.CheckName(input);
                    return input;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}. Please enter again.");
                }
            }
        }

        public DateTime GetDate()
        {
            while (true)
            {
                Console.Write("Enter date of birth (dd-MM-yyyy): ");
                string input = Console.ReadLine();

                DateTime dob;
                if (DateTime.TryParseExact(input, "dd-MM-yyyy", null, DateTimeStyles.AllowTrailingWhite, out dob))
                {
                    // Check if the entered date is less than today's date
                    if (dob >= DateTime.Now)
                    {
                        Console.WriteLine("Date of birth must be earlier than today.");
                    }
                    else
                    {
                        try
                        {
                            Validate.CheckDOB(dob);
                            return dob;
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine("Error: " + e.Message);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Input must be in format dd-MM-yyyy");
                }
            }
        }

        public string GetAddress()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter address: ");
                    string input = Console.ReadLine();
                    Validate.CheckAddress(input);
                    return input;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}. Please enter again.");
                }
            }
        }
        public float GetHeight()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter height(cm): ");
                    string input = Console.ReadLine();
                    if (input.Contains(","))
                    {
                        Console.WriteLine("Error: Use a period (.) instead of a comma (,) for decimals.");
                        continue;
                    }
                    float height = float.Parse(input, CultureInfo.InvariantCulture);
                    Validate.CheckHeight(height);
                    return height;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}. Please enter again.");
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please enter a valid number for height");
                }
            }
        }
        public float GetWeight()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter weight(kg): ");
                    string input = Console.ReadLine();
                    if (input.Contains(","))
                    {
                        Console.WriteLine("Error: Use a period (.) instead of a comma (,) for decimals.");
                        continue;
                    }
                    float weight = float.Parse(input, CultureInfo.InvariantCulture);
                    Validate.CheckWeight(weight);
                    return weight;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}. Please enter again.");
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please enter a valid number for height");
                }
            }
        }
        public string GetStudentId()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter student id: ");
                    string input = Console.ReadLine();
                    Validate.CheckStudentId(input);
                    return input;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}. Please enter again.");
                }
            }
        }
        public string GetSchoolName()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter school name: ");
                    string input = Console.ReadLine();
                    Validate.CheckSchoolName(input);
                    return input;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}. Please enter again.");
                }
            }
        }
        public int GetYearStarted()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter year started: ");
                    int year = int.Parse(Console.ReadLine());
                    Validate.CheckYearStarted(year);
                    return year;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}. Please enter again.");
                }
            }
        }
        public double GetGpa()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter gpa: ");
                    double gpa = double.Parse(Console.ReadLine());
                    Validate.CheckGpa(gpa);
                    return gpa;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}. Please enter again.");
                }
            }
        }
    }
}
