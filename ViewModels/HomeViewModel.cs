using EmployeeDirectory_WPF.Models;
using System;

namespace EmployeeDirectory_WPF.ViewModels
{
    public class HomeViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public int ExperienceInYears { get; set; }
        public long ContactNumber { get; set; }
        public decimal Salary { get; set; }
        
        public HomeViewModel(Employee employee)
        {
            this.Name = $"{employee.FirstName} {employee.LastName}";
            this.Email = employee.Email;
            this.Age = DateTime.Today.Year - employee.Dob.Year;
            this.JobTitle = employee.JobTitle;
            this.Department = employee.Department;
            this.ExperienceInYears = employee.ExperienceInYears;
            this.ContactNumber = employee.ContactNumber;
            this.Salary = employee.Salary;
        }
        public static HomeViewModel EmployeeToHomeViewModel(Employee emp)
        {
            return new HomeViewModel(emp);
        }
    }
}
