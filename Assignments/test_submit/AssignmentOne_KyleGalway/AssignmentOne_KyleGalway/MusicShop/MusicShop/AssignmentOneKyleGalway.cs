/*
 * Assignment: 1
 * Name: Kyle Galway
 * ID: 991418738
 * This is the main view class for accessing the music shop model 
 * for receiving console input and displaying console output. 
*/
namespace MusicShop
{
    internal class AssignmentOneKyleGalway
    {
        // Singleton MusicShop object for accessing application data.
        static MusicShop musicShop = MusicShop.MusicShopFactory();

        // Main method for launching application.
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Music Shop by Kyle Galway!\n");

            CreateInstruments();

            SortInstruments();

            PrintMostExpensiveInstrument();

            PrintLeastExpensiveInstrument();

            PrintInstrumentsInOrder();

            PrintInstrumentFamilySound();

            PrintAllInstruments();
        }

        // Method for creating Instruments using object factory methods.
        public static void CreateInstruments()
        {
            // Obtain factory methods for creating Instruments.
            Dictionary<string, Func<decimal, MusicalInstrument>>  dictInstrumentFactories = musicShop.GetInstrumentFactories();

            // Read price and instantiate all Instrument objects.
            foreach(KeyValuePair<string, Func<decimal, MusicalInstrument>> mapInstrumentFactory in dictInstrumentFactories)
            {
                decimal numPrice = GetDecimalInput($"Please enter the price " +
                    $"for {mapInstrumentFactory.Key}: ");

                MusicalInstrument instrument = 
                    mapInstrumentFactory.Value(numPrice);

                // Add Instrument instance to Music Shop list.
                musicShop.ListInstruments.Add(instrument);
            }
            Console.WriteLine();
        }

        // Method for commanding Music Shop to sort the list of Instruments.
        public static void SortInstruments()
        {
            musicShop.SortInstruments();
        }

        // Method for printing most expensive instrument.
        public static void PrintMostExpensiveInstrument()
        {
            // Obtain priciest instrument from Music Shop.
            MusicalInstrument expensiveInstrument =
                musicShop.PriciestInstrument;

            Console.WriteLine($"The most expensive instrument is: " +
                $"{expensiveInstrument}");

            // Display information of priciest instrument.
            PrintInstrument(expensiveInstrument);
            Console.WriteLine();
        }

        // Method for printing cheapest instrument.
        public static void PrintLeastExpensiveInstrument()
        {
            // Obtain cheapest instrument from Music Shop.
            MusicalInstrument cheapestInstrument =
                musicShop.CheapestInstrument;

            Console.WriteLine($"The least expensive instrument is: " +
                $"{cheapestInstrument}");

            // Display information of cheapest instrument.
            PrintInstrument(cheapestInstrument);
            Console.WriteLine();
        }

        // Method for printing instruments in order of price. 
        public static void PrintInstrumentsInOrder()
        {
            // Function which creates action for displaying each instrument.
            Action<MusicalInstrument> CreatePrintInstrumentAction()
            {
                // Closure variable for displaying instrument rank.
                int numInstruments = 1;

                // Function for printing each instrument.
                void printInstrument(MusicalInstrument instrument)
                {
                    Console.WriteLine($"{numInstruments++}. {instrument:-10} at {instrument.Price:C}");
                };

                // Return Print Function as Action Function variable.
                return printInstrument;
            }

            // Create Action Function Variable.
            Action<MusicalInstrument> printInstrument = 
                CreatePrintInstrumentAction();

            Console.WriteLine("Printing Instruments in Order of Price!");

            // Ensure instruments are sorted. 
            musicShop.SortInstruments();

            // For each Instrument, run the Print Instrument Action Function.
            musicShop.ListInstruments.ForEach(printInstrument);
            Console.WriteLine();
        }
       
        // Method for printing sounds of instrument family obtained from input.
        public static void PrintInstrumentFamilySound()
        {
            // Function for creating PrintFamilySound Action Function.
            Action<MusicalInstrument> CreatePrintFamilySoundAction()
            {
                // Action Function Variable for printing family sound.
                Action<MusicalInstrument> PrintFamilySound = (instrument) =>
                {
                    Console.WriteLine($"{instrument} makes sound by" +
                        $" {instrument.Sound}");
                };
                return PrintFamilySound;
            }

            // Function for creating PrintFamilyNames Action Function.
            Action<string> CreatePrintFamilyNamesAction()
            {
                // Closure variable for displaying Instrument rank.
                int numFamily = 1;

                // Function declaration for printing family names.
                void printFamilyName(string familyName)
                {
                    Console.WriteLine($"{numFamily++}. {familyName}");
                }
                return printFamilyName;
            }

            // Create PrintFamilyName Action Function Variable.
            Action<string> PrintFamilyName = CreatePrintFamilyNamesAction();
            Console.WriteLine("Instrument Families!");

            // Print all available family names.
            musicShop.GetInstrumentFamilies().ForEach(PrintFamilyName);

            string strFamily =
                    GetStringInput("Please enter an instrument family: ")
                    .ToLower();

            // Get all instruments matching entered family name.
            List<MusicalInstrument> familyInstruments = musicShop.GetInstrumentsByFamilyName(strFamily);

            // Create PrintFamilySound Action Function Variable.
            Action<MusicalInstrument> PrintFamilySound =
                CreatePrintFamilySoundAction();

            // For each Instrument in family, print sound.
            familyInstruments.ForEach(PrintFamilySound);
            Console.WriteLine();
        }

        // Method for printing a single instrument.
        public static void PrintInstrument(MusicalInstrument instrument)
        {
            // Function for printing basic information of any Instrument.
            void PrintStandard()
            {
                Console.WriteLine($"{instrument}'s cost is: " +
                $"{instrument.Price:C}");

                Console.WriteLine($"{instrument}'s sound is: " +
                    $"{instrument.Sound}");

                Console.WriteLine($"{instrument} pitch type: " +
                        $"{instrument.PitchType}");
            }

            // Function for printing repair information of fixable instruments.
            void PrintFixable()
            {
                // If instrument is fixable, print repair information.
                if (instrument is IFixable)
                {
                    IFixable fixableInstrument = instrument as IFixable;

                    Console.WriteLine($"{instrument} is fixed by: {fixableInstrument.HowToFix()}");
                }
            }

            // Function for printing play information of playable instruments.
            void PrintPlayable()
            {
                // If instrument is playable, print play information.
                if (instrument is IPlayable)
                {
                    IPlayable playableInstrument = instrument as IPlayable;

                    Console.WriteLine($"{instrument} is played by: " +
                        $"{playableInstrument.HowToPlay()}");
                }
            }

            // Print standard information.
            PrintStandard();

            // Print playable information if playable.
            PrintPlayable();

            // Print fixable information if fixable.
            PrintFixable();
        }

        // Method for printing all instruments.
        public static void PrintAllInstruments()
        {
            // Print all instruments, regardless of whether List is sorted.
            Console.WriteLine("Printing all Instruments!");
            foreach (MusicalInstrument instrument in musicShop.ListInstruments)
            {
                PrintInstrument(instrument);
                Console.WriteLine();
            }
        }

        // Method for displaying a prompt and reading string input.
        public static string GetStringInput(string prompt)
        {
            // Display prompt to user.
            Console.Write(prompt);

            // Read input from console.
            string? strInput = Console.ReadLine();

            // If input is invalid, continue to prompt for input.
            while (strInput == null)
            {
                Console.WriteLine("There was an error in your input, please" +
                    " try again!");
                Console.Write(prompt);
                strInput = Console.ReadLine();
            }
            // Return input with no trailing characters.
            return (string)strInput.Trim() ;
        }

        // Method for displaying a prompt and reading decimal input.
        public static decimal GetDecimalInput(string prompt)
        {
            // Create placeholder decimal value.
            decimal decInput = 0.0M;

            // Read string input from console.
            string strInput = GetStringInput(prompt);

            // If input cannot be parsed into decimal, repeat input.
            while (!decimal.TryParse(strInput, out decInput)) 
            {
                Console.WriteLine("There was an error in your input, please " +
                    "try again!");
                strInput = GetStringInput(prompt);
            }
            // Return decimal input.
            return decInput;
        }
    }
}