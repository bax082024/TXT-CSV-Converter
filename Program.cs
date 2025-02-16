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

    static void ConvertTxtToCsv()
    {
        Console.Write("Enter the path of the TXT file: ");
        string inputPath = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter the path to save the CSV file: ");
        string outputPath = Console.ReadLine() ?? string.Empty;

        try
        {
            using (var reader = new StreamReader(inputPath))
            using (var writer = new StreamWriter(outputPath))
            {
                writer.WriteLine("Question,Answer");
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split('\t');
                    if (parts.Length == 2)
                    {
                        writer.WriteLine($"\"{parts[0]}\",\"{parts[1]}\"");
                    }
                }
            }
            Console.WriteLine("TXT to CSV conversion successful!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void ConvertCsvToTxt()
    {
        Console.Write("Enter the path of the CSV file: ");
        string inputPath = Console.ReadLine();

        Console.Write("Enter the path to save the TXT file: ");
        string outputPath = Console.ReadLine();

        try
        {
            using (var reader = new StreamReader(inputPath))
            using (var writer = new StreamWriter(outputPath))
            {
                string headerLine = reader.ReadLine(); // Skip header
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        writer.WriteLine($"{parts[0].Trim('\"')}\t{parts[1].Trim('\"')}");
                    }
                }
            }
            Console.WriteLine("CSV to TXT conversion successful!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

}