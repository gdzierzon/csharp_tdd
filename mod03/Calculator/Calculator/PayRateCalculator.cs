namespace Calculator
{
    public class PayRateCalculator: ICalculator
    {
        public double CalculateGrossPay(double hoursWorked, double payRate, bool isSalaried)
        {
            if (isSalaried) hoursWorked = 40;

            return hoursWorked * payRate;
        }

        public int Add(int a, int b)
        {
            return 0;
        }
    }
}