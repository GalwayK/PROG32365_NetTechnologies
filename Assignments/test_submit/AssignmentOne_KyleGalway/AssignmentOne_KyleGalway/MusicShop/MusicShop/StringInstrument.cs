/*
 * Assignment: 1
 * Name: Kyle Galway
 * ID: 991418738
 * This is the abstract class for dictating the attributes of all 
 * String Instruments, those being Guitar and Harp.
*/
namespace MusicShop
{
    internal abstract class StringInstrument: MusicalInstrument, IFixable, 
        IPlayable
    {
        protected StringInstrument(string strSound, decimal numPrice, string strPitchType) : base(strSound, numPrice, strPitchType) { }

        public abstract string HowToPlay();

        // Guitar and Harp have the same implemenation of HowToFix()
        public string HowToFix()
        {
            return "replace the strings";
        }
    }
}