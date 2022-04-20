using EmployeeDirectory_WPF.Data;
using EmployeeDirectory_WPF.Models;
using EmployeeDirectory_WPF.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EmployeeDirectory_WPF.View
{
    /// <summary>
    /// Interaction logic for EmployeeDetailsView.xaml
    /// </summary>
    public partial class EmployeeDetailsView : UserControl
    {
        public EmployeeDetailsView()
        {
            InitializeComponent();
        }
        private void OnCancel(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new HomeView();
        }
        public void LoadFormContent(Employee emp)
        {
            if (emp != null)
            {
                fname.Text = emp.FirstName;
                lname.Text = emp.LastName;
                email.Text = emp.Email;
                jobtitle.Text = emp.JobTitle;
                department.Text = emp.Department;
                dob.SelectedDate = emp.Dob;
                salary.Text = emp.Salary.ToString();
                experience.Text = emp.ExperienceInYears.ToString();
            }
        }
        public void UpdateEmployeeDetails(object sender, RoutedEventArgs e)
        {
            (bool, Employee) tpl = FormValidator.IsValidFormData(fname.Text, lname.Text, email.Text, jobtitle.Text, department.Text, salary.Text, experience.Text, (DateTime)dob.SelectedDate);
            if (tpl.Item1 && tpl.Item2 != null)
            {
                EmployeeData.Employees.Remove(EmployeeData.Employees.FirstOrDefault(emp => emp.Email.Equals(tpl.Item2.Email, StringComparison.OrdinalIgnoreCase)));
                EmployeeData.Employees.Add(tpl.Item2);
                EmployeeData.WriteToJson("Employee");
                MessageBox.Show("Updated Successfully");
            }
        }
        public void HandleAddEmployee(object sender, RoutedEventArgs e)
        {
            (bool, Employee) tpl = FormValidator.IsValidFormData(fname.Text, lname.Text, email.Text, jobtitle.Text, department.Text, salary.Text, experience.Text, (DateTime)dob.SelectedDate);
            if (tpl.Item1 && tpl.Item2 != null)
            {
                EmployeeData.Employees.Add(tpl.Item2);
                AddDepartment(tpl.Item2.Department);
                AddJobTitle(tpl.Item2.JobTitle);
                MessageBox.Show($"{tpl.Item2.FirstName} has been added successfully");
            }
        }
        private void AddJobTitle(string jobTitle)
        {
            if (!string.IsNullOrEmpty(jobTitle))
            {
                KeyValuePair<string, int> job = EmployeeData.JobTitles.FirstOrDefault(jt => jt.Key.Equals(jobTitle, StringComparison.OrdinalIgnoreCase));
                if (job.Key != null)
                    EmployeeData.JobTitles[job.Key] += 1;
                else
                    EmployeeData.JobTitles.Add(jobTitle, 1);
            }
        }
        private void AddDepartment(string department)
        {
            if (!string.IsNullOrEmpty(department))
            {
                KeyValuePair<string, int> job = EmployeeData.Departments.FirstOrDefault(jt => jt.Key.Equals(department, StringComparison.OrdinalIgnoreCase));
                if (job.Key != null)
                    EmployeeData.Departments[job.Key] += 1;
                else
                    EmployeeData.Departments.Add(department, 1);
            }
        }
    }
}
