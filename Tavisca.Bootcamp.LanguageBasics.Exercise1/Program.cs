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
            string a=equation.Split('*')[0];
            string b=equation.Split('*')[1].Split('=')[0];
            string c=equation.Split('=')[1];
            int result=0;
            var ans=0.0;
            String ans1=null, ans2=null;
            if (a.Contains("?"))
            {
                ans=double.Parse(c) / double.Parse(b);
                ans1=a;
            }
            else if (b.Contains("?"))
            {
                ans=double.Parse(c) / double.Parse(a);
                ans1=b;
            }
            else if (c.Contains("?"))
            {
                ans=double.Parse(a) * double.Parse(b);
                ans1=c;
            }
            ans2=ans.ToString();
            if (ans1.Length==ans2.Length)
            {
                for (int i=0;i<ans2.Length;i++)
                {
                    if (ans1[i]!=ans2[i])
                    {
                        result=int.Parse(ans2[i].ToString());
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
