namespace DMCal3d.Net.Builders.Morph
{
    public class MorphBuilder : BaseAssetBuilder
    {
        private const string HeaderMagic = "XPF";
        private const string HeaderVersion = "919";
        private const string RootName = "ANIMATION";
        private const string DefaultSerializedName = "morph";
        private const string NumTracksAttributeName = "NUMTRACKS";
        private const string DurationAttributeName = "DURATION";

        public MorphBuilder(string serializedName = DefaultSerializedName) : base(serializedName)
        {
            CreateHeader(HeaderMagic, HeaderVersion);
            CreateRealRoot(RootName);
        }

        public void SetNumTracks(string value)
        {
            RealRoot.SetAttributeValue(NumTracksAttributeName, value);
        }

        public void SetDuration(string value)
        {
            RealRoot.SetAttributeValue(DurationAttributeName, value);
        }

        public MorphTrack AddTrack()
        {
            MorphTrack track = new();
            RealRoot.Add(track.Element);
            return track;
        }
    }
}
