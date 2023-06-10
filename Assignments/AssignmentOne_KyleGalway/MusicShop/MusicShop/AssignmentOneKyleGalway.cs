namespace MusicShop
{
    internal class AssignmentOneKyleGalway
    {
        static MusicShop musicShop = MusicShop.MusicShopFactory();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Music Shop!\n");

            CreateInstruments();

            SortInstruments();

            PrintMostExpensiveInstrument();

            PrintLeastExpensiveInstrument();

            PrintInstrumentsInOrder();

            PrintInstrumentFamilySound();

            foreach (MusicalInstrument instrument in musicShop.ListInstruments)
            {
                PrintInstrument(instrument);
                Console.WriteLine();
            }
        }

        public static void CreateInstruments()
        {
            Dictionary<string, Func<decimal, MusicalInstrument>>  dictInstrumentFactories = musicShop.GetInstrumentFactories();

            foreach(KeyValuePair<string, Func<decimal, MusicalInstrument>> mapInstrumentFactory in dictInstrumentFactories)
            {
                decimal numPrice = GetDecimalInput($"Please enter the price " +
                    $"for {mapInstrumentFactory.Key}: ");
                MusicalInstrument instrument = 
                    mapInstrumentFactory.Value(numPrice);
                musicShop.ListInstruments.Add(instrument);
            }
            Console.WriteLine();
        }

        public static void SortInstruments()
        {
            musicShop.ListInstruments.Sort();
        }

        public static List<MusicalInstrument> CopyAndSortListInstruments()
        {
            List<MusicalInstrument> copyListInstruments = new
                List<MusicalInstrument>(musicShop.ListInstruments);

            copyListInstruments.Sort();

            return copyListInstruments;
        }

        public static void PrintMostExpensiveInstrument()
        {
            List<MusicalInstrument> copyListInstruments = 
                CopyAndSortListInstruments();

            MusicalInstrument expensiveInstrument = 
                copyListInstruments.First();

            Console.WriteLine($"The most expensive instrument is: " +
                $"{expensiveInstrument}");

            PrintInstrument(expensiveInstrument);
            Console.WriteLine();
        }

        public static void PrintLeastExpensiveInstrument()
        {
            List<MusicalInstrument> copyListInstruments =
                CopyAndSortListInstruments();

            MusicalInstrument cheapestInstrument =
                copyListInstruments.Last();

            Console.WriteLine($"The least expensive instrument is: " +
                $"{cheapestInstrument}");

            PrintInstrument(cheapestInstrument);
            Console.WriteLine();
        }

        public static void PrintInstrumentsInOrder()
        {
            Action<MusicalInstrument> CreatePrintInstrumentAction()
            {
                int numInstruments = 1;

                void printInstrument(MusicalInstrument instrument)
                {
                    Console.WriteLine($"{numInstruments++}. {instrument:-10} at {instrument.Price:C}");
                };

                return printInstrument;
            }

            Action<MusicalInstrument> printInstrument = 
                CreatePrintInstrumentAction();

            Console.WriteLine("Printing Instruments in Order of Price!");
            musicShop.ListInstruments.ForEach(printInstrument);
            Console.WriteLine();
        }

        public static void PrintInstrumentFamilySound()
        {
            Action<MusicalInstrument> CreatePrintFamilySoundAction()
            {
                string strFamily = 
                    GetStringInput("Please enter an instrument family: ")
                    .ToLower();

                bool IsFamilyType(Type instrumentType)
                {
                    return instrumentType.BaseType.Name.ToLower()
                        .Equals(strFamily);
                }

                bool AltIsFamilyType(Type instrumentType)
                {
                    bool isFamily = instrumentType != null 
                        && !instrumentType.FullName.ToLower()
                            .Contains("musicalinstrument") 
                            ? instrumentType.FullName.ToLower().Contains(strFamily) 
                                ? true
                                : AltIsFamilyType(instrumentType.BaseType)
                            : false;
                    return isFamily;
                }

                Action<MusicalInstrument> PrintFamilySound = (instrument) =>
                {
                    if (IsFamilyType(instrument.GetType()))
                    {
                        Console.WriteLine($"{instrument} makes sound by {instrument.Sound}");
                    }
                };
                return PrintFamilySound;
            }

            Action<string> CreatePrintFamilyNamesAction()
            {
                int numFamily = 1;

                void printFamilyName(string familyName)
                {
                    Console.WriteLine($"{numFamily++}. {familyName}");
                }
                return printFamilyName;
            }

            Action<string> PrintFamilyName = CreatePrintFamilyNamesAction();
            Console.WriteLine("Instrument Families!");
            musicShop.GetInstrumentFamilies().ForEach(PrintFamilyName);

            Action<MusicalInstrument> PrintFamilySound =
                CreatePrintFamilySoundAction();
            musicShop.ListInstruments.ForEach(PrintFamilySound);
            Console.WriteLine();
        }

        public static void PrintInstrument(MusicalInstrument instrument)
        {
            void PrintStandard()
            {
                Console.WriteLine($"{instrument}'s cost is: " +
                $"{instrument.Price:C}");

                Console.WriteLine($"{instrument}'s sound is: " +
                    $"{instrument.Sound}");

                Console.WriteLine($"{instrument} pitch type: " +
                        $"{instrument.PitchType}");
            }

            void PrintFixable()
            {
                if (instrument is IFixable)
                {
                    IFixable fixableInstrument = (IFixable)instrument;

                    Console.WriteLine($"{instrument} is fixed by: {fixableInstrument.HowToFix()}");
                }
            }

            void PrintPlayable()
            {
                if (instrument is IPlayable)
                {
                    IPlayable playableInstrument = (IPlayable)instrument;

                    Console.WriteLine($"{instrument} is played by: " +
                        $"{playableInstrument.HowToPlay()}");
                }
            }

            PrintStandard();

            PrintPlayable();

            PrintFixable();
        }

        public static string GetStringInput(string prompt)
        {
            Console.Write(prompt);
            string? strInput = Console.ReadLine();
            while (strInput == null)
            {
                Console.WriteLine("There was an error in your input, please" +
                    " try again!");
                Console.Write(prompt);
                strInput = Console.ReadLine();
            }
            return (string)strInput.Trim() ;
        }

        public static decimal GetDecimalInput(string prompt)
        {
            decimal decInput = 0.0M;
            string strInput = GetStringInput(prompt);
            while (!decimal.TryParse(strInput, out decInput)) 
            {
                Console.WriteLine("There was an error in your input, please " +
                    "try again!");
                strInput = GetStringInput(prompt);
            }
            return decInput;
        }
    }
}
