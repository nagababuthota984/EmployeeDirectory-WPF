using EmployeeDirectory_WPF.Models;
using EmployeeDirectory_WPF.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace EmployeeDirectory_WPF.Data
{
    public class EmployeeData
    {
        public static List<Employee> Employees = new List<Employee>();
        public static List<HomeViewModel> HomeViewModels = new List<HomeViewModel>();
        public static Dictionary<string, int> Departments = new Dictionary<string, int>();
        public static Dictionary<string, int> JobTitles = new Dictionary<string, int>();
    }
}
