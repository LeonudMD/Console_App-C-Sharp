namespace calculator_console_app;

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Простой калькулятор. Введите 'exit' для выхода.");

        while (true)
        {
            try
            {
                Console.Write("Введите первое число: ");
                string? input1 = Console.ReadLine();
                if (input1.ToLower() == "exit") break;

                double num1 = Convert.ToDouble(input1);

                Console.Write("Введите операцию (+, -, *, /): ");
                string operation = Console.ReadLine();

                Console.Write("Введите второе число: ");
                string? input2 = Console.ReadLine();
                if (input2.ToLower() == "exit") break;

                double num2 = Convert.ToDouble(input2);

                double result = PerformOperation(num1, num2, operation);
                Console.WriteLine($"Результат: {result}\n");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Введены некорректные данные. Пожалуйста, вводите только числа.\n");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Ошибка: Деление на ноль невозможно.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}\n");
            }
        }
        Console.WriteLine("Программа завершена.");
    }

    static double PerformOperation(double num1, double num2, string operation)
    {
        switch (operation)
        {
            case "+":
                return num1 + num2;
            case "-":
                return num1 - num2;
            case "*":
                return num1 * num2;
            case "/":
                if (num2 == 0) throw new DivideByZeroException();
                return num1 / num2;
            default:
                throw new InvalidOperationException("Некорректная операция.");
        }
    }
}