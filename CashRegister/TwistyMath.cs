using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    public class TwistyMath
    {
        private const int _dollar = 100;
        private const int _quarter = 25;
        private const int _dime = 10;
        private const int _nickel = 5;
        private const int _penny = 1;

        public TwistyMath()
        { }

        public Change CalculateChange(decimal AmountPaid, decimal AmountOwed)
        {
            Change _change = new Change();
            int _calculatedChange = 0;
            int _amountPaidHundreds = 0;
            int _amountOwedHundreds = 0;

            List<int> Denominations = new List<int>();
            Denominations.Add(100);
            Denominations.Add(25);
            Denominations.Add(10);
            Denominations.Add(5);
            Denominations.Add(1);

            try
            {
                _amountPaidHundreds = (int)(AmountPaid * 100);
                _amountOwedHundreds = (int)(AmountOwed * 100);
                _calculatedChange = _amountPaidHundreds - _amountOwedHundreds;
                if (_calculatedChange < 0)
                {
                    //If the customer has not provided enough money to cover thier bill tell the cashier that they owe more money.
                    _change.MoneyOwed = true;
                    _change.AmountOwed = _calculatedChange * -1;
                }
                else
                {
                    _change.ChangeOwed = _calculatedChange;
                    if (_calculatedChange % 3 == 0)
                    {
                        _change.IsRandomChange = true;
                        //Twisty Math -- If the "owed" amount is divisible by 3, the app should randomly generate the change denominations
                        Random rand = new Random();
                        while (_calculatedChange > 0)
                        {
                            var randInt = Denominations[rand.Next(0, Denominations.Count)];
                            if (randInt <= _calculatedChange)
                            {
                                switch (randInt)
                                {
                                    case 100:
                                        _change.Dollars = _change.Dollars + (int)(_calculatedChange / _dollar);
                                        _calculatedChange = _calculatedChange - ((int)(_calculatedChange / _dollar) * _dollar);
                                        break;
                                    case 25:
                                        _change.Quarters = _change.Quarters + (int)(_calculatedChange / _quarter);
                                        _calculatedChange = _calculatedChange - ((int)(_calculatedChange / _quarter) * _quarter);
                                        break;
                                    case 10:
                                        _change.Dimes = _change.Dimes + (int)(_calculatedChange / _dime);
                                        _calculatedChange = _calculatedChange - ((int)(_calculatedChange / _dime) * _dime);
                                        break;
                                    case 5:
                                        _change.Nickels = _change.Nickels + (int)(_calculatedChange / _nickel);
                                        _calculatedChange = _calculatedChange - ((int)(_calculatedChange / _nickel) * _nickel);
                                        break;
                                    case 1:
                                        _change.Pennies = _change.Pennies + (int)(_calculatedChange / _penny);
                                        _calculatedChange = _calculatedChange - ((int)(_calculatedChange / _penny) * _penny);
                                        break;
                                }
                            }
                        }
                    }
                    else
                    {
                        //The function of the application is to tell the cashier how much change is owed, and what denominations should be used. 
                        //In most cases the app should return the minimum amount of physical change.
                        _change.Dollars = (int)(_calculatedChange / _dollar);
                        _change.Quarters = (int)((_calculatedChange % _dollar) / _quarter);
                        _change.Dimes = (int)(((_calculatedChange % _dollar) % _quarter) / _dime);
                        _change.Nickels = (int)((((_calculatedChange % _dollar) % _quarter) % _dime) / _nickel);
                        _change.Pennies = (int)(((((_calculatedChange % _dollar) % _quarter) % _dime) % _nickel) / _penny);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _change;
        }
    }
}
