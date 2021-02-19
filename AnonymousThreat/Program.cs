using System;
using System.Collections.Generic;
using System.Linq;

namespace AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine()
                .Split()
                .ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "3:1")
                {
                    break;
                }
                string[] tokens = line.Split();
                string command = tokens[0];

                if (command == "merge")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);

                    if (startIndex >= elements.Count)
                    {
                        continue;
                    }

                    if (endIndex < 0)
                    {
                        continue;
                    }

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }

                    if (endIndex >= elements.Count)
                    {
                        endIndex = elements.Count - 1;
                    }

                    string merged = string.Empty;
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        string element = elements[i];
                        merged += element;
                    }

                    elements.RemoveRange(startIndex, endIndex - startIndex + 1);
                    elements.Insert(startIndex, merged);
                }
                else
                {
                    int index = int.Parse(tokens[1]);
                    int partitions = int.Parse(tokens[2]);

                    string element = elements[index];
                    elements.RemoveAt(index);
                    int partitionSize = element.Length / partitions;

                    List<string> substrings = new List<string>();

                    for (int i = 0; i < partitions - 1; i++)
                    {
                        string substring = element.Substring(i * partitionSize, partitionSize);
                        substrings.Add(substring);
                    }

                    string lastSubstring = element.Substring((partitions - 1) * partitionSize);
                    substrings.Add(lastSubstring);
                    elements.InsertRange(index, substrings);
                }
            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
