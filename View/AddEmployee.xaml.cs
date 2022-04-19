﻿using EmployeeDirectory_WPF.Data;
using EmployeeDirectory_WPF.Models;
using EmployeeDirectory_WPF.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeeDirectory_WPF.View
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : UserControl
    {
        public AddEmployee()
        {
            InitializeComponent();
        }
        

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new HomeView();
            
        }

        private void HandleAddEmployee(object sender, RoutedEventArgs e)
        {
           

            (bool,Employee) tpl = FormValidator.IsValidFormData(fname.Text, lname.Text, email.Text, jobtitle.Text, department.Text, salary.Text, experience.Text, dob.SelectedDate);
            if (tpl.Item1 && tpl.Item2!=null)
            {
                EmployeeData.Employees.Add(tpl.Item2);
                AddDepartment(tpl.Item2.Department);
                AddJobTitle(tpl.Item2.JobTitle);
                MessageBox.Show($"{tpl.Item2.FirstName} has been added successfully");
            }
        }

        private void AddJobTitle(string jobTitle)
        {
            if(!string.IsNullOrEmpty(jobTitle))
            {
                foreach(var job in EmployeeData.JobTitles.Keys)
                {
                    if(job.ToLower().Trim().Equals(jobTitle.ToLower().Trim()))
                    {
                        EmployeeData.JobTitles[job] += 1;
                        return;
                    }
                }
                EmployeeData.JobTitles.Add(jobTitle, 1);
            }
        }

        private void AddDepartment(string department)
        {
            if (!string.IsNullOrEmpty(department))
            {
                foreach (var job in EmployeeData.Departments.Keys)
                {
                    if (job.ToLower().Trim().Equals(department.ToLower().Trim()))
                    {
                        EmployeeData.Departments[job] += 1;
                        return;
                    }
                }
                EmployeeData.Departments.Add(department, 1);
            }
        }
    }
}