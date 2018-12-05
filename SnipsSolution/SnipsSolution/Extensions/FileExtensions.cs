using System;

namespace SnipsSolution.Extensions
{
    public static class FileExtensions
    {
        public static string ToFileSize(this long size)
        {
            if (size < 1024) { return (size).ToString("F1") + " bytes"; }
            if (size < Math.Pow(1024, 2)) { return (size / 1024).ToString("F1") + " KB"; }
            if (size < Math.Pow(1024, 3)) { return (size / Math.Pow(1024, 2)).ToString("F1") + " MB"; }
            if (size < Math.Pow(1024, 4)) { return (size / Math.Pow(1024, 3)).ToString("F1") + " GB"; }
            if (size < Math.Pow(1024, 5)) { return (size / Math.Pow(1024, 4)).ToString("F1") + " TB"; }
            if (size < Math.Pow(1024, 6)) { return (size / Math.Pow(1024, 5)).ToString("F1") + " PB"; }
            return (size / Math.Pow(1024, 6)).ToString("F1") + " EB";
        }
    }
}