using EmployeeDirectory_WPF.Data;
using EmployeeDirectory_WPF.Models;
using EmployeeDirectory_WPF.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace EmployeeDirectory_WPF.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public List<HomeViewModel> filteredData;
        public static EmployeeDetailsView EmpDetailsView;
        public Employee SelectedEmployee;

        public HomeView()
        {
            InitializeComponent();
            DepartmentsDiv.ItemsSource = EmployeeData.Departments;
            JobTitlesDiv.ItemsSource = EmployeeData.JobTitles;
            EmpDetailsView = new EmployeeDetailsView();
            SelectedEmployee = new Employee();
            filteredData = EmployeeData.HomeViewModels;
            EmployeeCards.ItemsSource = filteredData;

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
            filteredData = EmployeeData.HomeViewModels.Where(emp => emp.JobTitle.Equals(filterValue, StringComparison.OrdinalIgnoreCase)).ToList(); ;
            return filteredData;
        }
        private List<HomeViewModel> GetEmployeesByDept(string filterValue)
        {
            filteredData = EmployeeData.HomeViewModels.Where(emp => emp.Department.Equals(filterValue, StringComparison.OrdinalIgnoreCase)).ToList();
            return filteredData;
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
        private List<HomeViewModel> GetSearchFilteredData(string textToCompare, string filterCategory)
        {
            if (!string.IsNullOrEmpty(textToCompare))
            {
                return filteredData.Where(emp => (filterCategory.Contains("Name") && emp.Name.Contains(textToCompare, StringComparison.OrdinalIgnoreCase)) || (filterCategory.Contains("Email") && emp.Email.Contains(textToCompare, StringComparison.OrdinalIgnoreCase)) || (filterCategory.Contains("ContactNumber") && emp.ContactNumber.ToString().Contains(textToCompare))).ToList();
            }
            else
                return EmployeeData.HomeViewModels;


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

        private void EditEmployeeDetails(object sender, MouseButtonEventArgs e)
        {
            Main.Visibility = Visibility.Collapsed;
            HomeViewModel clicked = (HomeViewModel)EmployeeCards.SelectedItem;
            if (clicked != null)
            {
                SelectedEmployee = EmployeeData.Employees.FirstOrDefault(emp => emp.Email.Equals(clicked.Email, StringComparison.OrdinalIgnoreCase));
                EmpDetailsView.LoadFormContent(SelectedEmployee);
                EmpDetailsView.Heading.Text = "Edit Employee Details";
                EmpDetailsView.SubmitBtn.Content = "Update Details";
                EmpDetailsView.SubmitBtn.Click += EmpDetailsView.UpdateEmployeeDetails;
                UserControlSpace.Visibility = Visibility.Visible;
                UserControlSpace.Content = EmpDetailsView;
                
            }
            

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
