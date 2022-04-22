using EmployeeDirectory_WPF.Data;
using EmployeeDirectory_WPF.Models;
using EmployeeDirectory_WPF.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using static EmployeeDirectory_WPF.Models.Enums;

namespace EmployeeDirectory_WPF.View
{
    /// <summary>
    /// Interaction logic for EmployeeDetailsView.xaml
    /// </summary>
    public partial class EmployeeDetailsView : UserControl
    {
        public Employee currentEmployee;
        public EmployeeDetailsView()
        {
            InitializeComponent();
            currentEmployee = new Employee();
        }
        private void OnCancel(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new HomeView();
        }
        public void LoadContentIntoForm(Employee emp)
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
                contactNumber.Text = emp.ContactNumber.ToString();
                currentEmployee = emp;
            }
        }
        public Employee ConvertFormContentToEmployee()
        {
            if (int.TryParse(experience.Text, out int exp) && decimal.TryParse(salary.Text, out decimal sal) && long.TryParse(contactNumber.Text, out long phone) && DateTime.TryParse(dob.SelectedDate.ToString(),out DateTime dateOfBirth))
            {
                currentEmployee.FirstName = fname.Text;
                currentEmployee.LastName = lname.Text;
                currentEmployee.Email = email.Text;
                currentEmployee.JobTitle = jobtitle.Text;
                currentEmployee.Department = department.Text;
                currentEmployee.ExperienceInYears = exp;
                currentEmployee.Salary = sal;
                currentEmployee.ContactNumber = phone;
                currentEmployee.Dob = dateOfBirth;
                return currentEmployee;
            }
            return null;

        }
        public void UpdateEmployeeDetails(object sender, RoutedEventArgs e)
        {
            currentEmployee = ConvertFormContentToEmployee();
            if (FormValidator.IsValidFormData(currentEmployee))
            {
                EmployeeData.Employees.Remove(EmployeeData.Employees.FirstOrDefault(emp => emp.Email.Equals(currentEmployee.Email, StringComparison.OrdinalIgnoreCase)));
                EmployeeData.Employees.Add(currentEmployee);
                JsonHelper.WriteToJson<Employee>();
                JsonHelper.WriteToJson<GeneralFilter>();
                MessageBox.Show("Updated Successfully");
                Application.Current.MainWindow.Content = new HomeView();
            }
        }
        public void HandleAddEmployee(object sender, RoutedEventArgs e)
        {
            currentEmployee = ConvertFormContentToEmployee();
            if (FormValidator.IsValidFormData(currentEmployee))
            {
                currentEmployee.PreferredName = $"{currentEmployee.FirstName} {currentEmployee.LastName}";
                EmployeeData.Employees.Add(currentEmployee);
                AddDepartment(currentEmployee.Department);
                AddJobTitle(currentEmployee.JobTitle);
                JsonHelper.WriteToJson<Employee>();
                JsonHelper.WriteToJson<GeneralFilter>();
                MessageBox.Show($"{currentEmployee.FirstName} has been added successfully");
            }
        }
        private void AddJobTitle(string jobTitle)
        {
            if (!string.IsNullOrEmpty(jobTitle))
            {
                GeneralFilter job = EmployeeData.JobTitles.FirstOrDefault(jt => (jt.Category == GeneralFilterCategories.JobTitle && jt.Name.Equals(jobTitle, StringComparison.OrdinalIgnoreCase)));
                if (job != null)
                    job.Count += 1;
                else
                    EmployeeData.JobTitles.Add(new GeneralFilter { Name = jobTitle, Count = 1, Category = GeneralFilterCategories.JobTitle });
            }
        }
        private void AddDepartment(string department)
        {
            if (!string.IsNullOrEmpty(department))
            {
                GeneralFilter dept = EmployeeData.Departments.FirstOrDefault(jt => jt.Name.Equals(department, StringComparison.OrdinalIgnoreCase));
                if (dept != null)
                    dept.Count += 1;
                else
                    EmployeeData.Departments.Add(new GeneralFilter { Name = department, Count = 1, Category = GeneralFilterCategories.Department });
            }
        }
    }
}
