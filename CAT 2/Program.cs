using System;
using KCAResultSlip;

Console.WriteLine("========================================");
Console.WriteLine("   KCA UNIVERSITY - STUDENT RESULT SLIP");
Console.WriteLine("========================================");
Console.WriteLine();

// Capture student details
Console.Write("Enter Student Name        : ");
string studentName = Console.ReadLine() ?? "";

Console.Write("Enter Student ID          : ");
string studentID = Console.ReadLine() ?? "";

Console.Write("Enter Course              : ");
string course = Console.ReadLine() ?? "";

Console.Write("Enter Semester            : ");
string semester = Console.ReadLine() ?? "";

Console.WriteLine();
Console.WriteLine("--- Enter Subject Marks (out of 100) ---");

Console.Write("Mathematics               : ");
double maths = double.Parse(Console.ReadLine());

Console.Write("Programming               : ");
double programming = double.Parse(Console.ReadLine());

Console.Write("Database Systems          : ");
double database = double.Parse(Console.ReadLine());

Console.Write("Networking                : ");
double networking = double.Parse(Console.ReadLine());

Console.Write("Communication Skills      : ");
double english = double.Parse(Console.ReadLine());

// Create student object via constructor
Student student = new Student(studentName, studentID, course, semester,
                               maths, programming, database, networking, english);

double average = student.ComputeAverage();
string remark  = student.GetOverallRemark(average);

// Display Result Slip
Console.WriteLine();
Console.WriteLine("========================================");
Console.WriteLine("          KCA UNIVERSITY");
Console.WriteLine("       STUDENT RESULT SLIP");
Console.WriteLine("========================================");
Console.WriteLine($"Student Name  : {student.StudentName}");
Console.WriteLine($"Student ID    : {student.StudentID}");
Console.WriteLine($"Course        : {student.Course}");
Console.WriteLine($"Semester      : {student.Semester}");
Console.WriteLine("----------------------------------------");
Console.WriteLine($"{"Subject",-25} {"Marks",6}  {"Grade",5}");
Console.WriteLine("----------------------------------------");
Console.WriteLine($"{"Mathematics",-25} {student.MathsMarks,6}  {student.GetGrade(student.MathsMarks),5}");
Console.WriteLine($"{"Programming",-25} {student.ProgrammingMarks,6}  {student.GetGrade(student.ProgrammingMarks),5}");
Console.WriteLine($"{"Database Systems",-25} {student.DatabaseMarks,6}  {student.GetGrade(student.DatabaseMarks),5}");
Console.WriteLine($"{"Networking",-25} {student.NetworkingMarks,6}  {student.GetGrade(student.NetworkingMarks),5}");
Console.WriteLine($"{"Communication Skills",-25} {student.EnglishMarks,6}  {student.GetGrade(student.EnglishMarks),5}");
Console.WriteLine("----------------------------------------");
Console.WriteLine($"{"Average",-25} {average,6:F1}");
Console.WriteLine($"{"Overall Remark",-25} {remark,6}");
Console.WriteLine("========================================");

// Save to database
using (var db = new DataContext())
{
    var record = new ResultRecord
    {
        StudentName      = student.StudentName,
        StudentID        = student.StudentID,
        Course           = student.Course,
        Semester         = student.Semester,
        MathsMarks       = student.MathsMarks,
        ProgrammingMarks = student.ProgrammingMarks,
        DatabaseMarks    = student.DatabaseMarks,
        NetworkingMarks  = student.NetworkingMarks,
        EnglishMarks     = student.EnglishMarks,
        AverageMarks     = average,
        OverallRemark    = remark,
        DateRecorded     = DateTime.Now
    };

    db.Results.Add(record);
    db.SaveChanges();

    Console.WriteLine();
    Console.WriteLine($"Record saved to database. Total records: {db.Results.Count()}");
}
