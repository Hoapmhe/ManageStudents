
using ManageStudents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudents.View
{
    public class Main
    {
        Student[] students = new Student[]
            {
                new Student("Nguyen Van A", new DateTime(2000, 5, 15), "Ha Noi", 170, 65, "SV001", "University A", 2018, 8.5),
                new Student("Tran Thi B", new DateTime(2001, 9, 21), "Hai Phong", 160, 55, "SV002", "University B", 2019, 9.8),
                new Student("Le Van C", new DateTime(1999, 12, 30), "Da Nang", 175, 70, "SV003", "University C", 2017, 9.2)
            };

    }
}
