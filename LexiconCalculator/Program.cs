using System;
using System.Collections.Generic;
using System.Linq;

namespace LexiconCalculator
{
    public class Program
    {
        public static void Main()
        {
            Console.Title = "Lexicon Calculator";
            CalculatorUser cu = new CalculatorUser();
            cu.MainMenu();

        }
    }

    public class CalculatorUser
    {
        public readonly string ExitMsg = "\n\nPress enter to exit";


        public void MainMenu()
        {
            string menuText = @"
   ____        _               _         _                  ____     _  _   
  / ___| __ _ | |  ___  _   _ | |  __ _ | |_  ___   _ __   / ___|  _| || |_ 
 | |    / _` || | / __|| | | || | / _` || __|/ _ \ | '__| | |     |_  ..  _|
 | |___| (_| || || (__ | |_| || || (_| || |_| (_) || |    | |___  |_      _|
  \____|\__,_||_| \___| \__,_||_| \__,_| \__|\___/ |_|     \____|   |_||_|  
                                                                            
";
            bool showMenu = true;
            while (showMenu)
            {
                Console.Clear();
                Console.WriteLine(menuText);
                Console.WriteLine("...Lexicon Calculator...\n");
                Console.WriteLine("0) Exit");
                Console.WriteLine("1) Addition: Add numbers");
                Console.WriteLine("2) Subtraction: Subtract numbers");
                Console.WriteLine("3) Division: Divide numbers");
                Console.WriteLine("4) Multiplication: Multiply numbers");
                Console.WriteLine("5) Evaluate expression: eg. 2+(5*3)");
                Console.Write("\r\nChoose function: ");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        showMenu = false;
                        Console.WriteLine("Goodbye!");
                        System.Environment.Exit(0);
                        break;
                    case "1":
                        option = "add";
                        break;
                    case "2":
                        option = "subtract";
                        break;
                    case "3":
                        option = "divide";
                        break;
                    case "4":
                        option = "multiply";
                        break;
                    case "5":
                        option = "evaluate";
                        break;
                    default:
                        break;
                }
                HandleUserInputs(option);
            }
        }

        public void HandleUserInputs(string option)
        {
            double result;
            List<double> validiatedList = new List<double>();
            Console.WriteLine($"Enter the numbers you would like to {option}, eg. 5 10 2,5" + ExitMsg);
            string userInput = Console.ReadLine();
            string[] inputValues = userInput.Split().Select(sValue => sValue.Trim()).ToArray();

            if (option == "evaluate")
            {
                Calculator.EvaluateExpression(userInput);
                Console.WriteLine(ExitMsg);
                Console.ReadKey();
            }
            else if (inputValues.Length < 2)
            {
                Console.WriteLine($"\n You need to provide at least two numbers separated with blankspace...{ExitMsg}");
                LogWriter.LogWrite($"Attempt to enter only one digit");
                Console.ReadKey();
            }
            else
            {
                validiatedList = ValidateDouble(inputValues);
                result = CallMathFunctions(validiatedList, option);
                Console.WriteLine($" The result of the calculation is: {result} {ExitMsg}");
                Console.ReadKey();
            }
        }

        public List<double> ValidateDouble(string[] inputStrings)
        {
            List<double> userInputList = new List<double>();
            bool checkInput;
            string errMsg = "Please try to only enter real numbers, like 1 or 1,5" + ExitMsg;
            foreach (string value in inputStrings)
            {
                checkInput = double.TryParse(value, out double numbers);
                if (!checkInput)
                {
                    Console.WriteLine($"\n{value} is not a real number... {errMsg}");
                    LogWriter.LogWrite($"Validate TryParse error");
                    break;
                }
                //add the checked value to the List
                userInputList.Add(numbers);
            }
            return userInputList;
        }

        public double CallMathFunctions(List<double> numList, string operation)
        {
            double[] numberList = numList.ToArray();
            double returnValue = 0;

            if (numberList.Length < 2)
            {
                double firstNumber = numberList[0], secondNumber = numberList[1];

                switch (operation)
                {
                    case "add":
                        returnValue = Calculator.Addition(firstNumber, secondNumber);
                        break;
                    case "subtract":
                        returnValue = Calculator.Subtraction(firstNumber, secondNumber);
                        break;
                    case "multiply":
                        returnValue = Calculator.Multiplication(firstNumber, secondNumber);
                        break;
                    case "divide":
                        returnValue = Calculator.Division(firstNumber, secondNumber);
                        break;
                    default:
                        Console.WriteLine("Invalid math operation");
                        break;
                }
            }
            else
            {
                switch (operation)
                {
                    case "add":
                        returnValue = Calculator.Addition(numberList);
                        break;
                    case "multiply":
                        returnValue = Calculator.Multiplication(numberList);
                        break;
                    case "subtract":
                        returnValue = Calculator.Subtraction(numberList);
                        break;
                    case "divide":
                        returnValue = Calculator.Division(numberList);
                        break;
                    default:
                        Console.WriteLine("Invalid math operation");
                        break;
                }
            }
            return returnValue;
        }
    }//End of CalculatorUser  
}
