using System;

namespace KCAResultSlip
{
    public class Student
    {
        public string StudentName { get; set; }
        public string StudentID { get; set; }
        public string Course { get; set; }
        public string Semester { get; set; }

        // Subjects and marks (out of 100)
        public double MathsMarks { get; set; }
        public double ProgrammingMarks { get; set; }
        public double DatabaseMarks { get; set; }
        public double NetworkingMarks { get; set; }
        public double EnglishMarks { get; set; }

        // Constructor
        public Student(string studentName, string studentID, string course, string semester,
                       double mathsMarks, double programmingMarks, double databaseMarks,
                       double networkingMarks, double englishMarks)
        {
            StudentName = studentName;
            StudentID = studentID;
            Course = course;
            Semester = semester;
            MathsMarks = mathsMarks;
            ProgrammingMarks = programmingMarks;
            DatabaseMarks = databaseMarks;
            NetworkingMarks = networkingMarks;
            EnglishMarks = englishMarks;
        }

        public double ComputeAverage()
        {
            return (MathsMarks + ProgrammingMarks + DatabaseMarks + NetworkingMarks + EnglishMarks) / 5.0;
        }

        public string GetGrade(double marks)
        {
            if (marks >= 70) return "A";
            else if (marks >= 60) return "B";
            else if (marks >= 50) return "C";
            else if (marks >= 40) return "D";
            else return "E";
        }

        public string GetOverallRemark(double average)
        {
            if (average >= 70) return "DISTINCTION";
            else if (average >= 60) return "CREDIT";
            else if (average >= 50) return "PASS";
            else if (average >= 40) return "SUPPLEMENT";
            else return "FAIL";
        }
    }
}
