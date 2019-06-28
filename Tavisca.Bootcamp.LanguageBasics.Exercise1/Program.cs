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
            int missing_part = 0, index = 0, flag = 0;

            string[] temp = equation.Split(new Char[] { '*', '=' });

            for (int i = 0; i < 3; i++)
            {
                if (temp[i].IndexOf('?') < 0)
                {
                    string temp1 = temp[i];
                    numbers[i] = Int32.Parse(temp1);
                }
                else
                {
                    unknown = temp[i];
                    index = temp[i].IndexOf('?');
                    missing_part = i;
                }
            }
            if (missing_part == 0)
            {
                result = numbers[2] / numbers[1];
                flag = Check(result);
            }
            else if (missing_part == 1)
            {
                result = numbers[2] / numbers[0];
                flag = Check(result);
            }
            else
            {
                result = numbers[0] * numbers[1];
                flag = Check(result);
            }
            res_string = result.ToString();

            if (res_string.Length == unknown.Length && flag == 1)
            {
                return (int)Char.GetNumericValue(res_string, index);
            }
            else
            {
                return -1;
            }
        }

        private static int Check(double a)
        {
            if ((a % 1) > 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
