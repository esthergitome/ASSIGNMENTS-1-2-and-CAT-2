using System;
using System.Collections.Generic;

class Employee
{
    public int EmployeeID;
    public string FirstName;
    public string SecondName;
    public string Surname;
    public char Gender;
    public string DateOfBirth;
    public double BasicSalary;
//constructor to initialize employee details
    public Employee(int id, string fname, string sname, string lname,
                    char gender, string dob, double salary)
    {
        EmployeeID = id;
        FirstName = fname;
        SecondName = sname;
        Surname = lname;
        Gender = gender;
        DateOfBirth = dob;
        BasicSalary = salary;
    }
// display employee details
    public void ShowEmployee()
    {
        Console.WriteLine("\nEMPLOYEE DETAILS");
        Console.WriteLine("ID NUMBER      : " + EmployeeID);
        Console.WriteLine("FIRST NAME     : " + FirstName);
        Console.WriteLine("SECOND NAME    : " + SecondName);
        Console.WriteLine("SURNAME        : " + Surname);
        Console.WriteLine("GENDER         : " + Gender);
        Console.WriteLine("DATE OF BIRTH  : " + DateOfBirth);
        Console.WriteLine("BASIC SALARY   : Ksh. " + BasicSalary);
    }
}
// implemented as a static method in a separate class to compute pension contribution
class Pension
{
    public static double ComputePension(Employee emp)
    {
        return emp.BasicSalary * 0.05;
    }
}

class Program
{
    static void Main()
    {
        // in-memory database to store employee records
        List<Employee> database = new List<Employee>();

        Console.WriteLine("ADD EMPLOYEE DETAILS");

        Console.Write("ENTER ID NUMBER: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("ENTER FIRST NAME: ");
        string fname = Console.ReadLine();

        Console.Write("ENTER SECOND NAME: ");
        string sname = Console.ReadLine();

        Console.Write("ENTER SURNAME: ");
        string lname = Console.ReadLine();

        Console.Write("ENTER GENDER (M or F): ");
        char gender = Convert.ToChar(Console.ReadLine());

        Console.Write("ENTER DATE OF BIRTH (dd-mm-yyyy): ");
        string dob = Console.ReadLine();

        Console.Write("ENTER BASIC SALARY IN KSH: ");
        double salary = Convert.ToDouble(Console.ReadLine());

// implemnentation of the employee class to create an employee object and add it to the database
        Employee emp_obj = new Employee(id, fname, sname, lname, gender, dob, salary);

        database.Add(emp_obj);

        emp_obj.ShowEmployee();

        double pension = Pension.ComputePension(emp_obj);

        Console.WriteLine("PENSION CONTRIBUTION (5%): Ksh. " + pension);
    }
}