using System;
using System.IO;
using System.Text;

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

            string choice = Console.ReadLine() ?? String.Empty;

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
        string inputPath = Console.ReadLine() ?? String.Empty;

        Console.Write("Enter the path to save the CSV file (with .csv extension): ");
        string outputPath = Console.ReadLine() ?? String.Empty;

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Error: The specified TXT file does not exist.");
            return;
        }

        try
        {
            using (var reader = new StreamReader(inputPath, Encoding.UTF8))
            using (var writer = new StreamWriter(outputPath, false, Encoding.UTF8))
            {
                writer.WriteLine("Question,Answer");
                string question = null;
                string answer = null;

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    if (question == null)
                    {
                        question = line.Trim();
                    }
                    else
                    {
                        answer = line.Trim();
                        writer.WriteLine($"\"{question}\",\"{answer}\"");
                        question = null;
                        answer = null;
                    }
                }

                if (question != null && answer == null)
                {
                    Console.WriteLine("Warning: Last question has no matching answer.");
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
        string inputPath = Console.ReadLine() ?? String.Empty;

        Console.Write("Enter the path to save the TXT file (with .txt extension): ");
        string outputPath = Console.ReadLine() ?? String.Empty;

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Error: The specified CSV file does not exist.");
            return;
        }

        try
        {
            using (var reader = new StreamReader(inputPath, Encoding.UTF8))
            using (var writer = new StreamWriter(outputPath, false, Encoding.UTF8))
            {
                reader.ReadLine(); 
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var parts = line.Split(",", 2);
                    if (parts.Length == 2)
                    {
                        writer.WriteLine(parts[0].Trim('"'));
                        writer.WriteLine(parts[1].Trim('"'));
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
