using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAN_1
{
    public class Calc
    {
        public Calc() { }
        public int Sum (int a, int b)
        {
            return a + b;
        }

        public int Min(int a, int b)
        {
            return a - b;
        }
        public int Mul(int a, int b)
        {
            return a * b;
        }
        public int Div(int a, int b)
        {
            return a / b;
        }
    }
}
