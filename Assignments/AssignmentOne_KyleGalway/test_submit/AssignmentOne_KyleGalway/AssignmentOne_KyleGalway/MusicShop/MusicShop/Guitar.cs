/*
 * Assignment: 1
 * Name: Kyle Galway
 * ID: 991418738
 * This is the model class for creating Guitar objects.
*/
namespace MusicShop
{
    internal class Guitar: StringInstrument
    {
        public static Guitar MakeInstrument(decimal numPrice)
        {
            string strSound = "vibrating strings";
            string strPitchType = "low to high pitch";
            Guitar guitar = new Guitar(strSound: strSound, strPitchType: 
                strPitchType, numPrice: numPrice);
            return guitar;
        }

        private Guitar(string strSound, decimal numPrice, string strPitchType):
            base(strSound, numPrice, strPitchType) {}

        public override string ToString()
        {
            return "Guitar";
        }

        public override string HowToPlay()
        {
            return "by strumming the strings";
        }
    }
}
