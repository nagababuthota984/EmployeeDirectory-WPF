using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmployeeDirectory_WPF.Models.Enums;

namespace EmployeeDirectory_WPF.Models
{
    public class Employee
    {
        #region Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PreferredName { get; set; }
        public string Email { get; set; }
        public DateOnly Dob { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public int ExperienceInYears { get; set; }
        public long ContactNumber { get; set; }
        public decimal Salary { get; set; }
        public EmployementType EmploymentType { get; set; }
        #endregion

        public Employee(string firstName, string lastName, string email, DateOnly dob, string jobtitle, string department, int experienceInYears,long phoneNumber,decimal salary,EmployementType empType)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PreferredName = firstName +" "+ lastName;
            this.Email = email;
            this.Dob = dob;
            this.JobTitle = jobtitle;
            this.Department = department;
            this.ExperienceInYears = experienceInYears;
            this.Salary = salary;
            this.ContactNumber = phoneNumber;
            this.EmploymentType = empType;
        }
    }

}
