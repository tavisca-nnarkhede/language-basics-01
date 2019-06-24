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

        public static int FindDigit(string equation)
        {
            string EPart1=equation.Split('*')[0];
            string EPart2=equation.Split('*')[1].Split('=')[0];
            string EPart3=equation.Split('=')[1];
            int result=0;
            var answer=0.0;
            String answer1=null, answer2=null;
            if (EPart1.Contains("?"))
            {
                answer=double.Parse(EPart3) / double.Parse(EPart2);
                answer1=EPart1;
            }
            else if (EPart2.Contains("?"))
            {
                answer=double.Parse(EPart3) / double.Parse(EPart1);
                answer1=EPart2;
            }
            else if (EPart3.Contains("?"))
            {
                answer=double.Parse(EPart1) * double.Parse(EPart2);
                answer1=EPart3;
            }
            answer2=answer.ToString();
            if (answer1.Length==answer2.Length)
            {
                for (int i=0;i<answer2.Length;i++)
                {
                    if (answer1[i]!=answer2[i])
                    {
                        result=int.Parse(answer2[i].ToString());
                        return result;
                    }

                }
            }
            else
            {
                return -1;
            }
            throw new NotImplementedException();
        }
    }
}
