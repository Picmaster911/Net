using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win7Calc
{
    public class CalcTest
    {
        public static Dictionary <char, Func<double, double, double>> Operators = new Dictionary <char, Func<double, double, double>>
        {
           { '+', (a, b) => a + b },
           { '-', (a, b) => a - b },
           { '/', (a, b) => a / b },
           { '%', (a, b) => 100 / b * a },
           { '*', (a, b) => a * b },
        };
    }
}
