namespace DMCal3d.Net.Builders.Animation
{
    public class AnimationBuilder : BaseAssetBuilder
    {
        private const string HeaderMagic = "XAF";
        private const string HeaderVersion = "919";
        private const string RootName = "ANIMATION";
        private const string DefaultSerializedName = "animation";
        private const string DurationAttributeName = "DURATION";
        private const string DefaultDurationAttributeValue = "1.0";
        private const string NumTracksAttributeName = "NUMTRACKS";

        public AnimationBuilder(string serializedName = DefaultSerializedName) : base(serializedName)
        {
            AddHeader(HeaderMagic, HeaderVersion);
            AddRealRoot(RootName);
            RealRoot.SetAttributeValue(DurationAttributeName, DefaultDurationAttributeValue);
        }

        public AnimationTrack AddTrack()
        {
            AnimationTrack track = new();
            RealRoot.Add(track.Element);
            return track;
        }

        public void SetDuration(object value)
        {
            RealRoot.SetAttributeValue(DurationAttributeName, value);
        }

        public void SetNumTracks(object value)
        {
            RealRoot.SetAttributeValue(NumTracksAttributeName, value);
        }
    }
}
