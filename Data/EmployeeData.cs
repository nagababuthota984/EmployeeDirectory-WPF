using EmployeeDirectory_WPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmployeeDirectory_WPF.Models.Enums;

namespace EmployeeDirectory_WPF.Data
{
    public class EmployeeData
    {
        public static string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

        public static List<Employee> Employees = new List<Employee>();
        public static Dictionary<string, int> Departments = new Dictionary<string, int>();
        public static Dictionary<string, int> JobTitles = new Dictionary<string, int>();

        public static void WriteToJson(string typeOfData)
        {
            string data = JsonConvert.SerializeObject(typeof(EmployeeData).GetProperty(typeOfData), Formatting.Indented);
            File.WriteAllText($"{projectDirectory}\\Data\\{typeOfData}.json", data);
        }
        public static void LoadDataFromJson()
        {
            string data = File.ReadAllText($"{projectDirectory}\\Data\\EmployeeData.json");
            if (string.IsNullOrEmpty(data)) Employees = new List<Employee>();
            Employees =  JsonConvert.DeserializeObject<List<Employee>>(data);

            data = File.ReadAllText($"{projectDirectory}\\Data\\JobTitles.json");
            if (string.IsNullOrEmpty(data)) JobTitles = new Dictionary<string, int>();
            JobTitles = JsonConvert.DeserializeObject<Dictionary<string, int>>(data);

            data = File.ReadAllText($"{projectDirectory}\\Data\\Departments.json");
            if (string.IsNullOrEmpty(data)) Departments = new Dictionary<string, int>();
            Departments = JsonConvert.DeserializeObject<Dictionary<string, int>> (data);
        }
    }
}
