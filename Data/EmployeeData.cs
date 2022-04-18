using EmployeeDirectory_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmployeeDirectory_WPF.Models.Enums;

namespace EmployeeDirectory_WPF.Data
{
    public class EmployeeData
    {
        public static List<Employee> Employees = new List<Employee>
        {
            new Employee("Anthony","Morris","anthonymorris@gmail.com",new DateOnly(1996,12,10),"Sharepoint Practice Head","IT Department",2,8464832529,35000,EmployementType.Contract),
            new Employee("Andrew","Philips","andrewphilips@gmail.com",new DateOnly(1996,10,1),"Web Developer","IT Department",0,8464892523,48000,EmployementType.Permanent),
            new Employee("Helen","Jimmerman","helenjimmerman@gmail.com",new DateOnly(1994,1,5),"Operations Manager","IT Department",4,8461892523,88000,EmployementType.Permanent),
            new Employee("Tami","Hopkins","tamihopkins@gmail.com",new DateOnly(1996,10,1),"Product Manager","IT Department",1,8463892523,48000,EmployementType.Permanent),
            new Employee("Olivia","Morris","oliviamorris@gmail.com",new DateOnly(1996,10,1),"Software Engineer","IT Department",3,8462892523,38000,EmployementType.Permanent),
            new Employee("Steve","Rogers","steverogers@gmail.com",new DateOnly(1996,10,1),"Lead Engineer Dot Net","IT Department",6,8464892523,30000,EmployementType.Permanent),
            new Employee("Tony","Stark","tonystark@gmail.com",new DateOnly(1996,10,1),"UI Designer","UX Department",9,8465892523,28000,EmployementType.Permanent),
            new Employee("Paul","Rudd","paulrudd@gmail.com",new DateOnly(1996,10,1),"Talent Magnet Jr.","HR Department",7,8466892523,25000,EmployementType.Permanent),
            new Employee("Mark","Ruffalo","markrufallo@gmail.com",new DateOnly(1996,10,1),"Junior Software Developer","IT Department",0,8467892523,48000,EmployementType.Contract),
            new Employee("Natasha","Romanoff","natasharomanoff@gmail.com",new DateOnly(1996,10,1),"Head HR","HR Department",1,8468892523,50000,EmployementType.Permanent),

        };
        public static Dictionary<string, int> Departments = new Dictionary<string, int>
        {
            { "IT Department",7},
            { "HR Department",2},
            { "UX Department",1 }
        };
        public static Dictionary<string, int> JobTitles = new Dictionary<string, int>
        {
            { "Sharepoint Practice Head",1 },
            { "Web Developer",1 },
            {"Operations Manager",1 },
            {"Product Manager",1 },
            {"Software Engineer",1 },
            {"Lead Engineer Dot Net",1 },
            {"UI Designer",1 },
            {"Talent Magnet Jr.",1 },
            {"Junior Software Developer",1 },
            {"Head HR",1 },

        };

    }
}
