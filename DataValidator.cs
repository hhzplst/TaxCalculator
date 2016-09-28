namespace TaxCalculator {
  public class DataValidator {
    public static int UpdateData(double[] arr, int index, double newValue) {
      if (index > arr.Length - 1) return 0;
      if (index == 0)
        if (newValue > arr[index + 1]) return 0;
      else if (index == arr.Length - 1)
        if (newValue < arr[index - 1]) return 0;
      else
        if (newValue < arr[index - 1] || newValue > arr[index + 1]) return 0;

      return 1;
    }
    public static bool IsValid(double[] arr, int index, double newValue) {
      return (UpdateData(arr, index, newValue) == 1)? true:false;
    }
  }
}