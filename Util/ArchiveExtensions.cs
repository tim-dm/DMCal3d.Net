using System;
using System.IO;
using System.IO.Compression;

namespace DMCal3d.Net.Utils
{
    public static class ArchiveExtensions
    {
        /// <summary>
        /// Extracts the contents of an entry to a string
        /// </summary>
        /// <param name="archive"></param>
        /// <param name="entryName"></param>
        /// <param name="text"></param>
        public static void ExtractToString(this ZipArchive archive, string entryName, out string text)
        {
            ZipArchiveEntry? entry = archive.GetEntry(entryName) 
                ?? throw new Exception("Entry not found");
            
            using (Stream stream = entry.Open())
            {
                using (StreamReader reader = new(stream))
                {
                    text = reader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// Creates a new ZipArchiveEntry and writes a string to it
        /// </summary>
        /// <param name="archive"></param>
        /// <param name="entryName"></param>
        /// <param name="entryContent"></param>
        public static void AddFromString(this ZipArchive archive, string entryName, string entryContent)
        {
            ZipArchiveEntry newEntry = archive.CreateEntry(entryName);

            using (StreamWriter writer = new(newEntry.Open()))
            {
                writer.Write(entryContent);
            }
        }
    }
}
