using Microsoft.CodeAnalysis.CSharp.Scripting;
using System;
using System.Linq;

namespace LexiconCalculator
{
    public static class Calculator
    {
        public static double Addition(double augend, double addend)
        {
            double sum = augend + addend;
            return sum;
        }

        // Overloaded Addition, takes a list of all inputs as argument
        public static double Addition(double[] summand)
        {
            double sum = 0;
            foreach (double addend in summand)
            {
                sum += addend;
            }
            return sum;
        }
        public static double Subtraction(double minuend, double subtrahend)
        {
            double difference = minuend - subtrahend;
            return difference;
        }

        // Overloaded Subtraction using first term (x) as minuend and subtracts the remaning subtrahends (y) as (x-y)
        public static double Subtraction(double[] terms)
        {
            double minuend = terms.First();
            terms = terms.Skip(1).ToArray();
            double difference = minuend;
            foreach (double subtrahend in terms)
            {
                difference -= subtrahend;
            }
            return difference;
        }
        public static double Multiplication(double firstFactor, double secondFactor)
        {
            double product = firstFactor * secondFactor;
            return product;
        }

        // Overloaded Multiplication, takes a list of all inputs as argument
        public static double Multiplication(double[] factors)
        {
            double product = 1;
            foreach (double multiplicand in factors)
            {
                product *= multiplicand;
            }
            return product;
        }
        public static double Division(double numerator, double denominator)
        {
            double quotient = 0;
            if (denominator == 0)
            {
                Console.WriteLine($"Division by {denominator} is forbidden.");
                LogWriter.LogWrite($"Attempt to divide by {denominator}");
                return quotient; // Division by zero will return 0 since infinity is a very big number to return  
            }
            else
            {
                quotient = numerator / denominator;
                return quotient;
            }
        }
        // Overloaded Division, using the first item in List as numerator
        public static double Division(double[] numerators)
        {
            double numerator = numerators.First();
            double quotient = numerator;
            numerators = numerators.Skip(1).ToArray();

            foreach (double dividend in numerators)
            {
                if (dividend == 0)
                {
                    Console.WriteLine($"Division by {dividend} is forbidden.");
                    LogWriter.LogWrite($"Attempt to divide by {dividend}");
                    quotient = 0; // Division by zero will return 0
                    break;
                }
                else
                {
                    quotient /= dividend;
                }
            }
            return quotient;
        }
        public static async void EvaluateExpression(string expression)
        {
            try
            {
                string codeToEval = expression;
                object result = await CSharpScript.EvaluateAsync(codeToEval);
                Console.Write($"=" + result);
            }
            catch (Exception e)
            {
                string errorMsg = "Use correct formatting, eg 2+3+(5*2) NOT 2+3(5*2)";
                string error = e.Message;
                LogWriter.LogWrite(error);
                Console.WriteLine($"\n{error} {errorMsg}");
            }
        }


    }//End Class Calculator
}
