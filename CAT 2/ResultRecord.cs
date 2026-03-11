using System;

namespace KCAResultSlip
{
    public class ResultRecord
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string StudentID { get; set; }
        public string Course { get; set; }
        public string Semester { get; set; }
        public double MathsMarks { get; set; }
        public double ProgrammingMarks { get; set; }
        public double DatabaseMarks { get; set; }
        public double NetworkingMarks { get; set; }
        public double EnglishMarks { get; set; }
        public double AverageMarks { get; set; }
        public string OverallRemark { get; set; }
        public DateTime DateRecorded { get; set; }
    }
}
