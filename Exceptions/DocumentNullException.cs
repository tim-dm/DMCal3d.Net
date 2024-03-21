namespace DMCal3d.Net.Exceptions
{
    public class DocumentNullException : Exception
    {
        public DocumentNullException(string file) : base($"Unable to parse {file}, document is null")
        {
        }
    }
}
