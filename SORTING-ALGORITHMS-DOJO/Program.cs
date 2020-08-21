using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SORTING_ALGORITHMS_DOJO
{
    class Program
    {
        private static readonly string ResourcePathPrefix = "/Resources";
        private static readonly string SortedFileNamePrefix = "sorted_";

        private static readonly Dictionary<string, string> NumbersToFiles = new Dictionary<string, string>
        {
            {"1", "one_thousand.txt"},
            {"2", "ten_thousand.txt"},
            {"3", "fifty_thousand.txt"},
            {"4", "one_hundred_thousand.txt"},
            {"5", "five_hundred_thousand.txt"},
            {"6", "one_million.txt"},
            {"7", "three_millions.txt"}
        };

        static void Main(string[] args)
        {
            PrintFileNames();
            var fileToSort = GetFileNameFromUser();
            SortOnUserChoice(fileToSort);
            Console.WriteLine();
        }

        private static void PrintFileNames()
        {
            Console.WriteLine("Which file do you want to sort? (one_thousand.txt is default)");
            foreach (KeyValuePair<string, string> entry in NumbersToFiles)
            {
                Console.WriteLine(entry.Key + ") " + entry.Value);
            }
        }

        private static string GetFileNameFromUser()
        {
            var fileName = "one_thousand.txt";
            var userInput = Console.ReadLine();
            if (NumbersToFiles.ContainsKey(userInput ?? string.Empty))
            {
                NumbersToFiles.TryGetValue(userInput ?? string.Empty, out fileName);
            }

            return fileName;
        }

        private static void SortOnUserChoice(string fileToSort)
        {
            int[] numbers = GetDataFromFile(fileToSort);

            PrintSortingMenu();
            var userChoice = Console.ReadLine();
            dynamic result = null;
            switch (userChoice)
            {
                case "1":
                    result = SortUsingInsertionSortAlgorithm(numbers);
                    break;
                case "2":
                    result = SortUsingBuiltInMethod(numbers);
                    break;
                case "3":
                    result = SortUsingInsertionSortAlgorithmWithList(numbers.ToList());
                    break;
                case "4":
                    result = SortUsingInsertionSortAlgorithmWithList(new LinkedList<int>(numbers));
                    break;
                default:
                    Console.WriteLine("Wrong option has been chosen.");
                    break;
            }

            if (result != null)
            {
                SaveResultToFile(result, SortedFileNamePrefix + fileToSort);
            }
        }

        private static void PrintSortingMenu()
        {
            Console.WriteLine("Which method you want to sort the numbers?");
            Console.WriteLine("1) Insertion sort using own algorithm");
            Console.WriteLine("2) Insertion sort using builtin algorithm");
            Console.WriteLine("3) Insertion sort using ArrayList");
            Console.WriteLine("4) Insertion sort using LinkedList");
            Console.WriteLine("Q) Quit");
        }

        private static int[] GetDataFromFile(string fileToSort)
        {
            var currentPath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            var filePath = currentPath + "\\Resources\\" + fileToSort;

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                int[] numbers = new int[lines.Length];
                var counter = 0;
                foreach (var line in lines)
                {
                    int.TryParse(line, out var lineValue);

                    numbers[counter] = lineValue;
                    counter++;
                }

                return numbers;
            }

            return new int[] { };
        }


        private static object SortUsingInsertionSortAlgorithm(int[] numbers)
        {
            // TODO
            throw new NotImplementedException();
        }

        private static object SortUsingBuiltInMethod(int[] numbers)
        {
            // TODO
            throw new NotImplementedException();
        }

        private static object SortUsingInsertionSortAlgorithmWithList(List<int> toList)
        {
            // TODO
            throw new NotImplementedException();
        }

        private static object SortUsingInsertionSortAlgorithmWithList(LinkedList<int> p0)
        {
            // TODO
            throw new NotImplementedException();
        }

        private static void SaveResultToFile(object result, string sortedFileName)
        {
            using StreamWriter sw = new StreamWriter(sortedFileName);

            foreach (var value in (IReadOnlyList<int>) result)
            {
                sw.WriteLine(value);
            }
        }
    }
}
