using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashRegister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Tests
{
    [TestClass()]
    public class TwistyMathTests
    {
        [TestMethod()]
        public void TestTwistyMathCalculations()
        {
            //Test code path when customer owes money
            Change owedMoney = new Change();
            owedMoney.AmountOwed = 532;
            owedMoney.MoneyOwed = true;

            TwistyMath TwistOwed = new TwistyMath();
            Change owedMoneyTestResult = TwistOwed.CalculateChange((decimal)7.25, (decimal)12.57);

            Assert.AreEqual(owedMoney.MoneyOwed, owedMoneyTestResult.MoneyOwed);
            Assert.AreEqual(owedMoney.AmountOwed, owedMoneyTestResult.AmountOwed);
            Assert.AreEqual(owedMoney.Dollars, owedMoneyTestResult.Dollars);

            //Test code path when change is due and the amount owed is not divisible by 3
            Change StandardChange = new Change();
            StandardChange.Dollars = 1;
            StandardChange.Quarters = 3;
            StandardChange.Pennies = 3;
            StandardChange.IsRandomChange = false;
            StandardChange.ChangeOwed = 178;

            TwistyMath TwistStandardChange = new TwistyMath();
            Change StandardChangeTestResult = TwistStandardChange.CalculateChange((decimal)5.00, (decimal)3.22);

            Assert.AreEqual(StandardChange.Dollars, StandardChangeTestResult.Dollars);
            Assert.AreEqual(StandardChange.Quarters, StandardChangeTestResult.Quarters);
            Assert.AreEqual(StandardChange.Dimes, StandardChangeTestResult.Dimes);
            Assert.AreEqual(StandardChange.Nickels, StandardChangeTestResult.Nickels);
            Assert.AreEqual(StandardChange.Pennies, StandardChangeTestResult.Pennies);
            Assert.AreEqual(StandardChange.IsRandomChange, StandardChangeTestResult.IsRandomChange);
            Assert.AreEqual(StandardChange.ChangeOwed, StandardChangeTestResult.ChangeOwed);
        }
    }
}
