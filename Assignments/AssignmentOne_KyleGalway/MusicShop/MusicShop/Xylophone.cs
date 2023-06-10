namespace MusicShop
{
    internal class Xylophone: PercussionInstrument
    {
        private Xylophone(string strSound, decimal numPrice, string 
            strPitchType) : base(strSound, numPrice, strPitchType) { }

        public static Xylophone MakeInstrument(decimal numPrice)
        {
            string strSound = "through resonators";
            string strPitchType = "each bar produces different pitch";

            Xylophone xylophone = new Xylophone(strSound, numPrice, 
                strPitchType);
            return xylophone;
        }

        public override string ToString()
        {
            return "Xylophone";
        }

        public override string HowToPlay()
        {
            return "with two mallets";
        }

        public override string HowToFix()
        {
            return "by replacing the bars";
        }
    }
}
