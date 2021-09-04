using Domain.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Employee
    {
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        
        public string Dni { get; set; }
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public string Lastname { get; set; }
        [JsonProperty]
        public decimal Wage { get; set; }
        [JsonProperty]
        public AcademicLevel AcademicLevel { get; set; }
        
        [JsonProperty]
        public Genders Gender { get; set; }


        public class EmployeeWageComparer : IComparer<Employee>
        {
            public int Compare(Employee e1, Employee e2)
            {
                if (e1 == null || e2 == null)
                {
                    throw new ArgumentException("Error, los objetos no puedn ser null.");
                }
                if (e1.Wage > e2.Wage)
                {
                    return 1;
                }
                else if (e1.Wage < e2.Wage)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public class EmployeeAcademicLevelComparer : IComparer<Employee>
        {
            public int Compare(Employee e1, Employee e2)
            {
                if (e1 == null || e2 == null)
                {
                    throw new ArgumentException("Error, los objetos no puedn ser null.");
                }
                if (e1.AcademicLevel > e2.AcademicLevel)
                {
                    return 1;
                }
                else if (e1.AcademicLevel < e2.AcademicLevel)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

    }
}
