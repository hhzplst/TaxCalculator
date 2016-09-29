using System;
using System.Globalization;

namespace TaxCalculator {
  public class TaxCalculator{
    private static double[] _defaultIncomeLimits = new double[] {0, 30000, 50000, 100000, 200000, 250000, Double.PositiveInfinity};
    private static double[] _defaultTaxRates = new double[] {0, 0.1, 0.2, 0.3, 0.35, 0.4};
    private double[] currentIncomeLimits, currentTaxRates;
    private double grossIncome;
    public double GrossIncome {
      get { 
        return grossIncome;
      }
      set { 
        if(value < 0)
          throw new ArgumentException("Can't have negative gross income!");
        grossIncome = value;
      }
    }
    public double Tax {get { return CalculateTax(); }}
    public double NetIncome {get { return GrossIncome - Tax; }}
    public TaxCalculator() {
      Init();
    }
    public TaxCalculator(double[] taxIncomeLimits, double[] taxRates) {
      currentIncomeLimits = taxIncomeLimits;
      currentTaxRates = taxRates;
    }
    private void Init() {
      currentIncomeLimits = (double[])_defaultIncomeLimits.Clone();
      currentTaxRates = (double[])_defaultTaxRates.Clone();
    }
    public void Reset() { Init(); }
    public string GetCurrentIncomeLimit(int interval) {
      try {
        return String.Format(new CultureInfo("en-US"), "{0:c}", currentIncomeLimits[interval]);
      } catch (System.IndexOutOfRangeException ex) {
        throw new ArgumentOutOfRangeException("Error! Interval between 1-6", ex);
      }  
    }
    public void SetCurrentIncomeLimit(int interval, double newLimit) {
      if(!DataValidator.IsValid(currentIncomeLimits, interval, newLimit))
        Console.WriteLine("\n\nSOMETHING WENT WRONG, CAN'T UPDATE THE INCOME LIMIT.");
      else 
        currentIncomeLimits[interval] = newLimit;
    }
    public string GetCurrentTaxRate(int interval) {
      try {
        return String.Format("{0:0%}", currentTaxRates[interval - 1]);
      } catch (System.IndexOutOfRangeException ex) {
        throw new ArgumentOutOfRangeException("Error! Interval between 1-6", ex);
      }  
    }
    public void SetCurrentTaxRate(int interval, double newRate) {
      if(!DataValidator.IsValid(currentTaxRates, interval - 1, newRate))
        Console.WriteLine("\n\nSOMETHING WENT WRONG, CAN'T UPDATE THE TAX RATE.");
      else 
        currentTaxRates[interval - 1] = newRate;
    }
    public void PrintDataTable() {
      Console.WriteLine(String.Format("\n\n**********************************************\n" +
                                          "{0, -20}              {1, 10}\n" +
                                          "**********************************************\n", 
                                          "Incremental Income", "Tax Rate"));
      PrintLines();
    }
    public void PrintLines() {
      for (int i = 0; i < 6; i++)
        Console.WriteLine(String.Format("{0, -11} to {1, -20} {2, 5}", GetCurrentIncomeLimit(i), 
                                                        GetCurrentIncomeLimit(i+1), GetCurrentTaxRate(i+1)));
    }
    public void PrintTaxCalculationResult() {
      Console.WriteLine(String.Format(new CultureInfo("en-US"), "\n\n***************************************************\n" +
                                                                "{0, -20}{1, -20}{2, -20}\n" +
                                                                "***************************************************\n" +
                                                                "{3, -20:c}{4, -20:c}{5, -20:c}\n",
                                                                "Gross Income", "Tax", "Net Income", GrossIncome, Tax, NetIncome));

    }
    private double CalculateTax() {
      double taxAmount = 0;
      for (int i = 0; i < currentTaxRates.Length; i++) {
        if ((GrossIncome >= currentIncomeLimits[i] && GrossIncome < currentIncomeLimits[i+1])) {
          taxAmount += currentTaxRates[i] * (GrossIncome - currentIncomeLimits[i]);
          break;
        } else {
          taxAmount += currentTaxRates[i] * (currentIncomeLimits[i+1] - currentIncomeLimits[i]);
        } 
      }
      return taxAmount;
    } 
  }
}