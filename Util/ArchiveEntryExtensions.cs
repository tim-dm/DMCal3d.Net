using System.IO;
using System.IO.Compression;

namespace DMCal3d.Net.Utils
{
    public static class ArchiveEntryExtensions
    {
        /// <summary>
        /// Determines if an entry inside an archive is a directory
        /// </summary>
        /// <param name="entry">A ZipArchiveEntry to check</param>
        /// <returns>True if the entry is a directory</returns>
        public static bool IsDirectory(this ZipArchiveEntry entry)
        {
            if (entry.FullName.EndsWith("/") || entry.FullName.EndsWith(@"\") && string.IsNullOrEmpty(entry.Name))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines if an entry inside an archive is in a directory
        /// </summary>
        /// <param name="entry">A ZipArchiveEntry to check</param>
        /// <returns>True if the entry is in a directory</returns>
        public static bool ParentIsDirectory(this ZipArchiveEntry entry)
        {
            if (entry.FullName.Contains('\\') || entry.FullName.Contains('/'))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Extracts the contents of an entry to a string
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public static string ExtractToString(this ZipArchiveEntry entry)
        {
            string entryContents;

            using (Stream stream = entry.Open())
            {
                using (StreamReader reader = new(stream))
                {
                    entryContents = reader.ReadToEnd();
                }
            }

            return entryContents;
        }
    }
}
