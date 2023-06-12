/*
 * Assignment: 1
 * Name: Kyle Galway
 * ID: 991418738
 * This is the model class for creating Harp objects.
*/
namespace MusicShop
{
    internal class Harp: StringInstrument
    {
        private Harp(string strSound, decimal numPrice, string strPitchType):
            base(strSound, numPrice, strPitchType) { }

        public static Harp MakeInstrument(decimal numPrice)
        {
            string strSound = "vibrating strings";
            string strPitchType = "seven levels of pitch";
            Harp harp = new Harp(strSound, numPrice, strPitchType);
            return harp;
        }

        public override string ToString()
        {
            return $"Harp";
        }

        public override string HowToPlay()
        {
            return "with the thumb and the first three fingers";
        }
    }
}
