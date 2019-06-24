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
            string EquPart1=equation.Split('*')[0];
            string EquPart2=equation.Split('*')[1].Split('=')[0];
            string EquPart3=equation.Split('=')[1];
            int Result=0;
            var Answer=0.0;
            String Answer1=null, Answer2=null;
            if (EquPart1.Contains("?"))
            {
                Answer=double.Parse(EquPart2) / double.Parse(EquPart3);
                Answer1=EquPart1;
            }
            else if (EquPart2.Contains("?"))
            {
                Answer=double.Parse(EquPart3) / double.Parse(EquPart1);
                Answer1=EquPart2;
            }
            else if (EquPart3.Contains("?"))
            {
                Answer=double.Parse(EquPart1) * double.Parse(EquPart2);
                Answer1=EquPart3;
            }
            Answer2=Answer.ToString();
            if (Answer1.Length==Answer2.Length)
            {
                for (int i=0;i<Answer2.Length;i++)
                {
                    if (Answer1[i]!=Answer2[i])
                    {
                        Result=int.Parse(Answer2[i].ToString());
                        return Result;
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
