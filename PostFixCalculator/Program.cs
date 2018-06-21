using System;
using System.Collections.Generic;

namespace PostFixCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Calculate("5", "6", "7", "*", "+", "1", "-", ")");
            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static int Calculate(params string[] args)
        {
            Stack<int> stack = new Stack<int>();

            foreach (var token in args)
            {
                bool isOperand = int.TryParse(token, out int value);

                if (isOperand)
                    stack.Push(value);
                else
                {
                    int rightOperand = stack.Pop();
                    int leftOperand = stack.Pop();

                    switch (token)
                    {
                        case "+":
                            stack.Push(leftOperand + rightOperand);
                            break;
                        case "-":
                            stack.Push(leftOperand - rightOperand);
                            break;
                        case "*":
                            stack.Push(leftOperand * rightOperand);
                            break;
                        case "/":
                            stack.Push(leftOperand / rightOperand);
                            break;
                        case "%":
                            stack.Push(leftOperand % rightOperand);
                            break;
                        default:
                            throw new ArgumentException($"Can't recognize the operator - {token}");
                    }
                }
            }

            return stack.Pop();
        }
    }
}
