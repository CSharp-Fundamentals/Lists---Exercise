using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] tokens = command.Split();
                string firstWordFromCommand = tokens[0];
                if (firstWordFromCommand == "Delete")
                {
                    int element = int.Parse(tokens[1]);
                    numbers.RemoveAll(x=> x==element);
                }
                else if (firstWordFromCommand == "Insert")
                {
                    int element = int.Parse(tokens[1]);
                    int position = int.Parse(tokens[2]);
                    numbers.Insert(position,element);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
