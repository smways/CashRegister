using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CashRegister
{
    public class FileProcessor
    {
        public FileProcessor()
        { }

        public static List<Transaction> ProcessCSV(string path)
        {
            List<Transaction> transactions = new List<Transaction>();
            using (var reader = new StreamReader(File.OpenRead(path)))
            {
                while (!reader.EndOfStream)
                {
                    try
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        Transaction tran = new Transaction(decimal.Parse(values[0].ToString()), decimal.Parse(values[1].ToString()));

                        transactions.Add(tran);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error reading file: " + ex.Message + " ---- " + ex.StackTrace);
                    }
                }
                reader.Close();
            }

            return transactions;
        }

        public static void WriteOutput(List<Transaction> transactions, string OutputPath, bool VerboseOutput)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(OutputPath))
            {
                foreach (Transaction tran in transactions)
                {
                    if (!tran.Change.MoneyOwed)
                    {
                        if (VerboseOutput)
                        {
                            //Easily readable for debugging
                            file.WriteLine("");
                            file.WriteLine("Change owed: " + ((decimal)tran.Change.ChangeOwed / 100).ToString());
                            file.WriteLine("Is the amount owed divisible by 3? " + tran.Change.IsRandomChange.ToString());
                            file.WriteLine("Dollars: " + tran.Change.Dollars.ToString());
                            file.WriteLine("Quarters: " + tran.Change.Quarters.ToString());
                            file.WriteLine("Dimes: " + tran.Change.Dimes.ToString());
                            file.WriteLine("Nickels: " + tran.Change.Nickels.ToString());
                            file.WriteLine("Pennies: " + tran.Change.Pennies.ToString());
                            file.WriteLine("");
                            file.WriteLine("---------------------------------------------------------------------------------------------------------------");
                        }
                        else
                        {
                            //Matches specifications
                            StringBuilder sbOutput = new StringBuilder();
                            sbOutput.Append(tran.Change.Dollars.ToString());
                            sbOutput.Append(" Dollars, ");
                            sbOutput.Append(tran.Change.Quarters.ToString());
                            sbOutput.Append(" Quarters, ");
                            sbOutput.Append(tran.Change.Dimes.ToString());
                            sbOutput.Append(" Dimes, ");
                            sbOutput.Append(tran.Change.Nickels.ToString());
                            sbOutput.Append(" Nickels, ");
                            sbOutput.Append(tran.Change.Pennies.ToString());
                            sbOutput.Append(" Pennies ");
                            file.WriteLine(sbOutput.ToString());
                        }
                    }
                    else
                    {
                        if (VerboseOutput)
                        {
                            file.WriteLine("");
                        }
                        StringBuilder sbOutput = new StringBuilder();
                        sbOutput.Append("The customer owes an additional $");
                        sbOutput.Append(((decimal)tran.Change.AmountOwed / 100).ToString());
                        file.WriteLine(sbOutput.ToString());
                        if (VerboseOutput)
                        {
                            file.WriteLine("");
                            file.WriteLine("---------------------------------------------------------------------------------------------------------------");
                        }
                    }
                }
            }
        }
    }
}
