﻿namespace InheritanceAndPolymorphism
{
    using System.Collections.Generic;
    using System;
    using System.Text;

    public abstract class Course
    {
        private string courseName;
        public Course(string courseName)
        {
            this.courseName = courseName;
            this.Students = new List<string>();
            this.TeacherName = null;
        }
        public Course(string courseName, string teacherName)
            :this(courseName)
        {
            this.TeacherName = teacherName;
        }

        public Course(string courseName, string teacherName, IList<string> students)
            : this(courseName, teacherName)
        {
            this.Students = students;
        }
        public string CourseName
        {
            get
            {
                return this.courseName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(value, "Name cannot be null");
                }

                this.courseName = value;
            }
        }

        public string TeacherName { get; set; }

        public IList<string> Students { get; set; }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("LocalCourse { Name = ");
            result.Append(this.CourseName);

            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            
            result.Append(" }");

            return result.ToString();
        }
    }
}
