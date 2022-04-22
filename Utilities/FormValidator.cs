using EmployeeDirectory_WPF.Data;
using EmployeeDirectory_WPF.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace EmployeeDirectory_WPF.Utilities
{
    public class FormValidator
    {
        public static bool IsValidFormData(Employee emp)
        {

            if (IsValidString(emp.FirstName) && IsValidString(emp.LastName) && IsValidString(emp.JobTitle) && IsValidString(emp.Department))
            {
                if (IsValidEmailFormat(emp.Email) || EmployeeData.Employees.Any(emp => emp.Email.Equals(emp.Email, StringComparison.OrdinalIgnoreCase)))
                {

                    if (DateTime.Today.Year - emp.Dob.Year > 20)
                    {
                        Employee employee = new Employee();
                        employee.FirstName = emp.FirstName;
                        employee.LastName = emp.LastName;
                        employee.PreferredName = $"{emp.FirstName} {emp.LastName}";
                        employee.Email = emp.Email;
                        employee.JobTitle = emp.JobTitle;
                        employee.Department = emp.Department;
                        employee.ExperienceInYears = emp.ExperienceInYears;
                        employee.Salary = emp.Salary;
                        employee.ContactNumber = emp.ContactNumber;
                        employee.Dob = emp.Dob;
                        return true;
                    }
                    else
                        MessageBox.Show("Invalid Dob");
                }
                MessageBox.Show("invalid Mail");

            }
            return false;
        }
        public static bool IsValidEmailFormat(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            else
                return false;
        }
        public static bool IsValidString(string text)
        {
            if (string.IsNullOrEmpty(text) || text.Any(char.IsDigit))
            {
                return false;
            }
            return true;
        }

    }
}
