﻿using EmployeeDirectory_WPF.Data;
using EmployeeDirectory_WPF.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public List<Employee> filteredData = EmployeeData.Employees;

        public HomeView()
        {
            InitializeComponent();
            EmployeeCards.ItemsSource = filteredData;
            DepartmentsDiv.ItemsSource = EmployeeData.Departments;
            JobTitlesDiv.ItemsSource = EmployeeData.JobTitles;


        }
        public void FiltersClickHandler(object sender, SelectionChangedEventArgs e)
        {
            var lbox = sender as ListBox;
            if (lbox.SelectedItem.ToString() != null)
            {
                string filterValue = lbox.SelectedItem.ToString().Replace('[', ',').Split(',')[1];
                string filterName = lbox.Name;
                if (filterName.Equals("DepartmentsDiv", StringComparison.OrdinalIgnoreCase))
                    EmployeeCards.ItemsSource = GetEmployeesByDept(filterValue);
                else
                    EmployeeCards.ItemsSource = GetEmployeesByJobTitle(filterValue);
            }
        }

        private IEnumerable GetEmployeesByJobTitle(string filterValue)
        {
            List<Employee> jobTitleFilteredData = new List<Employee>();
            foreach (Employee employee in EmployeeData.Employees)
            {
                if (employee.JobTitle.Equals(filterValue, StringComparison.OrdinalIgnoreCase))
                {
                    jobTitleFilteredData.Add(employee);
                }
            }
            filteredData = jobTitleFilteredData;
            return filteredData;
        }



        private List<Employee> GetEmployeesByDept(string filterValue)
        {
            List<Employee> deptFilteredData = new List<Employee>();
            foreach (Employee employee in EmployeeData.Employees)
            {
                if (employee.Department.Equals(filterValue, StringComparison.OrdinalIgnoreCase))
                {
                    deptFilteredData.Add(employee);
                }
            }
            filteredData = deptFilteredData;
            return deptFilteredData;
        }

        private void HandleSearchKeyUp(object sender, KeyEventArgs e)
        {
            var tb = sender as TextBox;
            var filterCategory = Filter.Text;
            if (tb != null)
            {
                EmployeeCards.ItemsSource = GetSearchFilteredData(tb.Text, filterCategory);
            }
        }
        private List<Employee> GetSearchFilteredData(string textToCompare, string filterCategory)
        {
            List<Employee> searchFilteredData = new List<Employee>();

            if (filterCategory.Equals("Name"))
            {
                foreach (Employee employee in filteredData)
                {
                    if (employee.PreferredName.Contains(textToCompare, StringComparison.OrdinalIgnoreCase))
                    {
                        searchFilteredData.Add(employee);
                    }
                } 
            }
            else if(filterCategory.Equals("Email"))
            {
                foreach (Employee employee in filteredData)
                {
                    if (employee.Email.Contains(textToCompare, StringComparison.OrdinalIgnoreCase))
                    {
                        searchFilteredData.Add(employee);
                    }
                }
            }
            else
            {
                foreach (Employee employee in filteredData)
                {
                    if (employee.ContactNumber.ToString().Contains(textToCompare, StringComparison.OrdinalIgnoreCase))
                    {
                        searchFilteredData.Add(employee);
                    }
                }
            }
            return searchFilteredData;
        }

        private void OpenAddEmployeeForm(object sender, RoutedEventArgs e)
        {

            Main.Visibility = Visibility.Collapsed;
            addEmpView.Visibility = Visibility.Visible;

        }

        private void EditEmployeeDetails(object sender, RoutedEventArgs e)
        {
            Main.Visibility = Visibility.Collapsed;
            EditEmpView.Visibility = Visibility.Visible;
            var btn = sender as Button;
            if (btn != null)
            {
                string firstName, lastName;
                firstName = btn.Content.ToString().Split(' ')[0];
                lastName = btn.Content.ToString().Split(' ')[1];

                if (!string.IsNullOrWhiteSpace(firstName) || !string.IsNullOrEmpty(lastName))
                {
                    Employee emp = GetEmployeeByName(firstName + ' ' + lastName);
                    if (emp != null)
                    {
                        EditEmpView.fname.Text = emp.FirstName;
                        EditEmpView.lname.Text = emp.LastName;
                        EditEmpView.email.Text = emp.Email;
                        EditEmpView.jobtitle.Text = emp.JobTitle;
                        EditEmpView.department.Text = emp.Department;
                        EditEmpView.dob.SelectedDate = emp.Dob;
                        EditEmpView.salary.Text = emp.Salary.ToString();
                        EditEmpView.experience.Text = emp.ExperienceInYears.ToString();
                    }
                }
            }
        }

        private Employee GetEmployeeByName(string preferredName)
        {
            foreach (var emp in EmployeeData.Employees)
            {
                if (preferredName.Equals(emp.PreferredName, StringComparison.OrdinalIgnoreCase))
                    return emp;
            }
            return null;

        }
        
        private void FilterSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EmployeeCards.ItemsSource = GetSearchFilteredData(Search.Text, Filter.Text);
        }
    }
}