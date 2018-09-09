using System;

namespace TCS_Coding
{
    class Program
    {
        public string ConvertSmallToLarger(string input)
        {

            return input.ToLower();
        }
        public string  ConvertVowelsToDollar(string input)
        {
            char[] midResult = input.ToCharArray();
            for (int count = 0; count < midResult.Length; count++)
            {
                if (midResult[count] == 'e')
                    midResult[count] = '$';
            }
            return midResult.ToString();
        }
        public string ConvertConsonentsToHash(string input)
        {
            return "";
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string input = Console.ReadLine();
            Program test = new Program();
           Console.WriteLine(test.ConvertVowelsToDollar(test.ConvertSmallToLarger(input)));
        }
    }
}
