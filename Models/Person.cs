using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudents.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }

        public Person() { }
        public Person(int id, string name, DateTime dOB, string address, float height, float weight)
        {
            Id = id;
            Name = name;
            DOB = dOB;
            Address = address;
            Height = height;
            Weight = weight;
        }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Date of birth: {DOB}, Address: {Address}, Height: {Height}(cm), Weight: {Weight}(kg)";
        }
    }
}
