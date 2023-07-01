/*
 * Assignment: 1
 * Name: Kyle Galway
 * ID: 991418738
 * This is the abstract class for dictating the attributes of all 
 * Woodwind Instruments, that being the Flute.
*/
namespace MusicShop
{
    internal abstract class WoodwindInstrument: MusicalInstrument, IPlayable
    {
        protected WoodwindInstrument(string strSound, decimal numPrice,
           string strPitchType) : base(strSound, numPrice, strPitchType) { }

        public abstract string HowToPlay();
    }
}
