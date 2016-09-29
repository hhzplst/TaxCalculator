using System;

namespace TaxCalculator {
    public class TaxCalculatorTest {
        public static void Main(string[] args) {
            TaxCalculator myCalculator = new TaxCalculator();
            //intervals are from 1 to 6
            Console.WriteLine("Initial tax table..."); 
            myCalculator.PrintDataTable();
            Console.WriteLine("\n\nSetting the income limit of the 6th interval to $300,000...");
            myCalculator.SetCurrentIncomeLimit(6, 300000);
            myCalculator.PrintDataTable();

            Console.WriteLine("\n\nSetting the tax rate of the 3rd to 25%...");
            myCalculator.SetCurrentTaxRate(3, 0.25);
            myCalculator.PrintDataTable();

            Console.WriteLine("\n\nTrying to set the income limit of the 2nd interval to $20,000...");
            myCalculator.SetCurrentIncomeLimit(2, 20000);
            Console.WriteLine("\n\nTrying to set the tax rate of the 4th interval to 15%...");
            myCalculator.SetCurrentTaxRate(4, 0.15);
            myCalculator.PrintDataTable();

            Console.WriteLine("\n\nResetting the tax table...");
            myCalculator.Reset();
            myCalculator.PrintDataTable();

            myCalculator.GrossIncome = 85000;
            myCalculator.PrintTaxCalculationResult();
        }
    }
}
