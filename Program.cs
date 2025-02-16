using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("=== TXT to CSV / CSV to TXT Converter ===");
            Console.WriteLine("1. Convert TXT to CSV");
            Console.WriteLine("2. Convert CSV to TXT");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option (1-3): ");

            string choice = Console.ReadLine();

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
        string inputPath = Console.ReadLine();

        Console.Write("Enter the path to save the CSV file (with .csv extension): ");
        string outputPath = Console.ReadLine();

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Error: The specified TXT file does not exist.");
            return;
        }

        try
        {
            using (var reader = new StreamReader(inputPath))
            using (var writer = new StreamWriter(outputPath))
            {
                writer.WriteLine("Question,Answer");
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(new string[] { "? " }, StringSplitOptions.None);
                    if (parts.Length == 2)
                    {
                        writer.WriteLine($"\"{parts[0]}?\",\"{parts[1]}\"");
                    }
                }
            }
            Console.WriteLine("TXT to CSV conversion successful!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }

    static void ConvertCsvToTxt()
    {
        Console.Write("Enter the path of the CSV file: ");
        string inputPath = Console.ReadLine();

        Console.Write("Enter the path to save the TXT file (with .txt extension): ");
        string outputPath = Console.ReadLine();

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Error: The specified CSV file does not exist.");
            return;
        }

        try
        {
            using (var reader = new StreamReader(inputPath))
            using (var writer = new StreamWriter(outputPath))
            {
                reader.ReadLine(); // Skip header
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        writer.WriteLine($"{parts[0].Trim('"')}? {parts[1].Trim('"')}");
                    }
                }
            }
            Console.WriteLine("CSV to TXT conversion successful!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}
