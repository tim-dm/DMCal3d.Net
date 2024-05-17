using System.IO.Compression;

namespace DMCal3d.Net.Extensions;

public static class ZipArchiveExtensions
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
        ZipArchiveEntry? existingEntry = archive.GetEntry(entryName);
        existingEntry?.Delete();

        ZipArchiveEntry newEntry = archive.CreateEntry(entryName);

        using (StreamWriter writer = new(newEntry.Open()))
        {
            writer.Write(entryContent);
        }
    }

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
}
