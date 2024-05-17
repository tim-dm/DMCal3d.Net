using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMCal3d.Net.Extensions;

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

    public static void ExtractToString(this ZipArchiveEntry entry, out string text)
    {
        using (Stream stream = entry.Open())
        {
            using (StreamReader reader = new(stream))
            {
                text = reader.ReadToEnd();
            }
        }
    }
}
