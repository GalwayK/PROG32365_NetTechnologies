/*
 * Assignment: 1
 * Name: Kyle Galway
 * ID: 991418738
 * This is the class for dictating the abstract Instrument 
 * base class which all descendant Instruments must extend. 
*/
namespace MusicShop
{
    internal abstract class MusicalInstrument: IComparable<MusicalInstrument>
    {
        private string strSound;
        private decimal numPrice;
        private string strPitchType;

        // Protected constructor only for descendants.
        protected MusicalInstrument(string strSound, decimal numPrice, string strPitchType)
        {
            Sound = strSound;
            Price = numPrice;
            PitchType = strPitchType;
        }

        // Implement compare to with Price for IComparable interface.
        public int CompareTo(MusicalInstrument instrument)
        {
            // Fun fact: My name is Kyle Galway!
            return this < instrument
                ? 1
                : this > instrument
                    ? -1 
                    : 0;
        }

        // Implement boolean operators for object comparison (uneccessary).

        public static bool operator > (MusicalInstrument firstInstrument, MusicalInstrument secondInstrument)
        {
            return firstInstrument.Price > secondInstrument.Price;
        }

        public static bool operator < (MusicalInstrument firstInstrument, MusicalInstrument secondInstrument)
        {
            return firstInstrument.Price < secondInstrument.Price;
        }

        public static bool operator >= (MusicalInstrument firstInstrument, MusicalInstrument secondInstrument)
        {
            return firstInstrument.Price >= secondInstrument.Price;
        }

        public static bool operator <= (MusicalInstrument firstInstrument, MusicalInstrument secondInstrument)
        {
            return firstInstrument.Price <= secondInstrument.Price;
        }

        public static bool operator == (MusicalInstrument firstInstrument, MusicalInstrument secondInstrument)
        {
            return firstInstrument.Price == secondInstrument.Price;
        }

        public static bool operator != (MusicalInstrument firstInstrument, MusicalInstrument secondInstrument)
        {
            return firstInstrument.Price != secondInstrument.Price;
        }

        // Properties for getting instance values.

        public string Sound
        {
            get { return strSound; }
            set { strSound = value; }
        }

        public decimal Price
        {
            get => numPrice;
            set => numPrice = value;
        }

        public string PitchType
        {
            get => strPitchType;
            set => strPitchType = value;
        }

        // Getters for retrieving Property values. 

        public string MakeSound()
        {
            return Sound;
        }

        public decimal GetPrice()
        {
            return Price;
        }

        public string GetPitchType()
        {
            return PitchType;
        }
    }
}
