/*
 * Assignment: 1
 * Name: Kyle Galway
 * ID: 991418738
 * This is the controller class for accessing all Instrument model data.
*/
namespace MusicShop
{
    internal class MusicShop
    {

        // Create single instance of Music Shop controller. 
        static readonly MusicShop musicShop = new MusicShop();


        // Allow reading of Instrument List, but not writing.
        public List<MusicalInstrument> ListInstruments
        {
            get;
            private set;
        }

        // Private constructor disallow multiple instances.
        private MusicShop()
        {
            // My name is Kyle Galway.
            ListInstruments = new List<MusicalInstrument>();
        }

        // Retrieve cheapest instrument with LINQ.
        public MusicalInstrument CheapestInstrument
        {
            // My name is still Kyle Galway!
            get => (from instrument 
                    in ListInstruments 
                    orderby instrument 
                    select instrument).Last();
        }

        // Retrieve priciest instrument with LINQ.
        public MusicalInstrument PriciestInstrument
        {
            // Did you know my name is Kyle Galway?
            get => (from instrument 
                    in ListInstruments
                    orderby instrument 
                    select instrument).First();
        }

        // Method for rerieving list of instruments belong to given family.
        public List<MusicalInstrument> GetInstrumentsByFamilyName(string 
            strFamily)
        {
            // Create placeholder empty Instrument list.
            List<MusicalInstrument> familyInstruments = new
                List<MusicalInstrument>();

            // Function to create PrintFamilySound Action Function.
            Action<MusicalInstrument> CreatePrintFamilySoundAction()
            {
                // Function to check if Instrument's parent is of given family.
                bool IsFamilyType(Type instrumentType)
                {
                    return instrumentType.BaseType.Name.ToLower()
                        .Equals(strFamily);
                }

                // Horribly cursed recursive Function for checking if object
                // or any of instrument's ancestors belong to given family.
                bool AltIsFamilyType(Type instrumentType)
                {
                    bool isFamily = instrumentType != null
                        && !instrumentType.FullName.ToLower()
                            .Contains("musicalinstrument")
                            ? instrumentType.FullName.ToLower()
                            .Contains(strFamily)
                                ? true
                                : AltIsFamilyType(instrumentType.BaseType)
                            : false;
                    return isFamily;
                }

                /* 
                 * IsFamilyType will only check if the direct parent belongs to 
                 * the given family name. 
                 * 
                 * AltIsFamilyType will check if the Instrument itself or any 
                 * of its ancestors belong to the given name. 
                 * 
                 * In this implementation, the first method is used.
                 */

                // Create Action Function for adding instrument to family list.
                Action<MusicalInstrument> AddToFamilyList = (instrument) =>
                {
                    if (IsFamilyType(instrument.GetType()))
                    {
                        familyInstruments.Add(instrument);
                    }
                };

                // Return Action Function variable.
                return AddToFamilyList;
            }

            // Create Action Function variable.
            Action<MusicalInstrument> AddToFamilyListAction = 
                CreatePrintFamilySoundAction();

            // For each instrument, if belongs to family, add to family list.
            ListInstruments.ForEach(AddToFamilyListAction);

            // Sort family list before returning. 
            familyInstruments.Sort();

            // Return family list.
            return familyInstruments;
        }

        // Sort Instruments hrough IComparable interface.
        public void SortInstruments()
        {
            // My name sorted is: aaegkllwyy
            ListInstruments.Sort();
        }

        // Return singleton Music Shop instance.
        public static MusicShop MusicShopFactory()
        {
            return musicShop;
        }

        // Method for returning Factory methods for creating instruments.
        public Dictionary<string, Func<decimal, MusicalInstrument>> GetInstrumentFactories()
        {
            // Create dictionary for holding instrument name and factory.
            Dictionary<string, Func<decimal, MusicalInstrument>> dictInstrumentFactories = new Dictionary<string, Func<decimal, MusicalInstrument>>();

            // Add all instruments factories to dictionary by name.
            dictInstrumentFactories.Add("Drum", Drum.MakeInstrument);
            dictInstrumentFactories.Add("Flute", Flute.MakeInstrument);
            dictInstrumentFactories.Add("Guitar", Guitar.MakeInstrument);
            dictInstrumentFactories.Add("Harp", Harp.MakeInstrument);
            dictInstrumentFactories.Add("Xylophone", Xylophone.MakeInstrument);

            // Return instrument factory dictionary.
            return dictInstrumentFactories;
        }

        // Methods for returning list of instrument family names.
        public List<string> GetInstrumentFamilies()
        {
            return new List<string>()
            {
                "StringInstrument", 
                "PercussionInstrument",
                "WoodwindInstrument"
            };
        }
    }
}