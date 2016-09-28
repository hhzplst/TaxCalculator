using System;
using System.Globalization;

namespace TaxCalculator {
  public class TaxCalculator{
    private static double[] defaultIncomeLimits = new double[] {3, 5, 10, 20, 25};
    private static double[] defaultTaxRates = new double[] {0, 0.1, 0.2, 0.3, 0.35, 0.4};
    private double[] currentIncomeLimits, currentTaxRates;
    public double GrossIncome {get; set;}
    public double Tax {get; set;}
    public double NetIncome {get;}
    public TaxCalculator() {
      Init();
    }
    private void Init() {
      currentIncomeLimits = defaultIncomeLimits;
      currentTaxRates = defaultTaxRates;
    }
    public void Reset() { Init(); }
    public string getCurrentIncomeLimit(int interval) {
      try {
        return String.Format(new CultureInfo("en-US"), "{0:c}", currentIncomeLimits[interval-1] * Math.Pow(10,4));
      } catch (System.IndexOutOfRangeException ex) {
        throw new ArgumentOutOfRangeException("Error! Interval between 1-5", ex);
      }  
    }
    public void setCurrentIncomeLImit(int interval, double newLimit) {
      if(!DataValidator.IsValid(currentIncomeLimits, interval - 1, newLimit / Math.Pow(10, 4)))
        Console.WriteLine("Something went wrong, can't update the income limit. ");
      else 
        currentIncomeLimits[interval - 1] = newLimit / Math.Pow(10,4);
    }
    public string getCurrentTaxRate(int interval) {
      try {
        return String.Format("{0:0%}", currentTaxRates[interval - 1]);
      } catch (System.IndexOutOfRangeException ex) {
        throw new ArgumentOutOfRangeException("Error! Interval between 1-5", ex);
      }  
    }
    public void setCurrentTaxRate(int interval, double newRate) {
      if(!DataValidator.IsValid(currentIncomeLimits, interval - 1, newRate))
        Console.WriteLine("Something went wrong, can't update the income limit. ");
      else 
        currentIncomeLimits[interval - 1] = newRate;
    }
    public void PrintDataTable() {
      Console.WriteLine(String.Format("**********************************************\n" +
                                      "{0, -25}     {1, -5}                          \n" +
                                      "**********************************************\n" +
                                      "Incremental Income", "Tax Rate"));
      
    }        
  }
}