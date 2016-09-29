/*  
 *  This class is to make sure that the income limits and tax rates 
 *  are in ascending order when being updated by the user.
 */

namespace TaxCalculator {
  public class DataValidator {
    public static int UpdateData(double[] arr, int index, double newValue) {
      if (index > arr.Length - 1)
        throw new System.IndexOutOfRangeException("Error! Interval between 1-6");
      if (index == 0) {
        if (arr[index + 1] < newValue) return 0;
      } else if (index == arr.Length - 1) {
        if (arr[index - 1] > newValue) return 0;
      } else {
        if (arr[index - 1] > newValue || arr[index + 1] < newValue) return 0;
      }
      return 1;
    }
    public static bool IsValid(double[] arr, int index, double newValue) {
      return (UpdateData(arr, index, newValue) == 1)? true : false;
    }
  }
}