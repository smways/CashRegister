using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            StartProcessingFile();
        }

        private static void StartProcessingFile()
        {
            try
            {
                Console.WriteLine("Welcome to Creative Cash Draw Solutions");
                Console.Write("Please enter a valid file path for the input file: ");
                string path = Console.ReadLine();
                Console.Write("Please enter a valid pather for the output file: ");
                string outpath = Console.ReadLine();
                if (System.IO.File.Exists(path))
                {
                    List<Transaction> transactions = FileProcessor.ProcessCSV(path);
                    foreach (Transaction tran in transactions)
                    {
                        tran.GetChange();
                        //tran.DisplayChange(); //Method used for visual debugging
                    }
                    FileProcessor.WriteOutput(transactions, outpath, true);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error has occured. The System will now exit.");
            }
        }
    }
}
