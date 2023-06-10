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