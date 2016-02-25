namespace Methods
{
using System;

    public class Student
    {
        private string firstName;
        private string lastName;
        private string nativeTown;
        private DateTime birthDate;

        public Student(string firstName, string lastName, string nativeTown, DateTime birthDate)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.NativeTown = nativeTown;
            this.BirthDate = birthDate;
        }
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First Name cannot be null");
                }

                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Last Name cannot be null");
                }

                this.lastName = value;
            }
        }
        public string NativeTown
        {
            get
            {
                return this.nativeTown;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Last Name cannot be null");
                }

                this.nativeTown = value;
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return this.birthDate;
            }
            set
            {
                if (value.Year < 1900 || value.Year > DateTime.Now.Year)
                {
                    throw new ArgumentOutOfRangeException("Please enter correct date");
                }

                this.birthDate = value;
            }
        }
        public bool IsOlderThan(Student other)
        {
            bool result = DateTime.Compare(this.BirthDate, other.BirthDate) == -1;
            return result;
        }
    }
}
