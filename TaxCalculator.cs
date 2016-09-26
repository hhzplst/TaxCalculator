using System;

namespace TaxCalculator {
  public class TaxCalculator : Exception {
    private static double[] defaultIncomeLimits = new double[] {30000, 50000, 100000, 200000, 250000};
    private static double[] defaultTaxRates = new double[] {0, 0.1, 0.2, 0.3, 0.35, 0.4};
    private double[] currentIncomeLimits, currentTaxRates;
    public double GrossIncome {get; set;}
    public double Tax {get;}
    public double NetIncome {get;}
    public TaxCalculator() {
      Init();
    }
    private void Init() {
      currentIncomeLimits = defaultIncomeLimits;
      currentTaxRates = defaultTaxRates;
    }
    public void Reset() { Init(); }
    public double getCurrentIncomeLimit(int interval) {
      try {
        return currentIncomeLimits[interval-1];
      } catch (System.IndexOutOfRangeException ex) {
        System.ArgumentException argEx = new ArgumentException("Error! Interval between 1-5", ex);
        throw argEx;
      }  
    }
    public void setCurrentIncomeLImit(int interval, double newLimit) {
      try {
        currentIncomeLimits[interval-1] = newLimit;
      } catch (System.IndexOutOfRangeException ex) {
        System.ArgumentException argEx = new ArgumentException("Error! Interval between 1-5", ex);
        throw argEx;
      }  
    }
  
  }
}