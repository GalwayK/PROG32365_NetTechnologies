namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Currency currencyOne = new Currency(strType: "Euro", dblWeight: 1.2, decValue: 100, firstName: "Kyle", lastName: "Galway");
            Console.WriteLine($"Type: {currencyOne.StrType} Value: ${currencyOne.DecValue} Weight: {currencyOne.DblWeight} Owner: {currencyOne.OwnerName}");
            currencyOne.AddValueToAccount(10.0M, 20.0M, 99M);
            Console.WriteLine($"Type: {currencyOne.StrType} Value: ${currencyOne.DecValue} Weight: {currencyOne.DblWeight} Owner: {currencyOne.OwnerName}");
            decimal decOutput;
            Console.Write("Enter an amount in dollars: ");
            decimal decInput = Convert.ToDecimal(Console.ReadLine());
            currencyOne.SubtractValue(ref decInput, out decOutput);
            Console.WriteLine($"Input: {decInput} Output: {decOutput.ToString("C"), 20}");

            Currency currencyTwo = new Currency("USD", dblWeight: 0.8, decValue: 100.0M);
            Console.WriteLine($"Type: {currencyTwo.StrType} Value: ${currencyTwo.DecValue} Weight: {currencyTwo.DblWeight} Owner: {currencyTwo.OwnerName}");

            Currency currencyThree = currencyOne + currencyTwo;
            Console.WriteLine($"Type: {currencyThree.StrType} Value: ${currencyThree.DecValue} Weight: {currencyThree.DblWeight} Owner: {currencyThree.OwnerName}");
        }
    }
}