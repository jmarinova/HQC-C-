using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course
    {
        public OffsiteCourse(string courseName)
            :base(courseName)
        {
        }

        public OffsiteCourse(string courseName, string teacherName)
            :base(courseName, teacherName)
        {
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            :base(courseName, teacherName, students)
        {
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("OffsiteCourse { Name = ");
            result.Append(this.CourseName);

            return result.ToString();
        }
    }
}
