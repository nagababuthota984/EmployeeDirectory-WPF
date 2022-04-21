using EmployeeDirectory_WPF.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace EmployeeDirectory_WPF.Data
{
    public class EmployeeData
    {
        public static string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

        public static List<Employee> Employees = new List<Employee>();
        public static List<GeneralFilter> Departments = new List<GeneralFilter>();
        public static List<GeneralFilter> JobTitles = new List<GeneralFilter>();

    }
}
