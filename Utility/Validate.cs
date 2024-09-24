using ManageStudents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudents.Utility
{
    public static class Validate
    {
        public static void CheckName(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length > Constants.NameLengthMax)
                throw new ArgumentException($"Name must be between 1 and {Constants.NameLengthMax} characters.");
        }

        public static void CheckDOB(DateTime dob)
        {
            if (dob.Year <= Constants.YearMin) throw new ArgumentException($"Date of birth from {Constants.YearMin}");
        }

        public static void CheckAddress(string address)
        {
            if (address != null && address.Length > Constants.AddressLengthMax)
                throw new ArgumentException($"Address must be less than {Constants.AddressLengthMax} characters.");
        }

        public static void CheckHeight(float height)
        {
            if (height < Constants.HeightMin || height > Constants.HeightMax)
                throw new ArgumentException($"Height must be between {Constants.HeightMin} and {Constants.HeightMax}(cm).");
        }

        public static void CheckWeight(float width)
        {
            if (width < Constants.WeightMin || width > Constants.WeightMax)
                throw new ArgumentException($"Weight must be between {Constants.WeightMin} and {Constants.WeightMax}(kg).");
        }

        public static void CheckStudentId(string id)
        {
            if (string.IsNullOrWhiteSpace(id) || id.Length != Constants.StudentIdLength)
                throw new ArgumentException($"Student ID must be {Constants.StudentIdLength} characters.");
        }

        public static void CheckSchoolName(string schoolName)
        {
            if (string.IsNullOrEmpty(schoolName) || schoolName.Length >= Constants.SchollNameLengthMax)
                throw new ArgumentException($"Current school must be less than {Constants.SchollNameLengthMax} characters.");
        }

        public static void CheckYearStarted(int year)
        {
            if(year <= Constants.YearSchoolStarted) throw new ArgumentException($"Year of university started must be after {Constants.YearSchoolStarted}.");
            if (year > DateTime.Now.Year) throw new ArgumentException("Start year must be at least less than current year");
        }

        public static void CheckGpa(double gpa)
        {
            if(gpa < Constants.GpaMin ||  gpa > Constants.GpaMax)
                throw new ArgumentException($"GPA must be between {Constants.GpaMin} and {Constants.GpaMax}.");  
        }
    }
}
