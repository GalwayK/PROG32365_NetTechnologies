namespace MusicShop
{
    internal abstract class WoodwindInstrument: MusicalInstrument, IPlayable
    {
        protected WoodwindInstrument(string strSound, decimal numPrice,
           string strPitchType) : base(strSound, numPrice, strPitchType) { }

        public abstract string HowToPlay();
    }
}
