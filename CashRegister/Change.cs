using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    public class Change
    {
        private int _changeOwed = 0;
        private int _dollars = 0;
        private int _quarters = 0;
        private int _dimes = 0;
        private int _nickels = 0;
        private int _pennies = 0;
        private bool _mod3 = false;
        private bool _oweMoney = false;
        private int _owedAmount = 0;

        public int ChangeOwed
        {
            get { return _changeOwed; }
            set { _changeOwed = value; }
        }
        public int Dollars
        {
            get { return _dollars; }
            set { _dollars = value; }
        }
        public int Quarters
        {
            get { return _quarters; }
            set { _quarters = value; }
        }
        public int Dimes
        {
            get { return _dimes; }
            set { _dimes = value; }
        }
        public int Nickels
        {
            get { return _nickels; }
            set { _nickels = value; }
        }
        public int Pennies
        {
            get { return _pennies; }
            set { _pennies = value; }
        }
        public bool IsRandomChange
        {
            get { return _mod3; }
            set { _mod3 = value; }
        }
        public bool MoneyOwed
        {
            get { return _oweMoney; }
            set { _oweMoney = value; }
        }
        public int AmountOwed
        {
            get { return _owedAmount; }
            set { _owedAmount = value; }
        }

        public Change()
        { }

        public Change(int Dollars, int Quarters, int Dimes, int Nickels, int Pennies, int changeOwed, bool Mod3)
        {
            _dollars = Dollars;
            _quarters = Quarters;
            _dimes = Dimes;
            _nickels = Nickels;
            _pennies = Pennies;
            _changeOwed = changeOwed;
            _mod3 = Mod3;
        }

        public Change(bool MoneyOwed, int AmountOwed)
        {
            _oweMoney = MoneyOwed;
            _owedAmount = AmountOwed;
        }
    }
}
