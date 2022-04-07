using EmployeeDirectory_WPF.Data;
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

namespace EmployeeDirectory_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            EmployeeCards.ItemsSource = EmployeeData.Employees;
            DepartmentsDiv.ItemsSource = EmployeeData.Departments;
            OfficesDiv.ItemsSource = EmployeeData.Offices;
            JobTitlesDiv.ItemsSource = EmployeeData.JobTitles;
        }

    }
}
