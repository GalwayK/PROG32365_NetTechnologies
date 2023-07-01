/*
 * Assignment: 1
 * Name: Kyle Galway
 * ID: 991418738
 * This is the model class for creating Drum objects.
*/
namespace MusicShop
{
    internal class Drum: PercussionInstrument
    {
        private Drum(string strSound, decimal numPrice, string strPitchType) :
            base(strSound, numPrice, strPitchType) { }

        public static Drum MakeInstrument(decimal numPrice)
        {
            string strSound = "vibrating stetched membrame";
            string strPitchType = "sonic pitch";

            Drum drum = new Drum(strSound, numPrice, strPitchType);
            return drum;
        }

        public override string ToString()
        {
            return "Drum";
        }

        public override string HowToPlay()
        {
            return "by hitting the membrane";
        }

        public override string HowToFix()
        {
            return "by replacing the membrane";
        }
    }
}
