using System;
using System.IO;
using System.Linq;

namespace CalculatorLab
{
    class Program
    {
        static char[] operators = { '/', '+', '-', '*' };
        static bool isCorrect(string str)
        {
            foreach (var sym in str)
            {
                if (!char.IsDigit(sym) && !operators.Contains(sym) && !char.IsWhiteSpace(sym)) return false;
            }
            return true;
        }
        static string ReadFile(string path)
        {
            StreamReader str = new StreamReader(path, System.Text.Encoding.Default);
            string line = str.ReadLine();
            return line;
        }

        static void calculateSum(int firstOperand, int secondOperand)
        {
            Console.WriteLine(firstOperand + secondOperand);
        }
        static void calculateDif(int firstOperand, int secondOperand)
        {
            Console.WriteLine(firstOperand - secondOperand);
        }
        static void calculateMultiply(int firstOperand, int secondOperand)
        {
            Console.WriteLine(firstOperand * secondOperand);
        }
        static void calculateDivision(float firstOperand, float secondOperand)
        {
            if (secondOperand != 0) Console.WriteLine(firstOperand / secondOperand);
            else Console.WriteLine("На ноль как бы не делим, ок да?");
        }
        static void Calculate(string str)
        {
            string firstOperand = "";
            string whichOperator = "";
            string secondOperand = "";
            int step = 0;
            foreach (var ch in str)
            {
                switch (step)
                {
                    case 0:
                        if (char.IsWhiteSpace(ch)) continue;
                        else if (char.IsDigit(ch))
                        {
                            step = 1;
                            firstOperand += ch;
                        }
                        break;
                    case 1:
                        if (char.IsDigit(ch)) firstOperand += ch;
                        else step = 2;
                        break;
                    case 2:
                        if (char.IsWhiteSpace(ch)) continue;
                        else if (operators.Contains(ch))
                        {
                            whichOperator += ch;
                            step = 3;
                        }
                        break;
                    case 3:
                        if (char.IsWhiteSpace(ch)) continue;
                        else if (char.IsDigit(ch))
                        {
                            secondOperand += ch;
                            step = 4;
                        }
                        else step = 4;
                        break;
                    case 4:
                        if (char.IsDigit(ch)) secondOperand += ch;
                        else step = 5;
                        break;
                }
            }
            if (secondOperand == "") Console.WriteLine("Что-то пошло не так, проверьте корректность входных данных");
            else if (whichOperator == "+") calculateSum(Convert.ToInt32(firstOperand), Convert.ToInt32(secondOperand));
            else if (whichOperator == "-") calculateDif(Convert.ToInt32(firstOperand), Convert.ToInt32(secondOperand));
            else if (whichOperator == "*") calculateMultiply(Convert.ToInt32(firstOperand), Convert.ToInt32(secondOperand));
            else calculateDivision(Convert.ToInt32(firstOperand), Convert.ToInt32(secondOperand));
        }
        static void Main(string[] args)
        {
            string str;
            if (!isCorrect(str = ReadFile(@"input.txt"))) Console.WriteLine("Входные данные некорректны");
            else
            {
                Calculate(str);
            }
            Console.ReadKey();
        }
    }
}
