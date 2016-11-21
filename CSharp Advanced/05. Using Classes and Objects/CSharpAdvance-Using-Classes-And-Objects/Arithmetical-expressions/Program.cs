using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class ArithmeticalExpressionCalc
{
    public static List<char> arithmeticOperations = new List<char> { '+', '-', '*', '/' };
    public static List<char> brackets = new List<char>() { '(', ')' };
    public static List<string> functions = new List<string>() { "pow", "sqrt", "ln" };

    static string TrimInput(string expression)
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] != ' ')
            {
                result.Append(expression[i]);
            }
        }
        return result.ToString();
    }

    static List<string> SeparateTokens(string expression)
    {
        var result = new List<string>();
        var number = new StringBuilder();

        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '-' && (i == 0 || expression[i - 1] == ',' || expression[i - 1] == '('))
            {
                number.Append('-');
            }
            else if (char.IsDigit(expression[i]) || expression[i] == '.')
            {
                number.Append(expression[i]);
            }
            else if (!char.IsDigit(expression[i]) && expression[i] != '.' && number.Length != 0)
            {
                result.Add(number.ToString());
                number.Clear();
                i--;
            }
            else if (brackets.Contains(expression[i]))
            {
                result.Add(expression[i].ToString());
            }
            else if (arithmeticOperations.Contains(expression[i]))
            {
                result.Add(expression[i].ToString());
            }
            else if (expression[i] == ',')
            {
                result.Add(",");
            }
            else if (i + 1 < expression.Length && expression.Substring(i, 2).ToLower() == "ln")
            {
                result.Add("ln");
                i++;
            }
            else if (i + 2 < expression.Length && expression.Substring(i, 3).ToLower() == "pow")
            {
                result.Add("pow");
                i += 2;
            }
            else if (i + 3 < expression.Length && expression.Substring(i, 4).ToLower() == "sqrt")
            {
                result.Add("sqrt");
                i += 3;
            }
            else
            {
                throw new ArgumentException("Invalid expression.");
            }
        }

        if (number.Length != 0)
        {
            result.Add(number.ToString());
        }

        return result;
    }

    static int Precedence(string arithmeticOperator)
    {
        if (arithmeticOperator == "+" || arithmeticOperator == "-")
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

    static Queue<string> ConvertToReversePolishNotation(List<string> tokens)
    {
        Stack<string> stack = new Stack<string>();
        Queue<string> queue = new Queue<string>();
        for (int i = 0; i < tokens.Count; i++)
        {
            var currentToken = tokens[i];
            double number;

            if (double.TryParse(currentToken, out number))
            {
                queue.Enqueue(currentToken);
            }
            else if (functions.Contains(currentToken))
            {
                stack.Push(currentToken);
            }
            else if (currentToken == ",")
            {
                if (!stack.Contains("(") || stack.Count == 0)
                {
                    throw new ArgumentException("Invalid brackets or function separator");
                }

                while (stack.Peek() != "(")
                {
                    // if not working -> you may need to pop the "("
                    queue.Enqueue(stack.Pop());
                }
            }
            else if (arithmeticOperations.Contains(currentToken[0]))
            {
                // if not working -> refactor logic for currentToken

                while (stack.Count != 0 && arithmeticOperations.Contains(stack.Peek()[0]) && Precedence(currentToken) <= Precedence(stack.Peek()))
                {
                    queue.Enqueue(stack.Pop());
                }

                stack.Push(currentToken);
            }
            else if (currentToken == "(")
            {
                stack.Push("(");
            }
            else if (currentToken == ")")
            {
                if (!stack.Contains("(") || stack.Count == 0)
                {
                    throw new ArgumentException("Invalid brackets.");
                }
                while (stack.Peek() != "(")
                {
                    queue.Enqueue(stack.Pop());
                }

                stack.Pop();
                if (stack.Count != 0 && functions.Contains(stack.Peek()))
                {
                    queue.Enqueue(stack.Pop());
                }
            }
        }

        while (stack.Count != 0)
        {
            if (brackets.Contains(stack.Peek()[0]))
            {
                throw new ArgumentException("Invalid bracket.");
            }
            queue.Enqueue(stack.Pop());
        }
        return queue;
    }

    static void PutInvariantCulture()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
    }

    static double GetResultFromRPN(Queue<string> queue)
    {
        Stack<double> stack = new Stack<double>();
        while (queue.Count != 0)
        {
            double number;
            string currentToken = queue.Dequeue();
            if (double.TryParse(currentToken, out number))
            {
                stack.Push(number);
            }
            else if (arithmeticOperations.Contains(currentToken[0]) || functions.Contains(currentToken))
            {
                if (currentToken == "+")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression.");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(firstValue + secondValue);
                }
                else if (currentToken == "-")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression.");
                    }
                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(secondValue - firstValue);
                }
                else if (currentToken == "*")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression.");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(secondValue * firstValue);
                }
                else if (currentToken == "/")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression.");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(secondValue / firstValue);
                }
                else if (currentToken == "pow")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression.");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(Math.Pow(secondValue, firstValue));
                }
                else if (currentToken == "sqrt")
                {
                    if (stack.Count < 1)
                    {
                        throw new ArgumentException("Invalid expression.");
                    }

                    double value = stack.Pop();

                    stack.Push(Math.Sqrt(value));
                }
                else if (currentToken == "ln")
                {
                    if (stack.Count < 1)
                    {
                        throw new ArgumentException("Invalid expression.");
                    }

                    double value = stack.Pop();

                    stack.Push(Math.Log(value));
                }
            }
        }
        if (stack.Count == 1)
        {
            return stack.Pop();
        }
        else
        {
            throw new ArgumentException("Invalid expression.");
        }
    }

    static void StartCalculating()
    {
        string expression = Console.ReadLine();
        
            try
            {

                string trimmedInput = expression.Replace(" ", string.Empty);
                var separateTokens = SeparateTokens(trimmedInput);
                var reversePolishNotation = ConvertToReversePolishNotation(separateTokens);
                var finalResult = GetResultFromRPN(reversePolishNotation);

                Console.WriteLine("{0:F2}",finalResult);
            }
            catch (ArgumentException ae)
            {
                Console.Error.WriteLine(ae.Message);
            }
            catch (FormatException fe)
            {
                Console.Error.WriteLine(fe.Message);
            }
        
    }

    static void Main(string[] args)
    {
        PutInvariantCulture();
        StartCalculating();
    }
}
