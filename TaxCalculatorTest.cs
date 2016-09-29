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

            Console.WriteLine("\n\nCalculating tax for $85,000...");
            myCalculator.GrossIncome = 85000;
            myCalculator.PrintTaxCalculationResult();

            Console.WriteLine("\n\nCalculating tax for $20,000...");
            myCalculator.GrossIncome = 20000;
            myCalculator.PrintTaxCalculationResult();

            Console.WriteLine("\n\nCalculating tax for $50,000...");
            myCalculator.GrossIncome = 50000;
            myCalculator.PrintTaxCalculationResult();

            Console.WriteLine("\n\nCalculating tax for $300,000...");
            myCalculator.GrossIncome = 300000;
            myCalculator.PrintTaxCalculationResult();
        }
    }
}

/*************************************************TEST OUTPUT******************************************************

➜  TaxCalculator git:(master) ✗ dotnet run
Project TaxCalculator (.NETCoreApp,Version=v1.0) will be compiled because inputs were modified
Compiling TaxCalculator for .NETCoreApp,Version=v1.0

Compilation succeeded.
    0 Warning(s)
    0 Error(s)

Time elapsed 00:00:01.4364226
 

Initial tax table...


**********************************************
Incremental Income                  Tax Rate
**********************************************

$0.00       to $30,000.00              0%
$30,000.00  to $50,000.00             10%
$50,000.00  to $100,000.00            20%
$100,000.00 to $200,000.00            30%
$200,000.00 to $250,000.00            35%
$250,000.00 to ∞                      40%


Setting the income limit of the 6th interval to $300,000...


**********************************************
Incremental Income                  Tax Rate
**********************************************

$0.00       to $30,000.00              0%
$30,000.00  to $50,000.00             10%
$50,000.00  to $100,000.00            20%
$100,000.00 to $200,000.00            30%
$200,000.00 to $250,000.00            35%
$250,000.00 to $300,000.00            40%


Setting the tax rate of the 3rd to 25%...


**********************************************
Incremental Income                  Tax Rate
**********************************************

$0.00       to $30,000.00              0%
$30,000.00  to $50,000.00             10%
$50,000.00  to $100,000.00            25%
$100,000.00 to $200,000.00            30%
$200,000.00 to $250,000.00            35%
$250,000.00 to $300,000.00            40%


Trying to set the income limit of the 2nd interval to $20,000...


SOMETHING WENT WRONG, CAN'T UPDATE THE INCOME LIMIT.


Trying to set the tax rate of the 4th interval to 15%...


SOMETHING WENT WRONG, CAN'T UPDATE THE TAX RATE.


**********************************************
Incremental Income                  Tax Rate
**********************************************

$0.00       to $30,000.00              0%
$30,000.00  to $50,000.00             10%
$50,000.00  to $100,000.00            25%
$100,000.00 to $200,000.00            30%
$200,000.00 to $250,000.00            35%
$250,000.00 to $300,000.00            40%


Resetting the tax table...


**********************************************
Incremental Income                  Tax Rate
**********************************************

$0.00       to $30,000.00              0%
$30,000.00  to $50,000.00             10%
$50,000.00  to $100,000.00            20%
$100,000.00 to $200,000.00            30%
$200,000.00 to $250,000.00            35%
$250,000.00 to ∞                      40%


Calculating tax for $85,000...


***************************************************
Gross Income        Tax                 Net Income          
***************************************************
$85,000.00          $9,000.00           $76,000.00          



Calculating tax for $20,000...


***************************************************
Gross Income        Tax                 Net Income          
***************************************************
$20,000.00          $0.00               $20,000.00          



Calculating tax for $50,000...


***************************************************
Gross Income        Tax                 Net Income          
***************************************************
$50,000.00          $2,000.00           $48,000.00          



Calculating tax for $300,000...


***************************************************
Gross Income        Tax                 Net Income          
***************************************************
$300,000.00         $79,500.00          $220,500.00         

***********************************************END TEST OUTPUT*************************************************/