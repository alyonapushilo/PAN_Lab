using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAN_1
{
    class Program
    {
        static void Main(string[] args)
        {

            Calc result = new Calc();
            Console.WriteLine("Введите число А");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите число B");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите операцию");

            string x= Convert.ToString(Console.ReadLine()); ;
            Console.WriteLine("Операция " + x);
            switch (x)
            {
                case "+":
                    
                    Console.WriteLine("Ответ: "+ result.Sum(a, b));
                    break;
                case "-":
                    Console.WriteLine("Ответ: " + result.Min(a, b));
                    break;
                case "*":
                    Console.WriteLine("Ответ: " + result.Mul(a, b));
                    break;
                case "/":
                    Console.WriteLine("Ответ: " + result.Div(a, b));
                    break;
                default:
                    Console.WriteLine("Данной операции нет");
                    break;
            }


        }
    }
}
