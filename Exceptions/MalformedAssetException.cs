namespace DMCal3d.Net.Exceptions
{
    public class MalformedAssetException : Exception
    {
        public MalformedAssetException(string file) : base($"Unable to parse asset, {file} is malformed")
        {
        }
    }
}
