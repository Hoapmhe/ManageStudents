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
            if (string.IsNullOrEmpty(name) || name.Length > Constants.NAME_LENGTH_MAX)
                throw new ArgumentException($"Name must be between 1 and {Constants.NAME_LENGTH_MAX} characters.");
        }

        public static void CheckDOB(DateTime dob)
        {
            if (dob.Year <= Constants.YEAR_MIN) throw new ArgumentException($"Date of birth from {Constants.YEAR_MIN}");
        }

        public static void CheckAddress(string address)
        {
            if (address != null && address.Length > Constants.ADDRESS_LENGTH_MAX)
                throw new ArgumentException($"Address must be less than {Constants.ADDRESS_LENGTH_MAX} characters.");
        }

        public static void CheckHeight(float height)
        {
            if (height < Constants.HEIGHT_MIN || height > Constants.HEIGHT_MAX)
                throw new ArgumentException($"Height must be between {Constants.HEIGHT_MIN} and {Constants.HEIGHT_MAX}(cm).");
        }

        public static void CheckWeight(float width)
        {
            if (width < Constants.WEIGHT_MIN || width > Constants.WEIGHT_MAX)
                throw new ArgumentException($"Weight must be between {Constants.WEIGHT_MIN} and {Constants.WEIGHT_MAX}(kg).");
        }

        public static void CheckStudentId(string id)
        {
            if (string.IsNullOrWhiteSpace(id) || id.Length != Constants.STUDENT_ID_LENGTH)
                throw new ArgumentException($"Student ID must be {Constants.STUDENT_ID_LENGTH} characters.");
        }

        public static void CheckSchoolName(string schoolName)
        {
            if (string.IsNullOrEmpty(schoolName) || schoolName.Length >= Constants.SCHOOL_NAME_LENGTH_MAX)
                throw new ArgumentException($"Current school must be less than {Constants.SCHOOL_NAME_LENGTH_MAX} characters.");
        }

        public static void CheckYearStarted(int year)
        {
            if(year <= Constants.YEAR_SCHOOL_STARTED) throw new ArgumentException($"Year of university started must be after {Constants.YEAR_SCHOOL_STARTED}.");    
        }

        public static void CheckGpa(double gpa)
        {
            if(gpa < Constants.GPA_MIN ||  gpa > Constants.GPA_MAX)
                throw new ArgumentException($"GPA must be between {Constants.GPA_MIN} and {Constants.GPA_MAX}.");  
        }
    }
}
