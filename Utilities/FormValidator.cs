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
        public static (bool, Employee) IsValidFormData(string firstName, string lastName, string emailId, string jobTitle, string dept, string salary, string experience, DateTime dob, string contactNumber)
        {

            long phoneNumber;
            int experienceInYears;
            decimal MonthlySalary;
            if (IsValidString(firstName) && IsValidString(lastName) && IsValidString(jobTitle) && IsValidString(dept))
            {
                if (IsValidEmailFormat(emailId) || EmployeeData.Employees.Any(emp => emp.Email.Equals(emailId, StringComparison.OrdinalIgnoreCase)))
                {
                    if (decimal.TryParse(salary, out MonthlySalary))
                    {
                        if (int.TryParse(experience, out experienceInYears))
                        {
                            if (long.TryParse(contactNumber,out phoneNumber))
                            {
                                if (DateTime.Today.Year - dob.Year > 20)
                                {
                                    Employee employee = new Employee();
                                    employee.FirstName = firstName;
                                    employee.LastName = lastName;
                                    employee.PreferredName = $"{firstName} {lastName}";
                                    employee.Email = emailId;
                                    employee.JobTitle = jobTitle;
                                    employee.Department = dept;
                                    employee.ExperienceInYears = experienceInYears;
                                    employee.Salary = MonthlySalary;
                                    employee.ContactNumber = phoneNumber;
                                    employee.Dob = dob;
                                    return (true, employee);
                                }
                                else
                                    MessageBox.Show("Invalid DOB");
                            }
                            else
                                MessageBox.Show("Invalid phone number");
                        }
                        else
                            MessageBox.Show("Invalid experience. Should enter only digits");
                    }
                    else
                        MessageBox.Show("invalid salary");
                }
                else
                    MessageBox.Show("invalid Mail");

            }
            return (false, null);
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
