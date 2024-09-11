using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudents.Models
{
    public class Student : Person
    {
        public string StudentId { get; set; }
        public string School { get; set; }
        public int YearStarted { get; set; }
        public double GPA { get; set; }
        public AcademicPerformanceEnum AcademicPerformance { get; set; }
        public Student() { }
        public Student(string name, DateTime dob, string address, float height, float weight,
                        string studentId, string school, int yearStarted, double gpa) : base(name,dob,address,height,weight)
        {
            StudentId = studentId;
            School = school;
            YearStarted = yearStarted;
            GPA = gpa;
            UpdateAcademicPerformance();
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nStudent ID: {StudentId}, School: {School}, Year Started: {YearStarted}, GPA: {GPA}, Academic: {AcademicPerformance}";
        }

        private void UpdateAcademicPerformance()
        {
            if (GPA < 3)
            {
                AcademicPerformance = AcademicPerformanceEnum.POOR;
            }
            else if (GPA >= 3 && GPA < 5)
            {
                AcademicPerformance =  AcademicPerformanceEnum.WEAK;
            }
            else if (GPA >= 5 && GPA < 6.5)
            {
                AcademicPerformance = AcademicPerformanceEnum.AVERAGE;
            }
            else if (GPA >= 6.5 && GPA < 7.5)
            {
                AcademicPerformance = AcademicPerformanceEnum.FAIR;
            }
            else if (GPA >= 7.5 && GPA < 9)
            {
                AcademicPerformance = AcademicPerformanceEnum.GOOD;
            }
            else
            {
                AcademicPerformance = AcademicPerformanceEnum.EXCELLENT;
            }
        } 
    }
}
