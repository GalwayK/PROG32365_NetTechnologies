using System.Security.Cryptography.X509Certificates;

namespace Week3Lesson1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Console.WriteLine("Hello, World!");
             ComissionedEmployee emp = new ComissionedEmployee(1, name: "Kyle Galway", creditRate: 1.2M, grossSale: 100);
             Console.WriteLine(emp.ToString());
             Console.WriteLine(emp.Earning());

             SalariedAndComissionedEmployee betterEmp = new SalariedAndComissionedEmployee(1, name: "Kyle Galway", creditRate: 1.2M, grossSale: 100, salary: 100000M);
             Console.WriteLine(betterEmp.ToString());
             Console.WriteLine(betterEmp.Earning());*/

            AreStringsNullable();
        }


        static void AreStringsNullable()
        {
            // Nullable string assigned to null 
            string? nullableString = null;
            string alsoNullable = null;

            
            nullableString = "It is nullable.";
            alsoNullable = "This is also nullable";
        }

        static void InferencedVariables()
        {
            // Variable decimal value is now of type decimal
            var decimalVariable = 1.2M;

            // Attempting to assign string value to decimalValue produces error
            /*decimalVariable = "decimalValue is now of type decimal and must follow all the rules of a strongly typed decimal variable. Once the code has been compiled, the var keyword essentially just becomes a stand in for the data type of the variable, this case decimal.";*/
        }
       
    }
}