using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop
{
    internal abstract class MusicalInstrument: IComparable<MusicalInstrument>
    {
        private string strSound;
        private decimal numPrice;
        private string strPitchType;

        protected MusicalInstrument(string strSound, decimal numPrice, string strPitchType)
        {
            Sound = strSound;
            Price = numPrice;
            PitchType = strPitchType;
        }

        public int CompareTo(MusicalInstrument instrument)
        {
            return this < instrument
                ? 1
                : this > instrument
                    ? -1 
                    : 0;
        }

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
