using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

         private static int FindDigit(string equation)
        {
            double[] numbers = new double[3];
            double result;
            string unknown = "", res_string;
            int missing_part = 0, index = 0;
            bool flag = true;   //checks if decimal number

            string[] equation_numbers = equation.Split(new Char[] { '*', '=' });

            for (int i = 0; i < 3; i++)
            {
                if (equation_numbers[i].IndexOf('?') < 0)   //checks whether current number has '?' symbol
                {
                    string temp1 = equation_numbers[i];
                    numbers[i] = Int32.Parse(temp1);
                }
                else
                {
                    unknown = equation_numbers[i];
                    index = equation_numbers[i].IndexOf('?');
                    missing_part = i;
                }
            }
            if (missing_part == 0)
            {
                if (numbers[1] == 0) { return -1; }
                result = numbers[2] / numbers[1];
                flag = (result % 1) > 0 ? true : false;
            }
            else if (missing_part == 1)
            {
                if (numbers[0] == 0) { return -1; }
                result = numbers[2] / numbers[0];
                flag = (result % 1) > 0 ? true : false;
            }
            else
            {
                result = numbers[0] * numbers[1];
                flag = (result % 1) > 0 ? true : false;
            }
            res_string = result.ToString();

            if (res_string.Length == unknown.Length && !flag)
            {
                return (int)Char.GetNumericValue(res_string, index);
            }
            else
            {
                return -1;
            }
        }
    }
}
