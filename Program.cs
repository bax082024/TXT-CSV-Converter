using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("===========================================");
            Console.WriteLine("=== TXT to CSV / CSV to TXT Converter ===");
            Console.WriteLine("===========================================");
            Console.WriteLine("\n1. Convert TXT to CSV");
            Console.WriteLine("2. Convert CSV to TXT");
            Console.WriteLine("3. Exit");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("\nChoose an option (1-3): ");

            string choice = Console.ReadLine() ?? string.Empty;

            switch (choice)
            {
                case "1":
                    ConvertTxtToCsv();
                    break;
                case "2":
                    ConvertCsvToTxt();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        }

    }

}