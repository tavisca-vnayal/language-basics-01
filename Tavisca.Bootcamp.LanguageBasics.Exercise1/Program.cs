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
            // Add your code here.
            string firstNumber = equation.Split("*")[0];
            string secondNumber = equation.Split("*")[1].Split("=")[0];
            string observedResult = equation.Split("=")[1];

            bool isFirstNumberNumeric = Int32.TryParse(firstNumber, out int intFirstNumber);
            bool isSecondNumberNumeric = Int32.TryParse(secondNumber, out int intSecondNumber);
            bool isObservedResultNumeric = Int32.TryParse(observedResult, out int intObservedResult);

            string correctEquation = "";

            if(isFirstNumberNumeric == false)
            {
                if(intObservedResult % intSecondNumber == 0)
                {
                    string newFirstNumber = Convert.ToString(intObservedResult / intSecondNumber);
                    correctEquation += newFirstNumber + "*" + secondNumber + "=" + observedResult;
                }
                else
                {
                    return -1;
                }
            }
            if (isSecondNumberNumeric == false)
            {
                if (intObservedResult % intFirstNumber == 0)
                {
                    string newSecondNumber = Convert.ToString(intObservedResult / intFirstNumber);
                    correctEquation += firstNumber + "*" + newSecondNumber + "=" + observedResult;
                }
                else
                {
                    return -1;
                }
            }
            if (isObservedResultNumeric == false)
            {
                string expectedResult = Convert.ToString(intFirstNumber * intSecondNumber);
                correctEquation += firstNumber + "*" + secondNumber + "=" + expectedResult;
            }

            if(equation.Length != correctEquation.Length)
            {
                return -1;
            }
            for(int i=0;i<correctEquation.Length;i++)
            {
                if (correctEquation[i] != equation[i] && equation[i] == '?')
                {
                    return (correctEquation[i] - '0');
                }
            }
            throw new NotImplementedException();
        }
    }
}
