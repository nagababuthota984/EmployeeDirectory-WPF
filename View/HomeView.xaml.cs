using EmployeeDirectory_WPF.Data;
using EmployeeDirectory_WPF.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static EmployeeDirectory_WPF.Models.Enums;

using EmployeeDirectory_WPF.Converters;
namespace EmployeeDirectory_WPF.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public List<Employee> filteredData = EmployeeData.Employees;
        public static EmployeeDetailsView EmpDetailsView;
        public Employee SelectedEmployee = null;

        public HomeView()
        {
            InitializeComponent();
            EmployeeCards.ItemsSource = filteredData;
            DepartmentsDiv.ItemsSource = EmployeeData.Departments;
            JobTitlesDiv.ItemsSource = EmployeeData.JobTitles;
            Filter.ItemsSource = Enum.GetNames(typeof(FilterCategories));
            Filter.SelectedValue = Filter.Items[0];
            EmpDetailsView = new EmployeeDetailsView();
            SelectedEmployee = new Employee();
            JsonHelper.WriteToJson<GeneralFilter>();

        }
        public void FiltersClickHandler(object sender, SelectionChangedEventArgs e)
        {
            var lbox = sender as ListBox;
            if (lbox.Name.Equals("DepartmentsDiv"))
            {
                var dept = (GeneralFilter)lbox.SelectedItem;
                EmployeeCards.ItemsSource = GetEmployeesByDept(dept.Name);
            }
            else
            {
                var jobTitle = (GeneralFilter)lbox.SelectedItem;
                EmployeeCards.ItemsSource = GetEmployeesByJobTitle(jobTitle.Name);
            }
        }
        private IEnumerable GetEmployeesByJobTitle(string filterValue)
        {
            return filteredData = EmployeeData.Employees.Where(emp => emp.JobTitle.Equals(filterValue, StringComparison.OrdinalIgnoreCase)).ToList(); ;
        }
        private List<Employee> GetEmployeesByDept(string filterValue)
        {
            return filteredData = EmployeeData.Employees.Where(emp => emp.Department.Equals(filterValue, StringComparison.OrdinalIgnoreCase)).ToList();
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
            if (!string.IsNullOrEmpty(textToCompare))
            {
                return filteredData.Where(emp => (filterCategory.Contains("Name") && emp.PreferredName.Contains(textToCompare, StringComparison.OrdinalIgnoreCase)) || (filterCategory.Contains("Email") && emp.Email.Contains(textToCompare, StringComparison.OrdinalIgnoreCase)) || (filterCategory.Contains("ContactNumber") && emp.ContactNumber.ToString().Contains(textToCompare))).ToList();
            }
            else
                return EmployeeData.Employees;
        }

        private void OpenAddEmployeeForm(object sender, RoutedEventArgs e)
        {
            Main.Visibility = Visibility.Collapsed;
            EmpDetailsView.Heading.Text = "New Employee Details";
            EmpDetailsView.SubmitBtn.Content = "Add Employee";
            EmpDetailsView.email.IsEnabled = true;
            EmpDetailsView.SubmitBtn.Click += EmpDetailsView.HandleAddEmployee;
            UserControlSpace.Visibility = Visibility.Visible;
            UserControlSpace.Content = EmpDetailsView;
        }

        private void EditEmployeeDetails(object sender, SelectionChangedEventArgs e)
        {
            Main.Visibility = Visibility.Collapsed;
            SelectedEmployee = (Employee)EmployeeCards.SelectedItem;
            EmpDetailsView.LoadFormContent(SelectedEmployee);
            EmpDetailsView.Heading.Text = "Edit Employee Details";
            EmpDetailsView.SubmitBtn.Content = "Update Details";
            EmpDetailsView.SubmitBtn.Click += EmpDetailsView.UpdateEmployeeDetails;
            UserControlSpace.Visibility = Visibility.Visible;
            UserControlSpace.Content = EmpDetailsView;

        }


        private void FilterSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0 && e.AddedItems[0].ToString().Split(":").Length > 1)
            {
                EmployeeCards.ItemsSource = GetSearchFilteredData(Search.Text, e.AddedItems[0].ToString().Split(":")[1].Trim());
            }
        }


    }
}
