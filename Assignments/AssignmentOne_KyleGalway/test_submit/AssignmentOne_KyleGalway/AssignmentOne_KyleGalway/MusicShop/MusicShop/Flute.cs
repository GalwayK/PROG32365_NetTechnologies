/*
 * Assignment: 1
 * Name: Kyle Galway
 * ID: 991418738
 * This is the model class for creating Flute objects.
*/
namespace MusicShop
{
    internal class Flute: WoodwindInstrument
    {
        public static Flute MakeInstrument(decimal numPrice)
        {
            string strSound = "guiding a stream of air";
            string strPitchType = "fundamental pitch is middle C";
            Flute flute = new Flute(strSound: strSound, strPitchType:
                strPitchType, numPrice: numPrice);
            return flute;
        }

        private Flute(string strSound, decimal numPrice, string strPitchType) :
            base(strSound, numPrice, strPitchType) { }

        public override string ToString()
        {
            return "Flute";
        }

        public override string HowToPlay()
        {
            return "by blowing into the flute";
        }
    }
}
