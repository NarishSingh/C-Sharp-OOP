using System;

namespace StudentManagementSystem.BLL.DTO
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Major { get; set; }
        public decimal GPA { get; set; }

        protected bool Equals(Student other)
        {
            return FirstName == other.FirstName
                   && LastName == other.LastName
                   && Major == other.Major
                   && GPA == other.GPA;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Student) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, Major, GPA);
        }
    }
}