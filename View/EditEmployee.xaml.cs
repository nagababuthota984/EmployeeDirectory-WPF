using EmployeeDirectory_WPF.Data;
using EmployeeDirectory_WPF.Models;
using EmployeeDirectory_WPF.Utilities;
using System;
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
    public partial class EditEmployee : UserControl
    {
        public EditEmployee()
        {
            InitializeComponent();
        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new HomeView();
        }
        private void UpdateEmployeeDetails(object sender, RoutedEventArgs e)
        {
            (bool, Employee) tpl = FormValidator.IsValidFormData(fname.Text, lname.Text, email.Text, jobtitle.Text, department.Text, salary.Text, experience.Text,(DateTime)dob.SelectedDate);
            if (tpl.Item1 && tpl.Item2 != null)
            {
                EmployeeData.Employees.Remove(EmployeeData.Employees.FirstOrDefault(emp=> emp.Email.Equals(tpl.Item2.Email,StringComparison.OrdinalIgnoreCase)));
                EmployeeData.Employees.Add(tpl.Item2);
                EmployeeData.WriteToJson("Employee");
                MessageBox.Show("Updated Successfully");
            }
        }
      
    }
}
