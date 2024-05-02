using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid
{
    internal class SRP
    {
        public class Employee
        {
            public string Name { get; set; }
            public decimal Salary { get; set; }
            public string Department { get; set; }
        }
        public class SalaryCalculator
        {
            public decimal CalculateYearlySalary(decimal monthlySalary)
            {
                return monthlySalary * 12;
            }
        }
        public class ReportGenerator
        {
            public void GenerateReport(string reportType, Employee employee)
            {
                Console.WriteLine($"Report By {reportType}\nEmployee ->\nName: {employee.Name}\nSalary: {employee.Salary}\nDepartment: {employee.Department}");
            }
        }
        public class EmailService
        {
            public void SendNotification(string receive, string message)
            {
                Console.WriteLine($"Email To {receive} Have {message}");
            }
        }
    }
}
