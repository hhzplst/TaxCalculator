using System;

namespace TaxCalculator {
    public class TaxCalculatorTest {
        public static void Main(string[] args) {
            TaxCalculator myCalculator = new TaxCalculator();
            Console.WriteLine(myCalculator.getCurrentIncomeLimit(2));
            Console.WriteLine(myCalculator.getCurrentIncomeLimit(6));
        }
    }
}
