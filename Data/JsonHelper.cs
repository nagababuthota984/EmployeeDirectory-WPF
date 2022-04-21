using EmployeeDirectory_WPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using static EmployeeDirectory_WPF.Models.Enums;

namespace EmployeeDirectory_WPF.Data
{
    public class JsonHelper
    {
        public static string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

        public static void WriteToJson<T>()
        {
            string data;
            string type = typeof(T).ToString();
            

            if (typeof(T) == typeof(Employee))
            {
                data = JsonConvert.SerializeObject(typeof(EmployeeData).GetProperty(typeof(T).ToString()), Formatting.Indented);
                File.WriteAllText($"{projectDirectory}\\Data\\{typeof(T)}.json", data);
            }
            else if(typeof(T) == typeof(GeneralFilter))
            {
                List<GeneralFilter> lst = new List<GeneralFilter>();
                lst.AddRange(EmployeeData.JobTitles);
                lst.AddRange(EmployeeData.Departments);
                data = JsonConvert.SerializeObject(lst,Formatting.Indented);
                File.WriteAllText($"{projectDirectory}\\Data\\GeneralFilters.json", data);

            }
        }
        public static string ReadFromJson(string typeOfData)
        {
            return File.ReadAllText($"{projectDirectory}\\Data\\{typeOfData}.json");

        }
        public static void InitEmployeeData()
        {
            string data = ReadFromJson("Employee");
            if (!string.IsNullOrEmpty(data))
                EmployeeData.Employees = JsonConvert.DeserializeObject<List<Employee>>(data);
            
        }
        public static void InitGeneralFiltersData()
        {
            string data = ReadFromJson("GeneralFilters");
            if (!string.IsNullOrEmpty(data))
            {
                EmployeeData.JobTitles = JsonConvert.DeserializeObject<List<GeneralFilter>>(data).Where(filter => filter.Category == GeneralFilterCategories.JobTitle).ToList();
                EmployeeData.Departments = JsonConvert.DeserializeObject<List<GeneralFilter>>(data).Where(filter => filter.Category == GeneralFilterCategories.Department).ToList();
            }
        }
        
    }

}
