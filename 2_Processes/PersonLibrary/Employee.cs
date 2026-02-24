using System;
using System.Collections.Generic;
using System.Text;

namespace PersonLibrary
{
    public class Employee : Person
    {
        string Position;
        decimal Salary;

        public Employee(string Name, string Lastname, int Age, string Position, decimal Salary) : base(Name, Lastname, Age)
        {
            this.Position = Position;
            this.Salary = Salary;
        }
    }
}
