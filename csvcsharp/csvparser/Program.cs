using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FileHelpers;
using FileHelpers.Options;
using csvparser.DataClasses;
using System.Threading;

namespace csvparser
{
    class Program
    {

        static string csvPath = "../../paypal.CSV",
            outputFile = "output.txt";
        Regex numbersOnly = new Regex(@"[^\d]", RegexOptions.Compiled);

        static void Main(string[] args)
        {
            if (File.Exists(outputFile))
                File.Delete(outputFile);
            //new Program().Start();
            new Program().Start();
        }

        private void Start()
        {
            var engine = new FileHelperEngine<PaypalInfo>();
            var readResults = from record in engine.ReadFile(csvPath)
                              where record.Gross > 0.10
                              orderby record.Gross descending
                              select record;

            double totalDonations = 0;
            var logQueue = new List<string>();

            foreach (PaypalInfo r in readResults)
            {
                //LogLine($"{r.OrganizationName}: {r.Gross.ToString("c")}", color: ConsoleColor.Magenta);
                LogToCurrentLine(normalizeTextEndPoint($"{r.OrganizationName}:   ", Console.WindowWidth / 2), ConsoleColor.Magenta);
                LogToCurrentLine(r.Gross.ToString("c") + "\n", color: ConsoleColor.Green);
                totalDonations += r.Gross;
            }

            LogLine($"\n\nTotal Donations Count: {readResults.Count()}", color: ConsoleColor.Green);
            LogLine($"Total Donation Amount: {totalDonations.ToString("c")}", color: ConsoleColor.Green);
            LogLine($"Average Donation Amount: {(totalDonations / readResults.Count()).ToString("c")}", color: ConsoleColor.Green);
            
            Console.WriteLine("Open the output text file? [Y/N]");
            if (Console.ReadKey(true).Key == ConsoleKey.Y)
                Process.Start(outputFile);
        }

        string normalizeTextEndPoint(string input, int endLength)
        {
            while(input.Length < endLength)
            {
                input = input.Insert(0, " ");
            }
            return input;
        }

        void Log(IEnumerable<string> text)
        {
            File.AppendAllLines(outputFile, text);
        }

        void LogLine(string text, ConsoleColor color = ConsoleColor.White, bool toConsole = true)
        {
            ConsoleColor prev = Console.ForegroundColor;
            Console.ForegroundColor = color;

            Console.WriteLine(text);
            File.AppendAllText(outputFile, text+"\n");

            Console.ForegroundColor = prev;
        }

        void LogToCurrentLine(string text, ConsoleColor color = ConsoleColor.White, bool toConsole = true)
        {
            ConsoleColor prev = Console.ForegroundColor;
            Console.ForegroundColor = color;

            Console.Write(text);
            File.AppendAllText(outputFile, text);

            Console.ForegroundColor = prev;
        }

        //private void Start()
        //{
        //    string[] lines = File.ReadAllLines(csvPath).Skip(1).Where(x => x.Contains("Donation Payment")).ToArray();
        //    var filtered = new List<string>();
        //    float minAmount = 0.11f;
        //    float totalDonations = 0f;

        //    int donationCount = 1;
        //    foreach (string line in lines)
        //    {
        //        string[] splitLine = line.Split(',');
        //        if (float.TryParse(splitLine[5].Trim('"'), out float parseResult))
        //        {
        //            string msg = "";
        //            if (parseResult < minAmount) continue;

        //            msg = donationCount < 10 ?
        //                $"Donation({donationCount}) : {splitLine[11].Trim('"')} --> {parseResult.ToString("c")}" :
        //                $"Donation({donationCount}): {splitLine[11].Trim('"')} --> {parseResult.ToString("c")}";

        //            totalDonations += parseResult;
        //            filtered.Add(msg);
        //            donationCount++;
        //        }
        //    }

        //    var finalResult = from v in filtered
        //                      select v;

        //    foreach (var l in finalResult)
        //        Console.WriteLine(l);

        //    Log(finalResult);
        //    Log($"\n\nTotal Donation Amount: {totalDonations.ToString("c")}\nAverage Donation Amount: " +
        //        $"{(totalDonations / finalResult.Count()).ToString("c")}\n\n");


        //}
    }
}
