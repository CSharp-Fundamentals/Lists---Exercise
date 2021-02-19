using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command=="End")
                {
                    break;
                }

                string[] tokens = command.Split();
                string firstWord = tokens[0];
                if (firstWord=="Add")
                {
                    int number = int.Parse(tokens[1]);
                    numbers.Add(number);
                }
                else if (firstWord=="Insert")
                {
                    int number = int.Parse(tokens[1]);
                    int index = int.Parse(tokens[2]);

                    if (!IsValid(index,numbers))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                        numbers.Insert(index,number);
                }
                else if (firstWord == "Remove")
                {
                    int index = int.Parse(tokens[1]);
                    if (!IsValid(index, numbers))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    numbers.RemoveAt(index);
                    
                }
                else if (firstWord == "Shift")
                {
                    string direction = tokens[1];
                    int count = int.Parse(tokens[2]);

                    if (direction=="left")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int firstElement = numbers[0];
                            numbers.RemoveAt(0);
                            numbers.Add(firstElement);
                        }
                    }
                    else if (direction=="right")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int lastElement = numbers[numbers.Count-1];
                            numbers.RemoveAt(numbers.Count-1);
                            numbers.Insert(0,lastElement);
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ",numbers));
        }

        private static bool IsValid(int index, List<int> numbers)
        {
            return index >= 0 && index < numbers.Count;
        }
    }
}
