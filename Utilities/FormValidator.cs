﻿using EmployeeDirectory_WPF.Data;
using EmployeeDirectory_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeDirectory_WPF.Utilities
{
    public class FormValidator
    {
        public static (bool,Employee) IsValidFormData(string firstName,string lastName,string emailId,string jobTitle,string dept,string salary,string experience)
        {
            
            long phoneNumber = 8464832529;
            int experienceInYears;
            decimal MonthlySalary;
            if (FormValidator.IsValidString(firstName) && FormValidator.IsValidString(lastName) && FormValidator.IsValidString(jobTitle) && FormValidator.IsValidString(dept))
            {
                if (FormValidator.IsValidEmailFormat(emailId) || EmployeeData.Employees.Any(emp => emp.Email.Equals(emailId, StringComparison.OrdinalIgnoreCase)))
                {
                    if (decimal.TryParse(salary, out MonthlySalary))
                    {
                        if (int.TryParse(experience, out experienceInYears))
                        {
                            Employee employee = new Employee();
                            employee.FirstName = firstName;
                            employee.LastName = lastName;
                            employee.Email = emailId;
                            employee.JobTitle = jobTitle;
                            employee.Department = dept;
                            employee.ExperienceInYears = experienceInYears;
                            employee.Salary = MonthlySalary;
                            employee.ContactNumber = phoneNumber;
                            return (true,employee);
                        }
                        MessageBox.Show("Invalid exp");
                    }
                    MessageBox.Show("invalid salary");
                }
                MessageBox.Show("invalid Mail");

            }
            return (false,null);
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
