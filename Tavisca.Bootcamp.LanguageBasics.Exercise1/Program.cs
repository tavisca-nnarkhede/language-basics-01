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
            string equationPart1=equation.Split('*')[0];
            string equationPart2=equation.Split('*')[1].Split('=')[0];
            string equationPart3=equation.Split('=')[1];
            int result=0;
            var answer=0.0;
            string answer1=null, answer2=null;
            if (equationPart1.Contains("?"))
            {
                answer=double.Parse(equationPart3) / double.Parse(equationPart2);
                answer1= equationPart1;
            }
            else if (equationPart2.Contains("?"))
            {
                answer=double.Parse(equationPart3) / double.Parse(equationPart1);
                answer1= equationPart2;
            }
            else if (equationPart3.Contains("?"))
            {
                answer=double.Parse(equationPart1) * double.Parse(equationPart2);
                answer1= equationPart3;
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
