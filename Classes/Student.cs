using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr5.Classes
{
    public class Student
    {
        public string FirstName = "";
        public string LastName = "";
        public string Surname = "";
        public bool Scholarship = false;
        public int Course = 4;

        public Student(string FirstName, string LastName, string Surname)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Surname = Surname;
        }

        public Student(string FirstName, string LastName, string Surname, bool Scholarship)
            : this(FirstName, LastName, Surname) {
                this.Scholarship = Scholarship;
            }

        public Student(string FirstName, string LastName, string Surname, bool Scholarship, int Course)
            : this(FirstName, LastName, Surname, Scholarship)
        {
            this.Course = Course;
        }
        
        public string GetFIO()
        {
            return $"{LastName} {FirstName} {Surname}";
        }
    }
}
