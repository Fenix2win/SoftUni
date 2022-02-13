using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
       public List<Student> students;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }

        public int Capacity { get; set; }
        public int Count { get=>students.Count;}


        public string RegisterStudent(Student student)
        {
            if (Count<Capacity)
            {
                students.Add(student);

                return $"Added student {student.FirstName} {student.LastName}"; 
            }

            return "No seats in the classroom";
        }


        public string DismissStudent(string firstName, string lastName)
        {
            Student dismStudent = students.Where(x => x.FirstName == firstName && x.LastName == lastName).FirstOrDefault();
            if (dismStudent != null)
            {
                students.Remove(dismStudent);
                return $"Dismissed student {firstName} {lastName}";
            }

            return "Student not found";
        }


        public string GetSubjectInfo(string subject)
        {
            List<Student> subjectStudents=new List<Student>();
            subjectStudents=students.Where(x=>x.Subject==subject).ToList();
            StringBuilder sb=new StringBuilder();

            if (subjectStudents.Count==0)
            {
                return "No students enrolled for the subject";
            }

            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");

            foreach (Student student in subjectStudents)
            {
                sb.AppendLine($"{student.FirstName} {student.LastName}");
            }


            return sb.ToString().TrimEnd();
        }


        public int GetStudentsCount()
        {
            return students.Count;
        }


        public Student GetStudent(string firstName, string lastName)
        {
            return students.Where((x) => x.FirstName == firstName &&x.LastName == lastName).FirstOrDefault();
        }
    }
}
