namespace _1_HelloWorld
{
    internal class Program
    {
        // The main method in C# uses a capital Main. Strings in C# are a primitive type by default, not a class. 
        // Like most other languages however, there are classes for each data type. 

        static void Main(string[] args)
        {
            // Console is the class for operating on the command line. 
            Console.WriteLine("Hello world!");
            Console.Write("Write something: ");
            int intInput = int.Parse(Console.ReadLine());
            Console.WriteLine("You have entered: " + intInput);

        }
    }
}

// Define 
// Public: 
// Private: 
// Protected: 
// Internal:
// Default: Used to define a default body for an interface. (Research Further). 

// C# doesn't use packages, but instead just uses folders without the nomenclature. 

