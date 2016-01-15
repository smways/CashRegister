using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    public class Transaction
    {
        public decimal AmountPaid
        { get; set; }
        public decimal AmountOwed
        { get; set; }
        public Change Change;

        public Transaction()
        {}

        public Transaction(decimal _amountPaid, decimal _amountOwed)
        {
            AmountPaid = _amountPaid;
            AmountOwed = _amountOwed;
        }

        public void GetChange()
        {
            try
            {
                Change = new TwistyMath().CalculateChange(AmountPaid, AmountOwed);
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error has occured calculating the changed owed to the customer. Error details: " + ex.Message + " ----- " + ex.StackTrace);
            }
        }

        public void DisplayChange()
        {
            Console.WriteLine("Change owed: " + ((decimal)Change.ChangeOwed / 100).ToString());
            Console.WriteLine("Is the amount owed divisible by 3? " + Change.IsRandomChange.ToString());
            Console.WriteLine("Dollars: " + Change.Dollars.ToString());
            Console.WriteLine("Quarters: " + Change.Quarters.ToString());
            Console.WriteLine("Dimes: " + Change.Dimes.ToString());
            Console.WriteLine("Nickels: " + Change.Nickels.ToString());
            Console.WriteLine("Pennies: " + Change.Pennies.ToString());
        }
    }
}
