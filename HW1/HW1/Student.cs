using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    internal class Student : Person
    {
        protected float _average;
        protected int _numberOfGroup;
        public float Average { get => _average; set => _average = value; }
        public int NumberOfGroup { get => _numberOfGroup; set => _numberOfGroup = value; }

        public Student(string name, string surname, int age, string phone, float average, int numberOfGroup) : base(name, surname, age, phone)
        {
            _average = average;
            _numberOfGroup = numberOfGroup;
        }

        public override void Print()
        {
            base.Print();
             Console.WriteLine($"Average = {Average}, Number of grup {NumberOfGroup}");
        }
    }
}
