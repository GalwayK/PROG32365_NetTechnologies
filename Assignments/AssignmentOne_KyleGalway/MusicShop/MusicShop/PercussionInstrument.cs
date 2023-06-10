namespace MusicShop
{
    internal abstract class PercussionInstrument: MusicalInstrument, IFixable, IPlayable
    {
        protected PercussionInstrument(string strSound, decimal numPrice,
            string strPitchType) : base(strSound, numPrice, strPitchType) { }

        public abstract string HowToPlay();

        public abstract string HowToFix();
    }
}
