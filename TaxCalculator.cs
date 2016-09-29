using System;
using System.Globalization;

namespace TaxCalculator {
  public class TaxCalculator{
    private static double[] _defaultIncomeLimits = new double[] {0, 3, 5, 10, 20, 25, Double.MaxValue};
    private static double[] _defaultTaxRates = new double[] {0, 0.1, 0.2, 0.3, 0.35, 0.4};
    private double[] currentIncomeLimits, currentTaxRates;
    public double GrossIncome {get; set;}
    public double Tax {get; set;}
    public double NetIncome {get;}
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
        return String.Format(new CultureInfo("en-US"), "{0:c}", currentIncomeLimits[interval] * Math.Pow(10,4));
      } catch (System.IndexOutOfRangeException ex) {
        throw new ArgumentOutOfRangeException("Error! Interval between 1-6", ex);
      }  
    }
    public void SetCurrentIncomeLimit(int interval, double newLimit) {
      if(!DataValidator.IsValid(currentIncomeLimits, interval, newLimit / Math.Pow(10, 4)))
        Console.WriteLine("\n\nSOMETHING WENT WRONG, CAN'T UPDATE THE INCOME LIMIT.");
      else 
        currentIncomeLimits[interval] = newLimit / Math.Pow(10,4);
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
        Console.WriteLine(String.Format(new CultureInfo("en-US"), "{0, -11} to {1, -20} {2, 5}",
                               GetCurrentIncomeLimit(i), GetCurrentIncomeLimit(i+1), GetCurrentTaxRate(i+1)));
    }        
  }
}