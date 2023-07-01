/*
 * Assignment: 1
 * Name: Kyle Galway
 * ID: 991418738
 * This is the abstract class for dictating the attributes of all 
 * PercussionInstruments descendants - those being Drum and Xylophone.
*/
namespace MusicShop
{
    internal abstract class PercussionInstrument: MusicalInstrument, IFixable, 
        IPlayable
    {
        protected PercussionInstrument(string strSound, decimal numPrice,
            string strPitchType) : base(strSound, numPrice, strPitchType) { }

        public abstract string HowToPlay();

        public abstract string HowToFix();
    }
}
