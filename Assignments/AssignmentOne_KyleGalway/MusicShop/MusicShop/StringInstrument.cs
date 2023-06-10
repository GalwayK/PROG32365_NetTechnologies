namespace MusicShop
{
    internal abstract class StringInstrument: MusicalInstrument, IFixable, IPlayable
    {
        protected StringInstrument(string strSound, decimal numPrice, string strPitchType) : base(strSound, numPrice, strPitchType) { }

        public abstract string HowToPlay();

        public string HowToFix()
        {
            return "replace the strings";
        }
    }
}
