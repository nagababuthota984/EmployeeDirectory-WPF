using EmployeeDirectory_WPF.Models;
using EmployeeDirectory_WPF.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace EmployeeDirectory_WPF.Data
{
    public class JsonHelper
    {
        public static string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

        public static void WriteToJson(string typeOfData)
        {
            string data = JsonConvert.SerializeObject(typeof(EmployeeData).GetProperty(typeOfData), Formatting.Indented);
            File.WriteAllText($"{projectDirectory}\\Data\\{typeOfData}.json", data);
        }
        public static string ReadFromJson(string typeOfData)
        {
            return File.ReadAllText($"{projectDirectory}\\Data\\{typeOfData}.json");

        }
        public static void InitEmployeeData()
        {
            string data = ReadFromJson("Employee");
            if (string.IsNullOrEmpty(data))
                EmployeeData.Employees = new List<Employee>();
            else
            {
                EmployeeData.Employees = JsonConvert.DeserializeObject<List<Employee>>(data);
                EmployeeData.HomeViewModels = EmployeeData.Employees.ConvertAll<HomeViewModel>(new Converter<Employee, HomeViewModel>(HomeViewModel.EmployeeToHomeViewModel));
            }
        }
        public static void InitJobTitlesData()
        {
            string data = ReadFromJson("JobTitles");
            if (!string.IsNullOrEmpty(data))
                EmployeeData.JobTitles = JsonConvert.DeserializeObject<Dictionary<string, int>>(data);
            else
                EmployeeData.JobTitles = new Dictionary<string, int>();
        }
        public static void InitDepartmentsData()
        {
            string data = ReadFromJson("Departments");
            if (!string.IsNullOrEmpty(data))
                EmployeeData.Departments = JsonConvert.DeserializeObject<Dictionary<string, int>>(data);
            else
                EmployeeData.Departments = new Dictionary<string, int>();
        }
    }

}
