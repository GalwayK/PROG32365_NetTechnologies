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
        private MusicShop()
        {
            ListInstruments = new List<MusicalInstrument>();
        }

        static readonly MusicShop musicShop = new MusicShop();

        public List<MusicalInstrument> ListInstruments
        {
            get;
            private set;
        }

        public MusicalInstrument CheapestInstrument
        {
            get => (from instrument 
                    in ListInstruments 
                    orderby instrument 
                    select instrument).Last();
        }

        public MusicalInstrument PriciestInstrument
        {
            get => (from instrument 
                    in ListInstruments
                    orderby instrument 
                    select instrument).First();
        }

        public List<MusicalInstrument> GetInstrumentsByFamilyName(string 
            strFamily)
        {
            List<MusicalInstrument> familyInstruments = new
                List<MusicalInstrument>();

            Action<MusicalInstrument> CreatePrintFamilySoundAction()
            {
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

                Action<MusicalInstrument> AddToFamilyList = (instrument) =>
                {
                    if (IsFamilyType(instrument.GetType()))
                    {
                        familyInstruments.Add(instrument);
                    }
                };
                return AddToFamilyList;
            }

            Action<MusicalInstrument> AddToFamilyListAction = 
                CreatePrintFamilySoundAction();

            ListInstruments.ForEach(AddToFamilyListAction);

            familyInstruments.Sort();

            return familyInstruments;
        }

        public void SortInstruments()
        {
            ListInstruments.Sort();
        }

        public static MusicShop MusicShopFactory()
        {
            return musicShop;
        }

        public Dictionary<string, Func<decimal, MusicalInstrument>> GetInstrumentFactories()
        {
            Dictionary<string, Func<decimal, MusicalInstrument>> dictInstrumentFactories = new Dictionary<string, Func<decimal, MusicalInstrument>>();

            dictInstrumentFactories.Add("Drum", Drum.MakeInstrument);
            dictInstrumentFactories.Add("Flute", Flute.MakeInstrument);
            dictInstrumentFactories.Add("Guitar", Guitar.MakeInstrument);
            dictInstrumentFactories.Add("Harp", Harp.MakeInstrument);
            dictInstrumentFactories.Add("Xylophone", Xylophone.MakeInstrument);

            return dictInstrumentFactories;
        }

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